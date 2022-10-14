import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { UsersExtendedComponent } from './components/users-extended/users-extended.component';
import { IdentityModule } from '@abp/ng.identity';
import {
  identityCreateFormPropContributors,
  identityEditFormPropContributors,
  identityEntityActionContributors,
  identityEntityPropContributors
} from './contributors';


@NgModule({
  imports: [
    CoreModule,
    ThemeSharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: UsersExtendedComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              IdentityModule.forLazy({
                entityActionContributors: identityEntityActionContributors,
                createFormPropContributors: identityCreateFormPropContributors,
                editFormPropContributors: identityEditFormPropContributors,
                entityPropContributors: identityEntityPropContributors
              }),
          },
        ],
      },
    ])
  ],
  declarations: [UsersExtendedComponent]
})
export class IdentityExtendedModule { }
