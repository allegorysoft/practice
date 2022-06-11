import { ModuleWithProviders, NgModule } from '@angular/core';
import { MODULE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ModuleConfigModule {
  static forRoot(): ModuleWithProviders<ModuleConfigModule> {
    return {
      ngModule: ModuleConfigModule,
      providers: [MODULE_ROUTE_PROVIDERS],
    };
  }
}
