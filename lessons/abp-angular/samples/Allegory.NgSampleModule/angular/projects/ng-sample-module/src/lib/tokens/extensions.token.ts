import { InjectionToken } from '@angular/core';
import { EntityPropContributorCallback } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { eNgSampleModuleComponents } from '../enums';
import { DEFAULT_CUSTOMERS_ENTITY_PROPS } from '../defaults';

export const DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_ENTITY_PROPS,
};

export const NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS =
  new InjectionToken<EntityPropContributors>(
    'NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS'
  );

type EntityPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityPropContributorCallback<CustomerDto>[];
}>;
