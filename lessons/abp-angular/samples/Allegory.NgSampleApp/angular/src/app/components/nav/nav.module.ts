import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreModule } from '@abp/ng.core';

import { MenubarModule } from 'primeng/menubar';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { TabViewModule } from 'primeng/tabview';
import { SlideMenuModule } from 'primeng/slidemenu';
import { DropdownModule } from 'primeng/dropdown';

import { NavComponent } from './nav.component';
import { LanguagesComponent } from './languages.component';


@NgModule({
  declarations: [
    NavComponent,
    LanguagesComponent
  ],
  imports: [
    CommonModule,
    CoreModule,

    MenubarModule,
    InputTextModule,
    ButtonModule,
    TabViewModule,
    SlideMenuModule,
    DropdownModule
  ],
  exports: [
    NavComponent,
    LanguagesComponent
  ]
})
export class NavModule { }
