import { mapEnumToOptions } from '@abp/ng.core';

export enum Gender {
  Male = 0,
  Female = 1,
}

export const genderOptions = mapEnumToOptions(Gender);
