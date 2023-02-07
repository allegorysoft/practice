import {
  CreateFormPropContributorCallback,
  EditFormPropContributorCallback,
  EntityActionContributorCallback,
  EntityPropContributorCallback,
  ToolbarActionContributorCallback,
} from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { eNgSampleModuleComponents } from '../enums';

export type NgSampleModuleEntityActionContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityActionContributorCallback<CustomerDto>[];
}>;

export type NgSampleModuleToolbarActionContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: ToolbarActionContributorCallback<
    CustomerDto[]
  >[];
}>;

export type NgSampleModuleEntityPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityPropContributorCallback<CustomerDto>[];
}>;

export type NgSampleModuleCreateFormPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: CreateFormPropContributorCallback<CustomerDto>[];
}>;

export type NgSampleModuleEditFormPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EditFormPropContributorCallback<CustomerDto>[];
}>;

export interface NgSampleModuleConfigOptions {
  entityActionContributors?: NgSampleModuleEntityActionContributors;
  toolbarActionContributors?: NgSampleModuleToolbarActionContributors;
  entityPropContributors?: NgSampleModuleEntityPropContributors;
  createFormPropContributors?: NgSampleModuleCreateFormPropContributors;
  editFormPropContributors?: NgSampleModuleEditFormPropContributors;
}
