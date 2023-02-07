import { Component, inject, Injector, OnInit } from '@angular/core';
import { UntypedFormGroup } from '@angular/forms';
import { finalize } from 'rxjs';
import { ListService, PagedResultDto } from '@abp/ng.core';
import {
  Confirmation,
  ConfirmationService,
  ToasterService,
} from '@abp/ng.theme.shared';
import {
  EXTENSIONS_IDENTIFIER,
  FormPropData,
  generateFormFromProps,
} from '@abp/ng.theme.shared/extensions';
import { CustomerDto, SampleService } from '../proxy/samples';
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
  private readonly injector = inject(Injector);
  private readonly service = inject(SampleService);
  private readonly confirmationService = inject(ConfirmationService);
  private readonly toasterService = inject(ToasterService);
  public readonly list = inject(ListService<CustomerDto[]>);
  //#endregion

  //#region Fields
  data: PagedResultDto<CustomerDto> = { items: [], totalCount: 0 };
  selected: CustomerDto;
  form: UntypedFormGroup;
  isModalVisible: boolean;
  modalBusy = false;
  //#endregion

  //#region Utilities
  private getCustomers(): void {
    this.service.customers$.subscribe(res => {
      this.data.items = res;
      this.data.totalCount = res.length;
    });
  }

  private hookToQuery(): void {
    // this.list
    //   .hookToQuery(query => this.service.getList(query))
    //   .subscribe((res: PagedResultDto<CustomerDto>) => (this.data = res));
  }
  //#endregion

  //#region Methods
  ngOnInit(): void {
    this.getCustomers();
  }

  buildForm() {
    const data = new FormPropData(this.injector, this.selected);
    this.form = generateFormFromProps(data);
  }

  openModal() {
    this.buildForm();
    this.isModalVisible = true;
  }

  add() {
    this.selected = {} as CustomerDto;
    this.openModal();
  }

  edit(id: string) {
    this.service.getCustomer(id).subscribe(res => {
      this.selected = res;
      this.openModal();
    });
  }

  save() {
    if (!this.form.valid) return;
    this.modalBusy = true;

    const { id } = this.selected;
    const input = this.form.value;
    (id
      ? this.service.updateCustomer(id, input)
      : this.service.createCustomer(input)
    )
      .pipe(finalize(() => (this.modalBusy = false)))
      .subscribe(() => {
        this.isModalVisible = false;
        // this.list.get();// Refresh list from server
      });
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
            // this.list.get(); // Refresh list from server
          });
        }
      });
  }
  //#endregion
}
