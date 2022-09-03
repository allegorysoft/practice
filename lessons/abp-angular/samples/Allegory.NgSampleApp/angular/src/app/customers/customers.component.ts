import { Component, OnInit } from '@angular/core';
import { ABP, LocalizationService, PermissionService } from '@abp/ng.core';
import { Customer } from '../models/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html'
})
export class CustomersComponent implements OnInit {
  //#region Fields
  readonly customers: Customer[] = [
    {
      id: '688e5469-143c-465e-b6ce-3ac85ea7ad17',
      name: 'Ahmet Faruk',
      surname: 'ULU'
    },
    {
      id: 'ad11e9c8-7b4e-4181-b8f8-cacde10c529f',
      name: 'Masum',
      surname: 'ULU'
    }
  ];

  hasAnyPolicy: boolean = this.permissionService.getGrantedPolicy(
    'NgSampleApp.Customers.Update || NgSampleApp.Customers.Delete'
  );
  //#endregion

  //#region Ctor
  constructor(
    private readonly permissionService: PermissionService,
    private readonly localizationService: LocalizationService
  ) {
    const policies = this.permissionService.filterItemsByPolicy(
      [
        { requiredPolicy: 'NgSampleApp.Customers' },
        { requiredPolicy: 'NgSampleApp.Customers.Create' }
      ] as ABP.HasPolicy[]
    );
    // console.log(policies);
  }
  //#endregion

  //#region Methods
  ngOnInit(): void {
    this.localizationService.get('NgSampleApp::Create').subscribe(console.log);
  }
  //#endregion
}
