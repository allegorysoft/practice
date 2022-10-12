import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CustomersModule } from '../customers/customers.module';

import { CustomersExtendedComponent } from './customers-extended.component';
import {
  customersEntityActionContributors,
  customersCreateFormPropContributors,
  customersEntityPropContributors,
  customersToolbarActionContributors
} from './contributors';

@NgModule({
  imports: [
    CoreModule,
    ThemeSharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: CustomersExtendedComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              CustomersModule.forLazy({
                // entityActionContributors: customersEntityActionContributors,
                createFormPropContributors: customersCreateFormPropContributors,
                // entityPropContributors: customersEntityPropContributors,
                // toolbarActionContributors: customersToolbarActionContributors
              }),
          },
        ]
      }
    ])
  ],
  declarations: [CustomersExtendedComponent]
})
export class CustomersExtendedModule { }
