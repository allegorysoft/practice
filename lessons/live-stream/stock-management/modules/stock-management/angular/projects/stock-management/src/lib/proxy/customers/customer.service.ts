import type { CustomerCreateDto, CustomerDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiName = 'StockManagement';

  create = (input: CustomerCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerDto>(
      {
        method: 'POST',
        url: '/api/stock-management/customers',
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerDto>(
      {
        method: 'GET',
        url: `/api/stock-management/customers/${id}`,
      },
      { apiName: this.apiName, ...config }
    );

  getByCode = (code: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerDto>(
      {
        method: 'GET',
        url: `/api/stock-management/customers/${code}`,
      },
      { apiName: this.apiName, ...config }
    );

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerDto[]>(
      {
        method: 'GET',
        url: '/api/stock-management/customers',
      },
      { apiName: this.apiName, ...config }
    );

  constructor(private restService: RestService) {}
}
