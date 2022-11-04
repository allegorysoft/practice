import { Component, Injector } from '@angular/core';

import { ListService, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { ConfirmationService, ToasterService } from '@abp/ng.theme.shared';
import { EXTENSIONS_IDENTIFIER } from '@abp/ng.theme.shared/extensions';
import { eIdentityComponents, RolesComponent } from '@abp/ng.identity';
import { IdentityRoleService } from '@abp/ng.identity/proxy';

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
export class RolesExtendedComponent extends RolesComponent {
  constructor(
    public readonly list: ListService<PagedAndSortedResultRequestDto>,
    protected confirmationService: ConfirmationService,
    toasterService: ToasterService,
    protected injector: Injector,
    protected service: IdentityRoleService,
  ) {
    super(
      list,
      confirmationService,
      toasterService,
      injector,
      service
    );
  }
}
