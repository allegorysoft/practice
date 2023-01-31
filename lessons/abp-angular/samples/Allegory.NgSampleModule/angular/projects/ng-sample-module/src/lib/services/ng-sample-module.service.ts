import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class NgSampleModuleService {
  apiName = 'NgSampleModule';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/NgSampleModule/sample' },
      { apiName: this.apiName }
    );
  }
}
