import { AccountConfigModule } from '@abp/ng.account/config';
import { CoreModule, PermissionService } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { ThemeBasicModule } from '@abp/ng.theme.basic';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';

import { ConfigComponent } from './config/config.component';
import { ExtendedPermissionService } from './services/extended-permission.service';
import { VALIDATION_ERROR_TEMPLATE } from '@ngx-validate/core';
import { ErrorComponent } from './shared/components/error/error.component';

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
  ],
  declarations: [AppComponent, ConfigComponent],
  providers: [
    APP_ROUTE_PROVIDER,
    {
      provide: VALIDATION_ERROR_TEMPLATE,
      useValue: ErrorComponent,
    }
    // {
    //   provide: PermissionService,
    //   useExisting: ExtendedPermissionService,
    // },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
