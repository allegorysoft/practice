import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eStockManagementRouteNames, eStockManagementPolicyNames } from '../enums';

export const STOCK_MANAGEMENT_ROUTE_PROVIDERS = [
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
        path: undefined,
        name: eStockManagementRouteNames.StockManagement,
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        order: 3,
      },
      {
        path: '/stock-management/products',
        name: eStockManagementRouteNames.Products,
        parentName: eStockManagementRouteNames.StockManagement,
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        order: 1,
        requiredPolicy: eStockManagementPolicyNames.Products,
      },
    ]);
  };
}
