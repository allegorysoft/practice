import type { SampleDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SampleService {
  apiName = 'Module';

  get = () =>
    this.restService.request<any, SampleDto>({
      method: 'GET',
      url: '/api/Module/sample',
    },
    { apiName: this.apiName });

  getAuthorized = () =>
    this.restService.request<any, SampleDto>({
      method: 'GET',
      url: '/api/Module/sample/authorized',
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
