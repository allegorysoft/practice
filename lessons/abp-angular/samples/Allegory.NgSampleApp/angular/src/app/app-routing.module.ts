import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigComponent } from './components/config/config.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account')
      .then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('./modules/identity-extended/identity-extended.module')
      .then(m => m.IdentityExtendedModule),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management')
        .then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management')
        .then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'config',
    component: ConfigComponent
  },
  {
    path: 'customers',
    loadChildren: () => import('./modules/customers-extended/customers-extended.module')
      .then(m => m.CustomersExtendedModule),
  },
  {
    path: 'photos',
    loadChildren: () => import('./modules/photos/photos.module')
      .then(m => m.PhotosModule),
  },
  {
    path: 'theme',
    loadChildren: () => import('./modules/theme/theme.module').then(m => m.ThemeModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
