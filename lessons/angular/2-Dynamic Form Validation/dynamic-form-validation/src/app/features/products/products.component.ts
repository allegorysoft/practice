import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

import { CurrencyMaskModule } from 'ng2-currency-mask';
import { NgxValidateCoreModule } from '@ngx-validate/core';

import { SharedModule } from '@app/shared.module';

import { CodeValidators } from '@app/features/shared';

const { required, min, minLength } = Validators;
const { startWith } = CodeValidators;

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [SharedModule, CurrencyMaskModule, NgxValidateCoreModule],
  templateUrl: './products.component.html',
})
export default class ProductsComponent {
  form = inject(FormBuilder).group({
    code: new FormControl('', {
      nonNullable: true,
      validators: [required, minLength(5), startWith('ABC')],
    }),
    name: new FormControl('', {
      nonNullable: true,
      validators: [required, minLength(3)],
    }),
    price: new FormControl(0, {
      nonNullable: true,
      validators: [required, min(1)],
    }),
  });

  save(): void {
    if (this.form.invalid) {
      return;
    }
    console.log(this.form.value);
  }
}
