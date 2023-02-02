import { EntityPropContributorCallback } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { eNgSampleModuleComponents } from '../enums';

export type NgSampleModuleEntityPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityPropContributorCallback<CustomerDto>[];
}>;

export interface NgSampleModuleConfigOptions {
  entityPropContributors?: NgSampleModuleEntityPropContributors;
}
