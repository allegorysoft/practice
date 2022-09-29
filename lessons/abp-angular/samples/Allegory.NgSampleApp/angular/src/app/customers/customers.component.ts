import { Component, OnInit } from '@angular/core';
import { ABP, LocalizationService, PermissionService } from '@abp/ng.core';
import { CustomerDto } from './models/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html'
})
export class CustomersComponent implements OnInit {
  //#region Fields
  readonly customers: CustomerDto[] = [
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
    //#region Authorization
    const policies = this.permissionService.filterItemsByPolicy(
      [
        { requiredPolicy: 'NgSampleApp.Customers' },
        { requiredPolicy: 'NgSampleApp.Customers.Create' }
      ] as ABP.HasPolicy[]
    );
    // console.log(policies);
    //#endregion
  }
  //#endregion

  //#region Methods
  ngOnInit(): void {
    this.localizationService.get('NgSampleApp::Create').subscribe(console.log);

    // const response = this.localizationService.instant(
    //   {
    //     key: 'NgSampleApp::UserDeletionConfirmation',
    //     defaultValue: 'Verilen key e uygun değer bulamazsan bunu yaz',
    //   },
    //   'Masum'
    // );
    // console.log(response);
  }
  //#endregion
}
