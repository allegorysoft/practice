import type { EntityDto } from '@abp/ng.core';

export interface CustomerCreateDto {
  code: string;
  name?: string;
}

export interface CustomerDto extends EntityDto<string> {
  code?: string;
  name?: string;
}
