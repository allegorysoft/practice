import type { CustomerCreateDto, CustomerDto, CustomerUpdateDto, CustomerWithDetailsDto, GetCustomerListDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiName = 'Module';

  create = (input: CustomerCreateDto) =>
    this.restService.request<any, CustomerWithDetailsDto>({
      method: 'POST',
      url: '/api/module/customers',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/module/customers/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CustomerWithDetailsDto>({
      method: 'GET',
      url: `/api/module/customers/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetCustomerListDto) =>
    this.restService.request<any, PagedResultDto<CustomerDto>>({
      method: 'GET',
      url: '/api/module/customers',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CustomerUpdateDto) =>
    this.restService.request<any, CustomerWithDetailsDto>({
      method: 'PUT',
      url: `/api/module/customers/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
