import {
    CreateFormPropContributorCallback,
    EditFormPropContributorCallback,
    EntityActionContributorCallback,
    EntityPropContributorCallback
} from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../enums/components';
import { CustomerDto } from './customer';

export type CustomersEntityActionContributors = Partial<{
    [eCustomersComponents.Customers]: EntityActionContributorCallback<CustomerDto>[];
}>;

export type CustomersEntityPropContributors = Partial<{
    [eCustomersComponents.Customers]: EntityPropContributorCallback<CustomerDto>[];
}>;

export type CustomersCreateFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: CreateFormPropContributorCallback<CustomerDto>[];
}>;

export type CustomersEditFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: EditFormPropContributorCallback<CustomerDto>[];
}>;

export interface CustomersConfigOptions {
    entityActionContributors?: CustomersEntityActionContributors;
    entityPropContributors?: CustomersEntityPropContributors;
    createFormPropContributors?: CustomersCreateFormPropContributors;
    editFormPropContributors?: CustomersEditFormPropContributors;
}
