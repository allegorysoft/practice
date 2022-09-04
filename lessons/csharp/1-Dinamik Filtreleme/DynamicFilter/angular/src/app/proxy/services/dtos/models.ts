import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { Condition } from '@allegorysoft/filter';
import type { Gender } from '../../entities/gender.enum';

export interface FilteredPagedAndSortedResultRequestDto extends PagedAndSortedResultRequestDto {
  conditions: Condition;
}

export interface PersonDto extends EntityDto<string> {
  name?: string;
  surname?: string;
  birthDate?: string;
  gender: Gender;
  balance: number;
}
