import { InjectionToken } from '@angular/core';
import {
    CreateFormPropContributorCallback,
    EditFormPropContributorCallback,
    EntityActionContributorCallback,
    EntityPropContributorCallback,
    ToolbarActionContributorCallback
} from '@abp/ng.theme.shared/extensions';

import { CustomerDto } from '../models/customer';
import { eCustomersComponents } from '../enums/components';
import {
    DEFAULT_CUSTOMERS_CREATE_FORM_PROPS,
    DEFAULT_CUSTOMERS_EDIT_FORM_PROPS,
    DEFAULT_CUSTOMERS_ENTITY_ACTIONS,
    DEFAULT_CUSTOMERS_ENTITY_PROPS,
    DEFAULT_CUSTOMERS_TOOLBAR_ACTIONS
} from '../defaults';


//#region Default Consts
export const DEFAULT_CUSTOMER_ENTITY_ACTIONS = {
    [eCustomersComponents.Customers]: DEFAULT_CUSTOMERS_ENTITY_ACTIONS,
};

export const DEFAULT_CUSTOMER_TOOLBAR_ACTIONS = {
    [eCustomersComponents.Customers]: DEFAULT_CUSTOMERS_TOOLBAR_ACTIONS,
};

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
export const CUSTOMERS_ENTITY_ACTION_CONTRIBUTORS = new InjectionToken<EntityActionContributors>(
    'CUSTOMERS_ENTITY_ACTION_CONTRIBUTORS',
);

export const CUSTOMERS_TOOLBAR_ACTION_CONTRIBUTORS = new InjectionToken<ToolbarActionContributors>(
    'CUSTOMERS_TOOLBAR_ACTION_CONTRIBUTORS',
);

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
type EntityActionContributors = Partial<{
    [eCustomersComponents.Customers]: EntityActionContributorCallback<CustomerDto>[];
}>;

type ToolbarActionContributors = Partial<{
    [eCustomersComponents.Customers]: ToolbarActionContributorCallback<CustomerDto[]>[];
}>;

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
