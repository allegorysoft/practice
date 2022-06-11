import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ModuleComponent } from './components/module.component';
import { ModuleRoutingModule } from './module-routing.module';

@NgModule({
  declarations: [ModuleComponent],
  imports: [CoreModule, ThemeSharedModule, ModuleRoutingModule],
  exports: [ModuleComponent],
})
export class ModuleModule {
  static forChild(): ModuleWithProviders<ModuleModule> {
    return {
      ngModule: ModuleModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ModuleModule> {
    return new LazyModuleFactory(ModuleModule.forChild());
  }
}
