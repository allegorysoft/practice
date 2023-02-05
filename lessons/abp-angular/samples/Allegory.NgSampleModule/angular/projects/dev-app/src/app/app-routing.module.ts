import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  {
    path: 'home',
    loadChildren: () =>
      import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () =>
      import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m =>
        m.TenantManagementModule.forLazy()
      ),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m =>
        m.SettingManagementModule.forLazy()
      ),
  },
  {
    path: 'ng-sample-module',
    loadChildren: () =>
      import('@allegory/ng-sample-module').then(m =>
        m.NgSampleModuleModule.forLazy()
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
