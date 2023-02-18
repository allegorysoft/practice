import { AsyncPipe } from '@angular/common';
import { Component, inject, Input, Optional, SkipSelf } from '@angular/core';
import {
  ControlContainer,
  FormArray,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { SharedModule } from '@app/shared.module';
import { TranslateService } from '@ngx-translate/core';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CurrencyMaskModule } from 'ng2-currency-mask';

import { PrimengModule, CodeValidators } from '../shared';
import { CustomerService } from './customer.service';
import { Order } from './models';

const { required, min } = Validators;
const { startWith } = CodeValidators;

@Component({
  selector: 'app-customer-orders',
  standalone: true,
  imports: [
    AsyncPipe,
    SharedModule,
    CurrencyMaskModule,
    NgxValidateCoreModule,
    PrimengModule,
  ],
  viewProviders: [
    {
      provide: ControlContainer,
      useFactory(dependency?: any) {
        return dependency;
      },
      deps: [[new Optional(), new SkipSelf(), ControlContainer]],
    },
  ],
  templateUrl: './customer-orders.component.html',
})
export class CustomerOrdersComponent {
  private readonly translate = inject(TranslateService);

  products$ = inject(CustomerService).products;

  @Input() orders!: FormArray<FormGroup<Order>>;

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
    this.orders.push(
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
}
