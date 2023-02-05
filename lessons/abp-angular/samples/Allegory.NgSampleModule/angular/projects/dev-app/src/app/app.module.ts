import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AccountConfigModule } from '@abp/ng.account/config';
import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { AbpOAuthModule } from '@abp/ng.oauth';
import { FeatureManagementModule } from '@abp/ng.feature-management';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { ThemeBasicModule } from '@abp/ng.theme.basic';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgSampleModuleConfigModule } from '@allegory/ng-sample-module/config';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
      sendNullsAsQueryParam: false,
      skipGetAppConfiguration: false,
    }),
    AbpOAuthModule.forRoot(),
    ThemeSharedModule.forRoot(),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    NgSampleModuleConfigModule.forRoot(),
    ThemeBasicModule.forRoot(),
    FeatureManagementModule.forRoot(),
  ],
  providers: [APP_ROUTE_PROVIDER],
  declarations: [AppComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
