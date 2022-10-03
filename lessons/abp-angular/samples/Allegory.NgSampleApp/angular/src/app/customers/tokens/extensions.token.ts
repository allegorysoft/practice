import { InjectionToken } from '@angular/core';
import {
    DEFAULT_CUSTOMERS_CREATE_FORM_PROPS, DEFAULT_CUSTOMERS_EDIT_FORM_PROPS
} from '../defaults/default-customers-form-props';
import {
    CreateFormPropContributorCallback, EditFormPropContributorCallback
} from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../enums/components';
import { CustomerDto } from '../models/customer';

export const DEFAULT_CUSTOMER_CREATE_FORM_PROPS = {
    [eCustomersComponents.CustomerEdit]: DEFAULT_CUSTOMERS_CREATE_FORM_PROPS,
};

export const DEFAULT_CUSTOMER_EDIT_FORM_PROPS = {
    [eCustomersComponents.CustomerEdit]: DEFAULT_CUSTOMERS_EDIT_FORM_PROPS,
};

export const CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS = new InjectionToken<CreateFormPropContributors>(
    'CUSTOMERS_CREATE_FORM_PROP_CONTRIBUTORS'
);

export const CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS = new InjectionToken<EditFormPropContributors>(
    'CUSTOMERS_EDIT_FORM_PROP_CONTRIBUTORS'
);

type CreateFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: CreateFormPropContributorCallback<CustomerDto>[];
}>;

type EditFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: EditFormPropContributorCallback<CustomerDto>[];
}>;
