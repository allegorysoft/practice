import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';
import { User, UserCreateDto } from './models';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiName = 'jsonPlaceholder';
  apiNameGithub = 'github';

  constructor(private readonly restService: RestService) { }

  get = () =>
    this.restService.request<any, User[]>(
      {
        method: 'GET',
        url: `/users`
      },
      { apiName: this.apiName }
    );

  getOrganization = (organizationName: string = 'allegorysoft') =>
    this.restService.request<any, User>(
      {
        method: 'GET',
        url: `/orgs/${organizationName}`
      },
      { apiName: this.apiNameGithub }
    );

  create = (input: UserCreateDto) =>
    this.restService.request<UserCreateDto, any>(
      {
        method: 'POST',
        url: `/users`,
        body: input
      },
      { apiName: this.apiName }
    );
}
