import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NumberToWordsService } from './number-to-words.service';
import { EMPTY, Observable, Subject, catchError, takeUntil } from 'rxjs';
import { NumberToWordsResultModel } from './number-to-words.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  private _destroy = new Subject<void>();
  private destroy$ = this._destroy as Observable<void>;

  public result: NumberToWordsResultModel | null = null;

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private numberToWordsService: NumberToWordsService,
  ) {
    this.form = this.fb.group({
      number: ['', [Validators.required]]
    });
  }

  public onSubmit(): void {
    const model = this.form.value;

    this.numberToWordsService.post$(model).pipe(
      takeUntil(this.destroy$),
      catchError(err => {
        console.log(err);
        return EMPTY;
      })
    ).subscribe((result) => {
      this.result = result;
    });
  }

  get number() {
    return this.form.get('number');
  }

  ngOnDestroy(): void {
    this._destroy.next();
    this._destroy.complete();
  }
}
