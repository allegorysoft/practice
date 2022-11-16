import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SkeletonModule } from 'primeng/skeleton';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';

import { CoreModule } from '@abp/ng.core';

import { PhotosComponent } from './photos.component';
import { PhotoCardComponent } from './components/photo-card/photo-card.component';

@NgModule({
  declarations: [PhotosComponent, PhotoCardComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: PhotosComponent
      }
    ]),
    CoreModule.forChild({
      localizations: [
        {
          culture: 'tr',
          resources: [
            {
              resourceName: 'NgSampleApp',
              texts: {
                Photos: 'Fotoğraflar',
                All: 'Tümü',
                SelectUser: 'Kullanıcı seç'
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
                Photos: 'Photos',
                All: 'All',
                SelectUser: 'Selecet user'
              }
            }
          ]
        }
      ]
    }),
    SkeletonModule,
    CardModule,
    DropdownModule,
    ButtonModule
  ]
})
export class PhotosModule { }
