import { AsyncPipe, CommonModule, JsonPipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
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

import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { DropdownModule } from 'primeng/dropdown';
import { TableModule } from 'primeng/table';

import { SharedModule } from '@app/shared.module';
import { CodeValidators } from '@app/features/shared';

import { ButtonModule } from 'primeng/button';
import { CustomerService } from './customer.service';
import { TranslateService } from '@ngx-translate/core';

const { required, min } = Validators;
const { startWith } = CodeValidators;

export interface Order {
  id: FormControl<string | null>;
  number: FormControl<string>;
  productId: FormControl<string>;
  price: FormControl<number>;
  amount: FormControl<number>;
}

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [
    CommonModule,
    AsyncPipe,
    JsonPipe,
    SharedModule,
    CurrencyMaskModule,
    NgxValidateCoreModule,
    InputTextModule,
    InputNumberModule,
    DropdownModule,
    ButtonModule,
    TableModule,
  ],
  templateUrl: './customers.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class CustomersComponent {
  private readonly customerService = inject(CustomerService);
  private readonly translate = inject(TranslateService);

  countries$ = this.customerService.countries;
  products$ = this.customerService.products;
  customerForm = inject(FormBuilder).group({
    name: new FormControl('', {
      nonNullable: true,
      validators: [required],
    }),
    country: new FormControl('', {
      nonNullable: true,
      validators: [required],
    }),
    orders: new FormArray<FormGroup<Order>>([]),
  });

  get orders() {
    return this.customerForm.controls.orders as FormArray<FormGroup<Order>>;
  }

  get currency(): string {
    let currency = 'TRY';
    switch (this.translate.currentLang) {
      case 'en':
        currency = 'USD';
        break;
      case 'tr':
        currency = 'TRY';
        break;
    }
    return currency;
  }

  get locale(): string {
    let locale = 'TRY';
    switch (this.translate.currentLang) {
      case 'en':
        locale = 'us-US';
        break;
      case 'tr':
        locale = 'tr-TR';
        break;
    }
    return locale;
  }

  ngOnInit(): void {
    this.addNewRow();
  }

  addNewRow(): void {
    this.customerForm.controls.orders.push(
      new FormGroup({
        id: new FormControl('', { validators: [] }),
        number: new FormControl('', {
          nonNullable: true,
          validators: [required, startWith('ORD')],
        }),
        productId: new FormControl('', {
          nonNullable: true,
          validators: [required],
        }),
        price: new FormControl(0, {
          nonNullable: true,
          validators: [required, min(0)],
        }),
        amount: new FormControl(0, {
          nonNullable: true,
          validators: [required, min(0)],
        }),
      }),
    );
  }

  remove(i: number): void {
    if (i < 0) return;
    this.orders.removeAt(i);
  }

  save(form: FormGroupDirective): void {
    if (this.customerForm.invalid) {
      return;
    }

    form.resetForm();
    this.clearOrders();
  }

  private clearOrders() {
    this.orders.clear();
    this.addNewRow();
  }
}
