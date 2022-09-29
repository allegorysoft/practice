import { CreateFormPropContributorCallback, EditFormPropContributorCallback } from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../enums/components';
import { CustomerDto } from './customer';


export type CustomersCreateFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: CreateFormPropContributorCallback<CustomerDto>[];
}>;

export type CustomersEditFormPropContributors = Partial<{
    [eCustomersComponents.CustomerEdit]: EditFormPropContributorCallback<CustomerDto>[];
}>;

export interface CustomersConfigOptions {
    createFormPropContributors?: CustomersCreateFormPropContributors;
    editFormPropContributors?: CustomersEditFormPropContributors;
}
