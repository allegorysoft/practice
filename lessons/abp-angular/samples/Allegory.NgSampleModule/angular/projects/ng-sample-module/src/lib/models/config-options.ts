import {
  EntityActionContributorCallback,
  EntityPropContributorCallback,
} from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { eNgSampleModuleComponents } from '../enums';

export type NgSampleModuleEntityActionContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityActionContributorCallback<CustomerDto>[];
}>;

export type NgSampleModuleEntityPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityPropContributorCallback<CustomerDto>[];
}>;

export interface NgSampleModuleConfigOptions {
  entityActionContributors?: NgSampleModuleEntityActionContributors;
  entityPropContributors?: NgSampleModuleEntityPropContributors;
}
