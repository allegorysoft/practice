import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { Photo } from './models';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  apiName = 'jsonPlaceholder';

  constructor(private readonly restService: RestService) { }

  get = (limit: number = 5) =>
    this.restService.request<null, Photo[]>(
      {
        method: 'GET',
        url: `/photos?_limit=${limit}`
      },
      { apiName: this.apiName }
    );

  getByUser = (limit: number = 5, userId: number = null) =>
    this.restService.request<null, Photo[]>(
      {
        method: 'GET',
        url: `/users/${userId}/photos?_limit=${limit}`
      },
      { apiName: this.apiName }
    );

  delete = (id: number) =>
    this.restService.request<null, any>(
      {
        method: 'DELETE',
        url: `/photos/${id}`
      },
      { apiName: this.apiName }
    )
}
