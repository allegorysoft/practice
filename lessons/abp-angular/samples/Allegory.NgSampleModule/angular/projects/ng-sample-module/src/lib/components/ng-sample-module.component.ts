import { Component, inject, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { EXTENSIONS_IDENTIFIER } from '@abp/ng.theme.shared/extensions';
import {
  Confirmation,
  ConfirmationService,
  ToasterService,
} from '@abp/ng.theme.shared';
import {
  CustomerCreateOrUpdateBase,
  CustomerDto,
  SampleService,
} from '../proxy/samples';
import { eNgSampleModuleComponents } from '../enums';

@Component({
  selector: 'lib-ng-sample-module',
  templateUrl: 'ng-sample-module.component.html',
  providers: [
    ListService,
    {
      provide: EXTENSIONS_IDENTIFIER,
      useValue: eNgSampleModuleComponents.NgSampleModule,
    },
  ],
})
export class NgSampleModuleComponent implements OnInit {
  //#region Services
  private readonly service = inject(SampleService);
  private readonly confirmationService = inject(ConfirmationService);
  private readonly toasterService = inject(ToasterService);
  public readonly list = inject(ListService<CustomerDto[]>);
  //#endregion

  data: PagedResultDto<CustomerDto> = { items: [], totalCount: 0 };

  private getCustomers(): void {
    this.service.customers$.subscribe(res => {
      this.data.items = res;
      this.data.totalCount = res.length;
    });
  }

  ngOnInit(): void {
    this.getCustomers();

    //#region HTTP Request
    // this.list
    //   .hookToQuery(query => this.service.getList(query))
    //   .subscribe((res: PagedResultDto<CustomerDto>) => (this.data = res));
    //#endregion
  }

  delete(id: string, name: string): void {
    this.confirmationService
      .warn(
        'NgSampleModule::CustomerDeletionConfirmationMessage',
        'NgSampleModule::AreYouSure',
        {
          messageLocalizationParams: [name],
        }
      )
      .subscribe((status: Confirmation.Status) => {
        if (status === Confirmation.Status.confirm) {
          this.toasterService.success('AbpUi::SuccessfullyDeleted');
          this.service.deleteCustomer(id).subscribe(() => {
            this.getCustomers();
            // this.list.get(); // Refresh list from server
          });
        }
      });
  }

  create(): void {
    const input = {
      name: `Test-${Math.floor(Math.random() * 10)}`,
      birthDate: new Date().getDate().toLocaleString(''),
      salary: Math.floor(1000 + Math.random() * 5000),
    } as CustomerCreateOrUpdateBase;

    this.service.createCustomer(input).subscribe(() => {
      this.getCustomers();
      // this.list.get();// Refresh list from server
    });
  }
}
