import {
    CreateFormPropContributorCallback,
    EditFormPropContributorCallback,
    EntityActionContributorCallback,
    EntityPropContributorCallback,
    ToolbarActionContributorCallback
} from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../enums/components';
import { CustomerDto } from './customer';

export type CustomersEntityActionContributors = Partial<{
    [eCustomersComponents.Customers]: EntityActionContributorCallback<CustomerDto>[];
}>;

export type CustomersToolbarActionContributors = Partial<{
    [eCustomersComponents.Customers]: ToolbarActionContributorCallback<CustomerDto[]>[];
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
    toolbarActionContributors?: CustomersToolbarActionContributors;
    entityPropContributors?: CustomersEntityPropContributors;
    createFormPropContributors?: CustomersCreateFormPropContributors;
    editFormPropContributors?: CustomersEditFormPropContributors;
}
