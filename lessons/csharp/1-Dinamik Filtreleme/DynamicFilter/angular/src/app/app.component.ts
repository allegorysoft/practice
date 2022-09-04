import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  styles: [`@import '_overrides/_theme.scss'`],
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
})
export class AppComponent { }
