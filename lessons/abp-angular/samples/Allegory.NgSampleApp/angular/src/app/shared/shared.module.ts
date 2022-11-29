import { NgModule } from '@angular/core';

import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';

import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';

import { ErrorComponent } from './components/error/error.component';

const COMPONENTS = [
  ErrorComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    NgbDropdownModule,
    NgxValidateCoreModule,
    CoreModule,
    ThemeSharedModule
  ],
  exports: [
    NgbDropdownModule,
    NgxValidateCoreModule,
    CoreModule,
    ThemeSharedModule,
    ...COMPONENTS
  ]
})
export class SharedModule { }
