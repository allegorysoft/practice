import type { CustomerGroupCreateUpdateDto, CustomerGroupDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomerGroupService {
  apiName = 'Module';

  create = (input: CustomerGroupCreateUpdateDto) =>
    this.restService.request<any, CustomerGroupDto>({
      method: 'POST',
      url: '/api/module/customer-groups',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/module/customer-groups/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CustomerGroupDto>({
      method: 'GET',
      url: `/api/module/customer-groups/${id}`,
    },
    { apiName: this.apiName });

  getByCode = (code: string) =>
    this.restService.request<any, CustomerGroupDto>({
      method: 'GET',
      url: '/api/module/customer-groups/by-code',
      params: { code },
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CustomerGroupDto>>({
      method: 'GET',
      url: '/api/module/customer-groups',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CustomerGroupCreateUpdateDto) =>
    this.restService.request<any, CustomerGroupDto>({
      method: 'PUT',
      url: `/api/module/customer-groups/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
