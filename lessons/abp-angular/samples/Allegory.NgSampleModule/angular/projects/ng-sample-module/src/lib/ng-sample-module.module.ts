import {
  NgModule,
  NgModuleFactory,
  ModuleWithProviders,
} from '@angular/core';
import {
  NgbDropdownModule,
  NgbNavModule,
} from '@ng-bootstrap/ng-bootstrap';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { UiExtensionsModule } from '@abp/ng.theme.shared/extensions';

import { NgSampleModuleRoutingModule } from './ng-sample-module-routing.module';

import { NgSampleModuleComponent } from './components';
import { NgSampleModuleExtensionsGuard } from './guards';
import { NgSampleModuleConfigOptions } from './models';
import {
  NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS,
  NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS,
} from './tokens';

@NgModule({
  declarations: [NgSampleModuleComponent],
  imports: [
    NgbNavModule,
    NgbDropdownModule,
    CoreModule,
    ThemeSharedModule,
    UiExtensionsModule,
    NgSampleModuleRoutingModule,
  ],
  exports: [NgSampleModuleComponent],
})
export class NgSampleModuleModule {
  static forChild(
    options: NgSampleModuleConfigOptions = {}
  ): ModuleWithProviders<NgSampleModuleModule> {
    return {
      ngModule: NgSampleModuleModule,
      providers: [
        {
          provide: NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS,
          useValue: options.entityPropContributors,
        },
        {
          provide: NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS,
          useValue: options.entityActionContributors,
        },
        NgSampleModuleExtensionsGuard,
      ],
    };
  }

  static forLazy(): NgModuleFactory<NgSampleModuleModule> {
    return new LazyModuleFactory(NgSampleModuleModule.forChild());
  }
}
