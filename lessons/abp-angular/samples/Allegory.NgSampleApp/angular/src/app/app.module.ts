import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { ThemeSharedModule, THEME_SHARED_APPEND_CONTENT } from '@abp/ng.theme.shared';
import { ThemeBasicModule } from '@abp/ng.theme.basic';
import { AccountConfigModule } from '@abp/ng.account/config';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';

import {
  ValidationErrorComponent,
  VALIDATION_ERROR_TEMPLATE,
  VALIDATION_INVALID_CLASSES,
  VALIDATION_TARGET_SELECTOR
} from '@ngx-validate/core';

import { environment } from '../environments/environment';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { ExtendedPermissionService } from './services/extended-permission.service';
import { AppRoutingModule } from './app-routing.module';

import { ConfigComponent } from './components/config/config.component';
import { NavItemsComponent } from './components/nav-items/nav-items.component';
import { AppLayoutModule } from './components/app-layout/app-layout.module';
import { AppComponent } from './app.component';

import { ErrorComponent } from './shared/components/error/error.component';
import { SharedModule } from './shared/shared.module';
import { RolesExtendedModule } from './modules/roles-extended/roles-extended.module';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
      localizations: [
        {
          culture: 'tr',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: {
                UserDeletionConfirmation: '{0} adlı kullanıcı silinecek',
                Gender: 'Cinsiyet',
                BirthDate: 'Doğum Tarihi',
                IdentityNumber: 'Kimlik numarası',
                CustomerAlreadyExists: `Üzgünüm \'\{0}\'\ kimlik numarası zaten var`,
                RequiredInput: "Oops! Bu alan gerekli."
              },
            },
          ],
        },
        {
          culture: 'en',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: {
                UserDeletionConfirmation: '{0} will be delete',
                Gender: 'Gender',
                BirthDate: 'Birth Date',
                IdentityNumber: 'Identity number',
                CustomerAlreadyExists: `Sorry \'\{0}\'\ identity number already exists`,
                RequiredInput: "Oops! We need this input."
              }
            }
          ]
        }
      ]
    }),
    ThemeSharedModule.forRoot({
      validation: {
        blueprints: {
          uniqueIdentityNumber: "::CustomerAlreadyExists[{{ identityNumber }}]",
          required: "::RequiredInput",
        },
      },
    }),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    ThemeBasicModule.forRoot(),
    SharedModule,
    AppLayoutModule,
    RolesExtendedModule,
  ],
  declarations: [
    AppComponent,
    ConfigComponent,
    NavItemsComponent
  ],
  providers: [
    APP_ROUTE_PROVIDER,
    {
      provide: VALIDATION_ERROR_TEMPLATE,
      useValue: ErrorComponent,
    },
    // {
    //   provide: THEME_SHARED_APPEND_CONTENT,
    //   useFactory: () => () => { },
    // },
    // {
    //   provide: VALIDATION_TARGET_SELECTOR,
    //   useValue: '.form-group',
    // },
    // {
    //   provide: VALIDATION_INVALID_CLASSES,
    //   useValue: 'is-invalid',
    // },

    // {
    //   provide: PermissionService,
    //   useExisting: ExtendedPermissionService,
    // },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
