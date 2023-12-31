import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetProductsInput extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface ProductCreateUpdateDto {
  code: string;
  name?: string;
}

export interface ProductDto extends EntityDto<string> {
  code?: string;
  name?: string;
}
