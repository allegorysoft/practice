import { NgModule } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { DropdownModule } from 'primeng/dropdown';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';

const modules = [
  InputTextModule,
  InputNumberModule,
  DropdownModule,
  TableModule,
  ButtonModule,
];

@NgModule({
  imports: [modules],
  exports: [modules],
})
export class PrimengModule {}
