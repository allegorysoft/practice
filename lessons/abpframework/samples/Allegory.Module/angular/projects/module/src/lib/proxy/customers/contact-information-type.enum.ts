import { mapEnumToOptions } from '@abp/ng.core';

export enum ContactInformationType {
  Phone = 0,
  Email = 1,
  Other = 2,
}

export const contactInformationTypeOptions = mapEnumToOptions(ContactInformationType);
