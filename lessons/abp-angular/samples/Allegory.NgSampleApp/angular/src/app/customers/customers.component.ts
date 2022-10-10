import { Component } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CustomerDto } from './models/customer';
import { EXTENSIONS_IDENTIFIER } from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from './enums';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  providers: [
    ListService,
    {
      provide: EXTENSIONS_IDENTIFIER,
      useValue: eCustomersComponents.Customers,
    },
  ]
})
export class CustomersComponent {
  private readonly customers = <CustomerDto[]>[
    {
      id: '688e5469-143c-465e-b6ce-3ac85ea7ad17',
      identityNumber: '98765432109',
      name: 'Ahmet Faruk',
      surname: 'ULU',
      gender: 1
    },
    {
      id: 'ad11e9c8-7b4e-4181-b8f8-cacde10c529f',
      identityNumber: '12345678901',
      name: 'Masum',
      surname: 'ULU',
      gender: 1
    },
    {
      id: '33e725c6-eb67-45d1-9114-d667cd13791f',
      identityNumber: '12345678902',
      name: 'Gaye',
      surname: 'BAŞAR',
      gender: 0
    }
  ];

  data: PagedResultDto<CustomerDto> = {
    items: this.customers,
    totalCount: this.customers.length
  };

  constructor(public readonly list: ListService<CustomerDto>) { }
}
