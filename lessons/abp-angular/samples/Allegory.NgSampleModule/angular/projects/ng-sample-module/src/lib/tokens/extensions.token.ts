import { InjectionToken } from '@angular/core';
import {
  CreateFormPropContributorCallback,
  EditFormPropContributorCallback,
  EntityActionContributorCallback,
  EntityPropContributorCallback,
  ToolbarActionContributorCallback,
} from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { eNgSampleModuleComponents } from '../enums';
import {
  DEFAULT_CUSTOMERS_ENTITY_PROPS,
  DEFAULT_CUSTOMERS_ENTITY_ACTIONS,
  DEFAULT_CUSTOMERS_TOOLBAR_ACTIONS,
  DEFAULT_CUSTOMERS_CREATE_FORM_PROPS,
  DEFAULT_CUSTOMERS_EDIT_FORM_PROPS,
} from '../defaults';

//#region Default Consts
export const DEFAULT_NG_SAMPLE_MODULE_ENTITY_ACTIONS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_ENTITY_ACTIONS,
};

export const DEFAULT_NG_SAMPLE_MODULE_TOOLBAR_ACTIONS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_TOOLBAR_ACTIONS,
};

export const DEFAULT_NG_SAMPLE_MODULE_ENTITY_PROPS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_ENTITY_PROPS,
};

export const DEFAULT_NG_SAMPLE_MODULE_CREATE_FORM_PROPS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_CREATE_FORM_PROPS,
};

export const DEFAULT_NG_SAMPLE_MODULE_EDIT_FORM_PROPS = {
  [eNgSampleModuleComponents.NgSampleModule]:
    DEFAULT_CUSTOMERS_EDIT_FORM_PROPS,
};
//#endregion

//#region InjectionTokens
export const NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS =
  new InjectionToken<EntityActionContributors>(
    'NG_SAMPLE_MODULE_ENTITY_ACTION_CONTRIBUTORS'
  );

export const NG_SAMPLE_MODULE_TOOLBAR_ACTION_CONTRIBUTORS =
  new InjectionToken<ToolbarActionContributors>(
    'NG_SAMPLE_MODULE_TOOLBAR_ACTION_CONTRIBUTORS'
  );

export const NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS =
  new InjectionToken<EntityPropContributors>(
    'NG_SAMPLE_MODULE_ENTITY_PROP_CONTRIBUTORS'
  );

export const NG_SAMPLE_MODULE_CREATE_FORM_PROP_CONTRIBUTORS =
  new InjectionToken<CreateFormPropContributors>(
    'NG_SAMPLE_MODULE_CREATE_FORM_PROP_CONTRIBUTORS'
  );

export const NG_SAMPLE_MODULE_EDIT_FORM_PROP_CONTRIBUTORS =
  new InjectionToken<EditFormPropContributors>(
    'NG_SAMPLE_MODULE_EDIT_FORM_PROP_CONTRIBUTORS'
  );

//#endregion

//#region type Contributors
type EntityActionContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityActionContributorCallback<CustomerDto>[];
}>;

type ToolbarActionContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: ToolbarActionContributorCallback<
    CustomerDto[]
  >[];
}>;

type EntityPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EntityPropContributorCallback<CustomerDto>[];
}>;

type CreateFormPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: CreateFormPropContributorCallback<CustomerDto>[];
}>;

type EditFormPropContributors = Partial<{
  [eNgSampleModuleComponents.NgSampleModule]: EditFormPropContributorCallback<CustomerDto>[];
}>;
//#endregion
