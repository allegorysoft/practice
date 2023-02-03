import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, switchMap, tap } from 'rxjs';
import { v4 as uuidv4 } from 'uuid';
import { RestService } from '@abp/ng.core';

import type {
  CustomerDto,
  CustomerCreateOrUpdateBase,
  SampleDto,
} from './models';

@Injectable({
  providedIn: 'root',
})
export class SampleService {
  apiName = 'NgSampleModule';
  get = () =>
    this.restService.request<any, SampleDto>(
      {
        method: 'GET',
        url: '/api/NgSampleModule/sample',
      },
      { apiName: this.apiName }
    );
  getAuthorized = () =>
    this.restService.request<any, SampleDto>(
      {
        method: 'GET',
        url: '/api/NgSampleModule/sample/authorized',
      },
      { apiName: this.apiName }
    );

  //#region Customers
  private readonly _customerSubject = new BehaviorSubject<CustomerDto[]>([
    {
      id: '7a0be59e-8f99-4ee1-a7b4-90dcc96161c0',
      name: 'Masum',
      salary: 2500,
      birthDate: '1999-19-10',
    },
    {
      id: '15f53f90-99c7-4d8f-827a-2ac52c8ff04c',
      name: 'Ahmet',
      salary: 2500,
      birthDate: '1998-02-09',
    },
  ]);

  get customers$(): Observable<CustomerDto[]> {
    return this._customerSubject.asObservable();
  }

  private get _customers(): CustomerDto[] {
    return this._customerSubject.value;
  }

  createCustomer = (input: CustomerCreateOrUpdateBase) =>
    of<CustomerDto>({ id: uuidv4(), ...input }).pipe(
      tap(value => this._customerSubject.next([...this._customers, value]))
    );

  deleteCustomer = (id: string) =>
    of(id).pipe(
      switchMap(id => {
        this._customerSubject.next(
          this._customers.filter(f => f.id !== id)
        );
        return of(void 0);
      })
    );

  //#endregion

  constructor(private restService: RestService) {}
}
