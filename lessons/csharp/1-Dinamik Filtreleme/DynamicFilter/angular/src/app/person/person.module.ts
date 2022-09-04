import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonComponent } from './person.component';

import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { DropdownModule } from 'primeng/dropdown';
import { PaginatorModule } from 'primeng/paginator';


@NgModule({
  declarations: [
    PersonComponent
  ],
  imports: [
    CommonModule,
    ButtonModule,
    ToolbarModule,
    TableModule,
    DropdownModule,
    PaginatorModule
  ],
  exports: [PersonComponent]
})
export class PersonModule { }
