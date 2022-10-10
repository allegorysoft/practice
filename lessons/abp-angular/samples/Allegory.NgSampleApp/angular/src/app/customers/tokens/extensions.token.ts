import { InjectionToken } from '@angular/core';
import {
    DEFAULT_CUSTOMERS_CREATE_FORM_PROPS, DEFAULT_CUSTOMERS_EDIT_FORM_PROPS
} from '../defaults/default-customers-form-props';
import {
    CreateFormPropContributorCallback, EditFormPropContributorCallback, EntityPropContributorCallback
} from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../enums/components';
import { CustomerDto } from '../models/customer';
import { DEFAULT_CUSTOMERS_ENTITY_PROPS } from '../defaults/default-users-entity-props';


//#region DEFAULT consts
export const DEFAULT_CUSTOMER_ENTITY_PROPS = {
    [eCustomersComponents.Customers]: DEFAULT_CUSTOMERS_ENTITY_PROPS,
};
export const DEFAULT_CUSTOMER_CREATE_FORM_PROPS = {
    [eCustomersComponents.CustomerEdit]: DEFAULT_CUSTOMERS_CREATE_FORM_PROPS,
};

export const DEFAULT_CUSTOMER_EDIT_FORM_PROPS = {
    [eCustomersComponents.CustomerEdit]: DEFAULT_CUSTOMERS_EDIT_FORM_PROPS,
};
//#endregion


//#region InjectionTokens
export const CUSTOMERS_ENTITY_PROP_CONTRIBUTORS = new InjectionToken<EntityPropContributors>(
    'CUSTOMERS_ENTITY_PROP_CONTRIBUTORS',
);

export const CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS = new InjectionToken<CreateFormPropContributors>(
    'CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS'
);

export const CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS = new InjectionToken<EditFormPropContributors>(
    'CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS'
);
//#endregion


//#region type Contributors
type EntityPropContributors = Partial<{
    [eCustomersComponents.Customers]: EntityPropContributorCallback<CustomerDto>[];
}>;

type CreateFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: CreateFormPropContributorCallback<CustomerDto>[];
}>;

type EditFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: EditFormPropContributorCallback<CustomerDto>[];
}>;
//#endregion
