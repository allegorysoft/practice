import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClient, HttpClientModule } from '@angular/common/http';

import {
  TranslateLoader,
  TranslateModule,
  TranslateService,
} from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CURRENCY_MASK_CONFIG } from 'ng2-currency-mask';

import { AppRoutingModule } from './app-routing.module';
import { ErrorComponent } from './error.component';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent, ErrorComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (http: HttpClient) => new TranslateHttpLoader(http),
        deps: [HttpClient],
      },
    }),
    NgxValidateCoreModule.forRoot({
      //Geçersiz icon sınıfının ismi (!)
      // invalidClasses: 'is-invalid',

      //Geçersiz icon sınıfını hangi etikete(tag) ekleyeceğini seçiyor
      // targetSelector: '.col-md-4',

      //Hata mesajını göstermek için kullanacağı componenti belirliyoruz(Zorunlu değil)
      errorTemplate: ErrorComponent,

      //Form'u gönderme event'ı tetiklendiğinde validate ediyor(varsayılan değer: false)
      validateOnSubmit: true,

      //Kendimize ait hata mesajlarını ekliyoruz(Zorunlu değil)
      blueprints: {
        required: 'Bu bir deneme mesajıdır',
        productName: 'Ürün adı XYZ ile başlamalı',
      },
    }),
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      deps: [TranslateService],
      multi: true,
      useFactory: (translate: TranslateService) => () => {
        translate.addLangs(['en', 'tr']);
        translate.setDefaultLang('tr');
        translate.use('tr');
      },
    },
    {
      provide: CURRENCY_MASK_CONFIG,
      useValue: {
        align: 'right',
        allowNegative: false,
        decimal: '.',
        precision: 2,
        prefix: '$',
        suffix: '',
        thousands: ',',
      },
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
