import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import {
  eNgSampleModuleRouteNames,
  eNgSampleModulePolicyNames,
} from '../enums';

export const NG_SAMPLE_MODULE_ROUTE_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureRoutes,
    deps: [RoutesService],
    multi: true,
  },
];

export function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/ng-sample-module',
        name: eNgSampleModuleRouteNames.NgSampleModule,
        // requiredPolicy: eNgSampleModulePolicyNames.NgSampleModule,
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        order: 3,
      },
    ]);
  };
}
