import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { NumberToWordsModel, NumberToWordsResultModel } from './number-to-words.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NumberToWordsService  {
  private numberToWordsUrl = environment.numberToWordsAPIUrl + 'numbertowords';

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(
    private http: HttpClient
  ) {
  }

  public post$(numberToWordsModel: NumberToWordsModel): Observable<NumberToWordsResultModel> {
    return this.http.post<NumberToWordsResultModel>(this.numberToWordsUrl, numberToWordsModel, { headers: this.headers })
      .pipe(
        catchError(this.handleError)
      );
  }

  protected handleError(err: HttpErrorResponse): Observable<never> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error}`;
    } 
    console.error(err);
    return throwError(() => err);
  }
  
}