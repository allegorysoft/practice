import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppLayoutComponent } from './app-layout.component';
import { NavModule } from '../nav/nav.module';

@NgModule({
  declarations: [AppLayoutComponent],
  imports: [
    CommonModule,
    RouterModule,
    NavModule
  ],
  exports: [AppLayoutComponent]
})
export class AppLayoutModule { }
