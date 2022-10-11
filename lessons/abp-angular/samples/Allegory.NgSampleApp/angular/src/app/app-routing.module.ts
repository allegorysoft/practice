import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigComponent } from './config/config.component';
import {
  customersEntityPropContributors,
  customersCreateFormPropContributors
} from './contributors';
import {
  identityCreateFormPropContributors,
  identityEditFormPropContributors,
  identityEntityPropContributors
} from './identity/contributors';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy({
      createFormPropContributors: identityCreateFormPropContributors,
      editFormPropContributors: identityEditFormPropContributors,
      // entityPropContributors: identityEntityPropContributors
    })),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'config',
    component: ConfigComponent
  },
  {
    path: 'customers',
    loadChildren: () =>
      import('./customers/customers.module').then(m => m.CustomersModule.forLazy({
        createFormPropContributors: customersCreateFormPropContributors,
        // entityPropContributors: customersEntityPropContributors
      })),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule { }
