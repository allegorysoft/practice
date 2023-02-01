import { NgModule } from '@angular/core';
import {
  PermissionGuard,
  ReplaceableComponents,
  ReplaceableRouteContainerComponent,
  RouterOutletComponent,
} from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { NgSampleModuleComponent } from './components/ng-sample-module.component';
import { eNgSampleModuleComponents } from './enums';

const routes: Routes = [
  {
    path: '',
    component: RouterOutletComponent,
    canActivate: [PermissionGuard],
    children: [
      {
        path: '',
        component: ReplaceableRouteContainerComponent,
        data: {
          // requiredPolicy: 'NgSampleModule',
          replaceableComponent: {
            key: eNgSampleModuleComponents.NgSampleModule,
            defaultComponent: NgSampleModuleComponent,
          } as ReplaceableComponents.RouteData<NgSampleModuleComponent>,
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NgSampleModuleRoutingModule {}
