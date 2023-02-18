import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export class CodeValidators {
  static startWith(value: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      return !control.value.startsWith(value)
        ? {
            invalidCode: {
              value,
              message: 'invalidCode',
            },
          }
        : null;
    };
  }
}
