import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface Customer {
  id: string;
  name: string;
}

export interface Country {
  id: string;
  name: string;
}

export interface Product {
  id: string;
  name: string;
}

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  getList = () =>
    of([
      {
        id: '62831349-5290-46ca-bc14-8d30926ebbcc',
        name: 'Ahmet faruk ULU',
      },
      {
        id: 'ff9c123a-682e-4aeb-8fab-5d774c021788',
        name: 'Masum ULU',
      },
    ] as Customer[]);

  get countries(): Observable<Country[]> {
    return of([
      {
        id: '1',
        name: 'Türkiye',
      },
      {
        id: '2',
        name: 'USA',
      },
    ] as Country[]);
  }

  get products(): Observable<Product[]> {
    return of([
      {
        id: '1',
        name: 'Excalibur G770',
      },
      {
        id: '2',
        name: 'iPhone X',
      },
    ] as Product[]);
  }
}
