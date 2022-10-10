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
import {
  CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS,
  CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS,
  CUSTOMERS_ENTITY_ACTION_CONTRIBUTORS,
  CUSTOMERS_ENTITY_PROP_CONTRIBUTORS
} from './tokens';
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
                Customers: 'Müşteriler',
                HelloMessage: '{0} dan Selam',
                CreateCustomer: 'Müşteri oluştur',
                EditCustomer: 'Müşteri düzenle',
                Female: 'Kadın',
                Male: 'Erkek',
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
                Customers: 'Customers',
                HelloMessage: 'Hello from {0}',
                CreateCustomer: 'Create customer',
                EditCustomer: 'Edit customer',
                Female: 'Female',
                Male: 'Male',
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
          provide: CUSTOMERS_ENTITY_ACTION_CONTRIBUTORS,
          useValue: options.entityActionContributors,
        },
        {
          provide: CUSTOMERS_ENTITY_PROP_CONTRIBUTORS,
          useValue: options.entityPropContributors,
        },
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
