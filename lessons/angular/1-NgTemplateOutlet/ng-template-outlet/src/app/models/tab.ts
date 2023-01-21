import { Type } from '@angular/core';

export interface Tab {
  name: string;
  component: Type<any> | null;
}
