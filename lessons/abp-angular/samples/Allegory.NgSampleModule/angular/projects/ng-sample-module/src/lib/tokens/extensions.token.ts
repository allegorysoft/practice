import { InjectionToken } from '@angular/core';
import {
  EntityActionContributorCallback,
  EntityPropContributorCallback,
} from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { eNgSampleModuleComponents } from '../enums';
import {
  DEFAULT_CUSTOMERS_ENTITY_PROPS,
  DEFAULT_CUSTOMERS_ENTITY_ACTIONS,
} from '../defaults';

//#region Default Consts
export const DEFAULT_NG_SAMPLE_MODULE_ENTITY_ACTIONS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_ENTITY_ACTIONS,
};

export const DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_ENTITY_PROPS,
};
//#endregion

//#region InjectionTokens
export const NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS =
  new InjectionToken<EntityActionContributors>(
    'NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS'
  );

export const NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS =
  new InjectionToken<EntityPropContributors>(
    'NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS'
  );
//#endregion

//#region type Contributors
type EntityActionContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityActionContributorCallback<CustomerDto>[];
}>;

type EntityPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityPropContributorCallback<CustomerDto>[];
}>;
//#endregion
