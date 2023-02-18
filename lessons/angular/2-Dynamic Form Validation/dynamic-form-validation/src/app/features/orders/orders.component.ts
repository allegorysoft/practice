import { Component, inject } from '@angular/core';
import { AsyncPipe, JsonPipe } from '@angular/common';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

import { TranslateModule } from '@ngx-translate/core';

import { SharedModule } from '@app/shared.module';
import { CustomerService } from '@app/features/customers';
import { CustomErrorComponent } from '@app/custom-error.component';

const { required, minLength } = Validators;

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [
    JsonPipe,
    AsyncPipe,
    SharedModule,
    TranslateModule,
    CustomErrorComponent,
  ],
  templateUrl: './orders.component.html',
})
export default class OrdersComponent {
  customers$ = inject(CustomerService).getList();

  orderForm = inject(FormBuilder).group({
    customer: new FormControl('', {
      nonNullable: true,
      validators: [required],
    }),
    number: new FormControl('', {
      nonNullable: true,
      validators: [required, minLength(5)],
    }),
  });

  get customer(): FormControl<string> {
    return this.orderForm.controls.customer;
  }

  get number(): FormControl<string> {
    return this.orderForm.controls.number;
  }

  hasTouchedOrDirty = (control: FormControl<any>): boolean =>
    control.touched || control.dirty;

  isInvalid = (control: FormControl<any>): boolean =>
    this.hasTouchedOrDirty(control) && control.invalid;

  save(): void {
    if (this.orderForm.invalid) {
      this.orderForm.markAllAsTouched();
      return;
    }

    console.log(this.orderForm.value);
    this.orderForm.reset();
  }
}
