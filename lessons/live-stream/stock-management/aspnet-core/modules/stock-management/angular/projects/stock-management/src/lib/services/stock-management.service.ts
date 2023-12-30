import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class StockManagementService {
  apiName = 'StockManagement';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/StockManagement/sample' },
      { apiName: this.apiName }
    );
  }
}
