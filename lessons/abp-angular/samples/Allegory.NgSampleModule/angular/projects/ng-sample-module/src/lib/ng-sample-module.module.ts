import {
  NgModule,
  NgModuleFactory,
  ModuleWithProviders,
} from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgSampleModuleComponent } from './components/ng-sample-module.component';
import { NgSampleModuleRoutingModule } from './ng-sample-module-routing.module';

@NgModule({
  declarations: [NgSampleModuleComponent],
  imports: [CoreModule, ThemeSharedModule, NgSampleModuleRoutingModule],
  exports: [NgSampleModuleComponent],
})
export class NgSampleModuleModule {
  static forChild(): ModuleWithProviders<NgSampleModuleModule> {
    return {
      ngModule: NgSampleModuleModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<NgSampleModuleModule> {
    return new LazyModuleFactory(NgSampleModuleModule.forChild());
  }
}
