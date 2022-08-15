import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/config',
        name: 'Config',
        order: 2,
        iconClass: 'fa fa-gear',
        layout: eLayoutType.application,
      },
      // {
      //   path: '/customers',
      //   name: 'Müşteriler',
      //   // requiredPolicy: 'NgSampleApp.Customer',
      //   order: 3,
      //   layout: eLayoutType.application,
      //   iconClass: 'fa fa-users',
      // }
    ]);
  };
}
