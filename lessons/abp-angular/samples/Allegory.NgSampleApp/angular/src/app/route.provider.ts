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
        order: 1,
        iconClass: 'pi-home',
        // iconClass: 'fas fa-home',
        layout: eLayoutType.application,
      },
      {
        path: '/config',
        name: 'Config',
        order: 2,
        iconClass: 'pi-cog',
        // iconClass: 'fa fa-gear',
        layout: eLayoutType.application,
      },
      {
        path: '/customers',
        name: 'Müşteriler',
        order: 3,
        requiredPolicy: 'NgSampleApp.Customers',
        iconClass: 'pi-users',
        // iconClass: 'fa fa-users',
        layout: eLayoutType.application,
      },
      {
        path: '/photos',
        name: 'Fotoğraflar',
        order: 4,
        iconClass: 'pi-images',
        layout: eLayoutType.application,
      }
    ]);
  };
}
