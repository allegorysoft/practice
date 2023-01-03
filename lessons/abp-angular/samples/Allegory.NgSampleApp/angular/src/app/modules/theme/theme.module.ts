import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { CoreModule } from '@abp/ng.core';

import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RippleModule } from 'primeng/ripple';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';

import { ThemeComponent } from './theme.component';

@NgModule({
  declarations: [ThemeComponent],
  imports: [
    CommonModule,
    CoreModule.forChild({
      localizations: [
        {
          culture: 'tr',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: {
                Theming: 'Tema',
              },
            },
          ],
        },
        {
          culture: 'en',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: {
                Theming: 'Theming',
              },
            },
          ],
        },
      ],
    }),
    RouterModule.forChild([
      {
        path: '',
        component: ThemeComponent,
      },
    ]),
    ButtonModule,
    InputTextModule,
    CheckboxModule,
    RadioButtonModule,
    RippleModule,
    MessagesModule,
    MessageModule
  ],
})
export class ThemeModule {}
