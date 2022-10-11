import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CustomersModule } from '../customers/customers.module';

import { CustomersExtendedComponent } from './customers-extended.component';
import {
  customersCreateFormPropContributors,
  customersEntityPropContributors
} from './contributors';
import { customersEntityActionContributors } from './contributors/entity-action-contributors';

@NgModule({
  imports: [
    CoreModule.forChild(),
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
                createFormPropContributors: customersCreateFormPropContributors,
                // entityPropContributors: customersEntityPropContributors,
                // entityActionContributors: customersEntityActionContributors,
              }),
          },
        ]
      }
    ])
  ],
  declarations: [CustomersExtendedComponent]
})
export class CustomersExtendedModule { }
