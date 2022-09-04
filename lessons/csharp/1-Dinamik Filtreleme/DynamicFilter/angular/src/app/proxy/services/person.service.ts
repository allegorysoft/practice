import type { FilteredPagedAndSortedResultRequestDto, PersonDto } from './dtos/models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  apiName = 'Default';

  listByInput = (input: FilteredPagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<PersonDto>>({
      method: 'POST',
      url: '/api/app/person/list',
      body: input,
    },
      { apiName: this.apiName });

  listWithRawSqlByInput = (input: FilteredPagedAndSortedResultRequestDto) =>
    this.restService.request<any, ListResultDto<PersonDto>>({
      method: 'POST',
      url: '/api/app/person/list-with-raw-sql',
      body: input,
    },
      { apiName: this.apiName });

  constructor(private restService: RestService) { }
}
