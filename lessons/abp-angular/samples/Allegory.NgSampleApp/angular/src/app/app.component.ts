import { Component, OnInit } from '@angular/core';

import { ReplaceableComponentsService } from '@abp/ng.core';
import { eThemeBasicComponents } from '@abp/ng.theme.basic';

import { PrimeNGConfig } from 'primeng/api';

import { AppLayoutComponent } from './components/app-layout/app-layout.component';
import { NavItemsComponent } from './components/nav-items/nav-items.component';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(
    private replace: ReplaceableComponentsService,
    private primengConfig: PrimeNGConfig
  ) { }

  // eslint-disable-next-line @angular-eslint/no-empty-lifecycle-method
  ngOnInit(): void {
    this.primengConfig.ripple = true;

    // this.replace.add({
    //   key: 'Theme.ApplicationLayoutComponent',//eThemeBasicComponents.ApplicationLayout,
    //   component: AppLayoutComponent
    // });

    this.replace.add({
      component: NavItemsComponent,
      key: eThemeBasicComponents.NavItems,
    });
  }
}
