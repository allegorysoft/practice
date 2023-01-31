import { ModuleWithProviders, NgModule } from '@angular/core';
import { NG_SAMPLE_MODULE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class NgSampleModuleConfigModule {
  static forRoot(): ModuleWithProviders<NgSampleModuleConfigModule> {
    return {
      ngModule: NgSampleModuleConfigModule,
      providers: [NG_SAMPLE_MODULE_ROUTE_PROVIDERS],
    };
  }
}
