import type { EntityDto, ExtensibleEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ContactInformationType } from './contact-information-type.enum';

export interface AddressDto extends EntityDto {
  country: string;
  city: string;
  town: string;
  line1: string;
  line2: string;
}

export interface ContactInformationCreateUpdateDto extends EntityDto {
  name: string;
  type: ContactInformationType;
  value: string;
}

export interface ContactInformationDto extends EntityDto {
  name?: string;
  type: ContactInformationType;
  value?: string;
}

export interface CustomerCreateDto extends CustomerCreateOrUpdateDtoBase {
}

export interface CustomerCreateOrUpdateDtoBase extends ExtensibleEntityDto {
  name: string;
  surname: string;
  customerGroupCode?: string;
  contactInformations: ContactInformationCreateUpdateDto[];
  address: AddressDto;
}

export interface CustomerDto extends EntityDto<string> {
  name?: string;
  surname?: string;
}

export interface CustomerGroupCreateUpdateDto extends ExtensibleEntityDto {
  code: string;
  description?: string;
}

export interface CustomerGroupDto extends ExtensibleEntityDto<string> {
  code?: string;
  description?: string;
}

export interface CustomerUpdateDto extends CustomerCreateOrUpdateDtoBase {
}

export interface CustomerWithDetailsDto extends ExtensibleEntityDto<string> {
  name?: string;
  surname?: string;
  customerGroupCode?: string;
  contactInformations: ContactInformationDto[];
  address: AddressDto;
}

export interface GetCustomerListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}
