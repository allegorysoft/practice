import { ConfigStateService, ExtensionPropertyDto } from '@abp/ng.core';
import { ExtensionsService, getObjectExtensionEntitiesFromStore, mapEntitiesToContributors, mergeWithDefaultProps } from '@abp/ng.theme.shared/extensions';
import { Injectable, Injector } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable, of, pipe } from 'rxjs';
import { map, mapTo, switchMap, tap } from 'rxjs/operators';
import { eCustomersComponents } from '../enums';
import { CustomersCreateFormPropContributors, CustomersEditFormPropContributors } from '../models';
import { CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS } from '../tokens';

import { CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS, DEFAULT_CUSTOMER_CREATE_FORM_PROPS, DEFAULT_CUSTOMER_EDIT_FORM_PROPS } from '../tokens/extensions.token';

@Injectable()
export class CustomerExtensionsGuard implements CanActivate {
  constructor(private injector: Injector) { }

  canActivate(): Observable<boolean> {
    const extensions = this.injector.get(ExtensionsService);

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

