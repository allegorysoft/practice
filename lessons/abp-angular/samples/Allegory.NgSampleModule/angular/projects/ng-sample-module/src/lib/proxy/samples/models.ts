import { EntityDto, ExtensibleObject } from '@abp/ng.core';

export interface SampleDto {
  value: number;
}

export interface CustomerDto extends EntityDto<string> {
  name: string;
  salary: number;
  birthDate: string;
}

export interface CustomerCreateOrUpdateBase extends ExtensibleObject {
  name: string;
  salary: number;
  birthDate: string;
}
