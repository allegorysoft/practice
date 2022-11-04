import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { UiExtensionsModule } from '@abp/ng.theme.shared/extensions';
import { PermissionManagementModule } from '@abp/ng.permission-management';

import { NgxValidateCoreModule } from '@ngx-validate/core';

import { RolesExtendedComponent } from './roles-extended.component';


@NgModule({
  declarations: [RolesExtendedComponent],
  imports: [
    CommonModule,

    CoreModule.forChild({
      localizations: [
        {
          culture: 'tr',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: { ExtendedRoles: 'Genişletilmiş roller' },
            },
          ],
        },
        {
          culture: 'en',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: { ExtendedRoles: 'Extended roles' }
            }
          ]
        }
      ]
    }),
    ThemeSharedModule,
    UiExtensionsModule,
    PermissionManagementModule,
    NgxValidateCoreModule,
  ],
  exports: [RolesExtendedComponent]
})
export class RolesExtendedModule { }
