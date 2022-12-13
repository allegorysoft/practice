import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { ThemeComponent } from './theme.component';
import { CoreModule } from '@abp/ng.core';

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
              }
            }
          ]
        }
      ]
    }),
    RouterModule.forChild([
      {
        path: '',
        component: ThemeComponent
      }
    ]),
    ButtonModule
  ]
})
export class ThemeModule {}
