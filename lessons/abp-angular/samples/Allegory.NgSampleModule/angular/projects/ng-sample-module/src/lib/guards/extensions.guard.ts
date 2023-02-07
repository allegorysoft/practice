import { inject, Injectable, Injector } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { ConfigStateService } from '@abp/ng.core';
import {
  ExtensionsService,
  getObjectExtensionEntitiesFromStore,
  mapEntitiesToContributors,
  mergeWithDefaultActions,
  mergeWithDefaultProps,
} from '@abp/ng.theme.shared/extensions';
import { eNgSampleModuleComponents } from '../enums';
import {
  NgSampleModuleEntityActionContributors,
  NgSampleModuleEntityPropContributors,
  NgSampleModuleToolbarActionContributors,
  NgSampleModuleCreateFormPropContributors,
  NgSampleModuleEditFormPropContributors,
} from '../models';
import {
  DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS,
  DEFAULT_NG_SAMPLE_MODULE_ENTITY_ACTIONS,
  DEFAULT_NG_SAMPLE_MODULE_TOOLBAR_ACTIONS,
  DEFAULT_NG_SAMPLE_MODULE_CREATE_FORM_PROPS,
  DEFAULT_NG_SAMPLE_MODULE_EDIT_FORM_PROPS,
  NG_SAMPLE_MODULE_TOOLBAR_ACTION_CONTRIBUTORS,
  NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS,
  NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS,
  NG_SAMPLE_MODULE_CREATE_FORM_PROP_CONTRIBUTORS,
  NG_SAMPLE_MODULE_EDIT_FORM_PROP_CONTRIBUTORS,
} from '../tokens';

@Injectable()
export class NgSampleModuleExtensionsGuard implements CanActivate {
  private readonly injector = inject(Injector);

  canActivate(): Observable<boolean> {
    const configState = this.injector.get(ConfigStateService);
    const extensions = this.injector.get(ExtensionsService);

    const actionContributors: NgSampleModuleEntityActionContributors =
      this.injector.get(
        NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS,
        null
      ) || {};

    const toolbarContributors: NgSampleModuleToolbarActionContributors =
      this.injector.get(
        NG_SAMPLE_MODULE_TOOLBAR_ACTION_CONTRIBUTORS,
        null
      ) || {};

    const propContributors: NgSampleModuleEntityPropContributors =
      this.injector.get(NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS, null) ||
      {};

    const createFormContributors: NgSampleModuleCreateFormPropContributors =
      this.injector.get(
        NG_SAMPLE_MODULE_CREATE_FORM_PROP_CONTRIBUTORS,
        null
      ) || {};

    const editFormContributors: NgSampleModuleEditFormPropContributors =
      this.injector.get(
        NG_SAMPLE_MODULE_EDIT_FORM_PROP_CONTRIBUTORS,
        null
      ) || {};

    return getObjectExtensionEntitiesFromStore(
      configState,
      'NgSampleModule'
    ).pipe(
      map(entities => ({
        [eNgSampleModuleComponents.NgSampleModule]: entities.Customers,
      })),
      mapEntitiesToContributors(configState, 'NgSampleModule'),
      tap(objectExtensionContributors => {
        mergeWithDefaultActions(
          extensions.entityActions,
          DEFAULT_NG_SAMPLE_MODULE_ENTITY_ACTIONS,
          actionContributors
        );
        mergeWithDefaultActions(
          extensions.toolbarActions,
          DEFAULT_NG_SAMPLE_MODULE_TOOLBAR_ACTIONS,
          toolbarContributors
        );
        mergeWithDefaultProps(
          extensions.entityProps,
          DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS,
          objectExtensionContributors.prop,
          propContributors
        );
        mergeWithDefaultProps(
          extensions.createFormProps, //ExtensionsService de ki hangi listeye ekleneceğini belirtiyor
          DEFAULT_NG_SAMPLE_MODULE_CREATE_FORM_PROPS, //Varsayılan form prop'ları
          // objectExtensionContributors.createForm,//Global state'de ki objectExtensions properties'inden gelen değerler
          createFormContributors //forLazy metodu ile dışarıdan eklenen proplar
        );
        mergeWithDefaultProps(
          extensions.editFormProps, //ExtensionsService de ki hangi listeye ekleneceğini belirtiyor
          DEFAULT_NG_SAMPLE_MODULE_EDIT_FORM_PROPS, //Varsayılan form prop'ları
          // objectExtensionContributors.editForm,//Global state'de ki objectExtensions properties'inden gelen değerler
          editFormContributors //forLazy metodu ile dışarıdan eklenen proplar
        );
      }),
      map(() => true)
    );
  }
}
