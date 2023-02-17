import { FormControl } from '@angular/forms';

export interface Order {
  id: FormControl<string | null>;
  number: FormControl<string>;
  productId: FormControl<string>;
  price: FormControl<number>;
  amount: FormControl<number>;
}

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
