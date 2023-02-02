import { inject, Injectable, Injector } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { ConfigStateService } from '@abp/ng.core';
import {
  ExtensionsService,
  getObjectExtensionEntitiesFromStore,
  mapEntitiesToContributors,
  mergeWithDefaultProps,
} from '@abp/ng.theme.shared/extensions';
import { eNgSampleModuleComponents } from '../enums';
import { NgSampleModuleEntityPropContributors } from '../models';
import { DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS } from '../tokens';

@Injectable()
export class NgSampleModuleExtensionsGuard implements CanActivate {
  private readonly injector = inject(Injector);

  canActivate(): Observable<boolean> {
    const configState = this.injector.get(ConfigStateService);
    const extensions = this.injector.get(ExtensionsService);

    const propContributors: NgSampleModuleEntityPropContributors =
      this.injector.get(DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS, null) || {};

    return getObjectExtensionEntitiesFromStore(
      configState,
      'NgSampleModule'
    ).pipe(
      map(entities => ({
        [eNgSampleModuleComponents.NgSampleModule]: entities.Customers,
      })),
      mapEntitiesToContributors(configState, 'NgSampleModule'),
      tap(objectExtensionContributors => {
        mergeWithDefaultProps(
          extensions.entityProps,
          DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS,
          objectExtensionContributors.prop,
          propContributors
        );
      }),
      map(() => true)
    );
  }
}
