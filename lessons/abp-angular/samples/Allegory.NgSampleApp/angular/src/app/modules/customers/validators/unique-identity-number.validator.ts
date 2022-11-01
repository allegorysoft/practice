import {
    AbstractControl,
    AsyncValidatorFn,
    ValidationErrors,
    ValidatorFn
} from "@angular/forms";
import { Observable, of } from "rxjs";
import { delay, map } from "rxjs/operators";

export function uniqueIdentityNumber(identityNumber: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        return control.value === '12345678901' && control.value !== identityNumber ?
            {
                uniqueIdentityNumber:
                {
                    value: control.value,
                    identityNumber: control.value
                }
            } : null;
    };
}

export class IdentityNumberValidator {
    private static check() {
        return of(true)
    }

    static validate(identityNumber: string): AsyncValidatorFn {
        return (control: AbstractControl): Observable<ValidationErrors | null> => {
            return this.check().pipe(
                delay(250),
                map(() => control.value === '12345678901' &&
                    control.value !== identityNumber ?
                    {
                        uniqueIdentityNumber:
                        {
                            value: control.value,
                            identityNumber: control.value
                        }
                    } : null)
            );
        };
    }
}
