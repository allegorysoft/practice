import { Injectable, Injector } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { map, mapTo, tap } from 'rxjs/operators';

import { ConfigStateService } from '@abp/ng.core';
import {
  ExtensionsService,
  getObjectExtensionEntitiesFromStore,
  mapEntitiesToContributors,
  mergeWithDefaultActions,
  mergeWithDefaultProps
} from '@abp/ng.theme.shared/extensions';

import { eCustomersComponents } from '../enums';

import {
  CustomersCreateFormPropContributors,
  CustomersEditFormPropContributors,
  CustomersEntityActionContributors,
  CustomersEntityPropContributors,
  CustomersToolbarActionContributors
} from '../models';
import {
  CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS,
  CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS,
  CUSTOMERS_ENTITY_ACTION_CONTRIBUTORS,
  CUSTOMERS_ENTITY_PROP_CONTRIBUTORS,
  CUSTOMERS_TOOLBAR_ACTION_CONTRIBUTORS,
  DEFAULT_CUSTOMER_CREATE_FORM_PROPS,
  DEFAULT_CUSTOMER_EDIT_FORM_PROPS,
  DEFAULT_CUSTOMER_ENTITY_ACTIONS,
  DEFAULT_CUSTOMER_ENTITY_PROPS,
  DEFAULT_CUSTOMER_TOOLBAR_ACTIONS
} from '../tokens';

@Injectable()
export class CustomerExtensionsGuard implements CanActivate {
  constructor(private injector: Injector) { }

  canActivate(): Observable<boolean> {
    const extensions = this.injector.get(ExtensionsService);
    
    const actionContributors: CustomersEntityActionContributors =
      this.injector.get(CUSTOMERS_ENTITY_ACTION_CONTRIBUTORS, null) || {};

    const propContributors: CustomersEntityPropContributors =
      this.injector.get(CUSTOMERS_ENTITY_PROP_CONTRIBUTORS, null) || {};

    const toolbarContributors: CustomersToolbarActionContributors =
      this.injector.get(CUSTOMERS_TOOLBAR_ACTION_CONTRIBUTORS, null) || {};

    const createFormContributors: CustomersCreateFormPropContributors =
      this.injector.get(CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS, null) || {};

    const editFormContributors: CustomersEditFormPropContributors =
      this.injector.get(CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS, null) || {};

    const configState = this.injector.get(ConfigStateService);

    return getObjectExtensionEntitiesFromStore(configState, 'NgSampleApp').pipe(
      map(entities => ({
        [eCustomersComponents.CustomerEdit]: entities.Customer
      })),
      mapEntitiesToContributors(configState, 'NgSampleApp'),
      tap(objectExtensionContributors => {
        mergeWithDefaultActions(
          extensions.entityActions,
          DEFAULT_CUSTOMER_ENTITY_ACTIONS,
          actionContributors,
        );
        mergeWithDefaultActions(
          extensions.toolbarActions,
          DEFAULT_CUSTOMER_TOOLBAR_ACTIONS,
          toolbarContributors,
        );
        mergeWithDefaultProps(
          extensions.entityProps,
          DEFAULT_CUSTOMER_ENTITY_PROPS,
          // objectExtensionContributors.createForm,//Global state'de ki objectExtensions properties'inden gelen değerler
          propContributors,
        );
        mergeWithDefaultProps(
          extensions.createFormProps,//ExtensionsService de ki hangi listeye ekleneceğini belirtiyor
          DEFAULT_CUSTOMER_CREATE_FORM_PROPS,//Varsayılan form prop'ları
          // objectExtensionContributors.createForm,//Global state'de ki objectExtensions properties'inden gelen değerler
          createFormContributors,//forLazy metodu ile dışarıdan eklenen proplar
        );
        mergeWithDefaultProps(
          extensions.editFormProps,//ExtensionsService de ki hangi listeye ekleneceğini belirtiyor
          DEFAULT_CUSTOMER_EDIT_FORM_PROPS,//Varsayılan form prop'ları
          // objectExtensionContributors.editForm,//Global state'de ki objectExtensions properties'inden gelen değerler
          editFormContributors,//forLazy metodu ile dışarıdan eklenen proplar
        );
      }),
      mapTo(true)
    );
  }
}
