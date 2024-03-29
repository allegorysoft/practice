import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SkeletonModule } from 'primeng/skeleton';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { AccordionModule } from 'primeng/accordion';

import { CoreModule } from '@abp/ng.core';

import { PhotosComponent } from './photos.component';
import { PhotoCardComponent } from './components/photo-card/photo-card.component';

@NgModule({
  declarations: [PhotosComponent, PhotoCardComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
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
                CreateUser: 'Kullanıcı oluştur',
                SelectUser: 'Kullanıcı seç',
                GetOrganization: 'Organizasyonu getir',
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
                CreateUser: 'Create user',
                SelectUser: 'Selecet user',
                GetOrganization: 'Get organization'
              }
            }
          ]
        }
      ]
    }),
    SkeletonModule,
    CardModule,
    DropdownModule,
    ButtonModule,
    AccordionModule
  ]
})
export class PhotosModule { }
