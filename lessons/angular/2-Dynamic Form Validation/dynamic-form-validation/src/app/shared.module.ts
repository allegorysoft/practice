import { NgModule } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [NgIf, NgFor, ReactiveFormsModule],
  exports: [NgIf, NgFor, ReactiveFormsModule],
})
export class SharedModule {}
