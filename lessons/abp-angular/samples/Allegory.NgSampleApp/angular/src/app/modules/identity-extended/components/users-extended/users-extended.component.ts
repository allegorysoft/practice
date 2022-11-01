import { ListService } from '@abp/ng.core';
import { eIdentityComponents, UsersComponent } from '@abp/ng.identity';
import { GetIdentityUsersInput, IdentityUserService } from '@abp/ng.identity/proxy';
import { ConfirmationService, ToasterService } from '@abp/ng.theme.shared';
import { EXTENSIONS_IDENTIFIER } from '@abp/ng.theme.shared/extensions';
import { Component, Injector } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-users-extended',
  templateUrl: './users-extended.component.html',
  providers: [
    ListService,
    {
      provide: EXTENSIONS_IDENTIFIER,
      useValue: eIdentityComponents.Users,
    }
  ]
})
export class UsersExtendedComponent extends UsersComponent {
  constructor(
    public readonly list: ListService<GetIdentityUsersInput>,
    protected confirmationService: ConfirmationService,
    protected service: IdentityUserService,
    private _toasterService: ToasterService,
    protected fb: FormBuilder,
    protected injector: Injector,
  ) {
    super(
      list,
      confirmationService,
      service,
      _toasterService,
      fb,
      injector
    );
  }

  openModal(): void {
    super.buildForm();
    this.isModalVisible = true;
  }

  edit(id: string): void {
    this.service
      .get(id)
      .pipe(
        tap(user => (this.selected = user)),
        switchMap(() => this.service.getRoles(id)),
      )
      .subscribe(userRole => {
        this.selectedUserRoles = userRole.items || [];
        this.openModal();
      });
  }
}
