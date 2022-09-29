import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgxValidateCoreModule } from '@ngx-validate/core';

import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { UiExtensionsModule } from '@abp/ng.theme.shared/extensions';

import { CustomersRoutingModule } from './customers-routing.module';

import { CustomersComponent } from './customers.component';
import { CustomerEditComponent } from './components/customer-edit/customer-edit.component';

import { CustomerExtensionsGuard } from './guards';
import { CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS, CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS } from './tokens';
import { CustomersConfigOptions } from './models';

@NgModule({
  declarations: [CustomersComponent, CustomerEditComponent],
  exports: [CustomersComponent, CustomerEditComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    CoreModule.forChild({
      localizations: [
        {
          culture: 'tr',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: {
                HelloMessage: '{0} dan Selam',
                CreateCustomer: 'Müşteri oluştur',
                EditCustomer: 'Müşteri düzenle'
              }
            }
          ]
        },
        {
          culture: 'en',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: {
                HelloMessage: 'Hello from {0}',
                CreateCustomer: 'Create customer',
                EditCustomer: 'Edit customer'
              }
            }
          ]
        }
      ]
    }),
    ThemeSharedModule,
    UiExtensionsModule,
    NgxValidateCoreModule
  ]
})
export class CustomersModule {
  static forChild(options: CustomersConfigOptions = {}): ModuleWithProviders<CustomersModule> {
    return {
      ngModule: CustomersModule,
      providers: [
        {
          provide: CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS,
          useValue: options.createFormPropContributors
        },
        {
          provide: CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS,
          useValue: options.editFormPropContributors
        },
        CustomerExtensionsGuard
      ]
    };
  }

  static forLazy(options: CustomersConfigOptions = {}): NgModuleFactory<CustomersModule> {
    return new LazyModuleFactory(CustomersModule.forChild(options));
  }
}
