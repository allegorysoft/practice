import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { LazyModuleFactory } from '@abp/ng.core';
import { StockManagementRoutingModule } from './stock-management-routing.module';

@NgModule({
  imports: [StockManagementRoutingModule],
})
export class StockManagementModule {
  static forChild(): ModuleWithProviders<StockManagementModule> {
    return {
      ngModule: StockManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<StockManagementModule> {
    return new LazyModuleFactory(StockManagementModule.forChild());
  }
}
