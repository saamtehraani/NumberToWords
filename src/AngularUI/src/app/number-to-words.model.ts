import { FormControl } from "@angular/forms";

export interface NumberToWordsModel {
  number: number;
}

export interface NumberToWordsResultModel {
  result: string;
}

export interface NumberToWordsForm {
  number: FormControl<number | null>;
}