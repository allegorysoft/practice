import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';
import { User } from './models';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiName = 'jsonPlaceholder';

  constructor(private readonly restService: RestService) { }

  get = () =>
    this.restService.request<any, User>(
      {
        method: 'GET',
        url: `/users`
      },
      { apiName: this.apiName }
    );
}
