import { ModuleWithProviders, NgModule } from '@angular/core';
import { STOCK_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class StockManagementConfigModule {
  static forRoot(): ModuleWithProviders<StockManagementConfigModule> {
    return {
      ngModule: StockManagementConfigModule,
      providers: [STOCK_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
