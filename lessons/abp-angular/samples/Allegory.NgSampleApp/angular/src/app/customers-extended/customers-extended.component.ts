import { Component } from '@angular/core';
import { CustomerDto } from '../customers/models/customer';

@Component({
  selector: 'app-customers-extended',
  templateUrl: './customers-extended.component.html'
})
export class CustomersExtendedComponent {
  isCustomerQuickViewVisible!: boolean;

  customer!: CustomerDto;

  openUserQuickView(record: CustomerDto):void {
    this.customer = new Proxy(record, {
      get: (target, prop) => target[prop] || '—',
    });
    this.isCustomerQuickViewVisible = true;
  }
}
