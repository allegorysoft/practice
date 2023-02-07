import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  PermissionGuard,
  ReplaceableComponents,
  ReplaceableRouteContainerComponent,
  RouterOutletComponent,
} from '@abp/ng.core';
import { NgSampleModuleExtensionsGuard } from './guards';
import { eNgSampleModuleComponents } from './enums';
import { NgSampleModuleComponent } from './components';

const routes: Routes = [
  {
    path: '',
    component: RouterOutletComponent,
    canActivate: [PermissionGuard, NgSampleModuleExtensionsGuard],
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
