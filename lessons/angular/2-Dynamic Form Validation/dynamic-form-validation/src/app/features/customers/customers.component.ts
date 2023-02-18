import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  FormGroupDirective,
  Validators,
} from '@angular/forms';

import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CurrencyMaskModule } from 'ng2-currency-mask';

import { SharedModule } from '@app/shared.module';
import { PrimengModule } from '@app/features/shared';

import { Order } from './models';
import { CustomerService } from './customer.service';
import { CustomerOrdersComponent } from './customer-orders.component';

const { required } = Validators;

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [
    AsyncPipe,
    SharedModule,
    NgxValidateCoreModule,
    CurrencyMaskModule,
    PrimengModule,
    CustomerOrdersComponent,
  ],
  templateUrl: './customers.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class CustomersComponent {
  countries$ = inject(CustomerService).countries;
  customerForm = inject(FormBuilder).group({
    name: new FormControl('', {
      nonNullable: true,
      validators: [required],
    }),
    countryId: new FormControl('', {
      nonNullable: true,
      validators: [required],
    }),
    orders: new FormArray<FormGroup<Order>>([]),
  });

  private clearOrders(): void {
    this.customerForm.controls.orders.clear();
  }

  save(form: FormGroupDirective): void {
    if (this.customerForm.invalid) {
      return;
    }

    console.log(this.customerForm.value);
    form.resetForm();
    this.clearOrders();
  }
}
