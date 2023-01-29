import { PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerEditComponent } from './components/customer-edit/customer-edit.component';
import { CustomersComponent } from './customers.component';
import { CustomerExtensionsGuard } from './guards';

const routes: Routes = [
  {
    path: '',
    component: CustomersComponent,
    canActivate: [PermissionGuard, CustomerExtensionsGuard],
    data: { requiredPolicy: 'NgSampleApp.Customers' }
  },
  {
    path: 'edit',
    component: CustomerEditComponent,
    canActivate: [PermissionGuard, CustomerExtensionsGuard],
    data: { requiredPolicy: 'NgSampleApp.Customers.Create' },
  },
  {
    path: 'edit/:id',
    component: CustomerEditComponent,
    canActivate: [PermissionGuard, CustomerExtensionsGuard],
    data: { requiredPolicy: 'NgSampleApp.Customers.Update' },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersRoutingModule { }
