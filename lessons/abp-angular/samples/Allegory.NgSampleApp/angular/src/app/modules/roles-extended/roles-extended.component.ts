import { Component, Injector, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { finalize } from 'rxjs/operators';

import {
  ListService,
  PagedAndSortedResultRequestDto,
  PagedResultDto
} from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import {
  EXTENSIONS_IDENTIFIER,
  FormPropData,
  generateFormFromProps
} from '@abp/ng.theme.shared/extensions';
import { eIdentityComponents, RolesComponent } from '@abp/ng.identity';
import { IdentityRoleDto, IdentityRoleService } from '@abp/ng.identity/proxy';
import { ePermissionManagementComponents } from '@abp/ng.permission-management';

@Component({
  selector: 'app-roles-extended',
  templateUrl: './roles-extended.component.html',
  providers: [
    ListService,
    {
      provide: EXTENSIONS_IDENTIFIER,
      useValue: eIdentityComponents.Roles,
    },
    {
      provide: RolesComponent,
      useExisting: RolesExtendedComponent
    }
  ]
})
export class RolesExtendedComponent implements OnInit {
  //#region Fields
  data: PagedResultDto<IdentityRoleDto> = { items: [], totalCount: 0 };

  form: FormGroup;

  selected: IdentityRoleDto;

  isModalVisible: boolean;

  visiblePermissions = false;

  providerKey: string;

  modalBusy = false;

  permissionManagementKey = ePermissionManagementComponents.PermissionManagement;

  onVisiblePermissionChange = event => {
    this.visiblePermissions = event;
  };
  //#endregion

  //#region Utilities
  private hookToQuery() {
    this.list.hookToQuery(query => this.service.getList(query)).subscribe(
      res => (this.data = res)
    );
  }
  //#endregion

  //#region Ctor
  constructor(
    public readonly list: ListService<PagedAndSortedResultRequestDto>,
    protected confirmationService: ConfirmationService,
    protected injector: Injector,
    protected service: IdentityRoleService,
  ) { }
  //#endregion

  //#region Methods
  ngOnInit() {
    this.hookToQuery();
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
    this.selected = {} as IdentityRoleDto;
    this.openModal();
  }

  edit(id: string) {
    this.service.get(id).subscribe(res => {
      this.selected = res;
      this.openModal();
    });
  }

  save() {
    if (!this.form.valid) return;
    this.modalBusy = true;

    const { id } = this.selected;
    (id
      ? this.service.update(id, { ...this.selected, ...this.form.value })
      : this.service.create(this.form.value)
    )
      .pipe(finalize(() => (this.modalBusy = false)))
      .subscribe(() => {
        this.isModalVisible = false;
        this.list.get();
      });
  }

  delete(id: string, name: string) {
    this.confirmationService
      .warn('AbpIdentity::RoleDeletionConfirmationMessage', 'AbpIdentity::AreYouSure', {
        messageLocalizationParams: [name],
      })
      .subscribe((status: Confirmation.Status) => {
        if (status === Confirmation.Status.confirm) {
          this.service.delete(id).subscribe(() => this.list.get());
        }
      });
  }

  openPermissionsModal(providerKey: string) {
    this.providerKey = providerKey;
    setTimeout(() => {
      this.visiblePermissions = true;
    }, 0);
  }

  sort(data) {
    const { prop, dir } = data.sorts[0];
    this.list.sortKey = prop;
    this.list.sortOrder = dir;
  }
  //#endregion
}
