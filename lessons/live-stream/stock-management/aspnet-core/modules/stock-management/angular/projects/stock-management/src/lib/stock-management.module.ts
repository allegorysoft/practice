import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { StockManagementComponent } from './components/stock-management.component';
import { StockManagementRoutingModule } from './stock-management-routing.module';

@NgModule({
  declarations: [StockManagementComponent],
  imports: [CoreModule, ThemeSharedModule, StockManagementRoutingModule],
  exports: [StockManagementComponent],
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
