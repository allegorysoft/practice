import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';

const routes: Route[] = [
  { path: '', pathMatch: 'full', redirectTo: 'manuel-validation' },
  {
    path: 'manuel-validation',
    loadComponent: () => import('./features/orders/orders.component'),
  },
  {
    path: 'ngx-validate',
    loadComponent: () => import('./features/products/products.component'),
  },
  {
    path: 'ngx-validate-2',
    loadComponent: () => import('./features/customers/customers.component'),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
