import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import {
  ConfigStateService,
  LanguageInfo,
  SessionStateService
} from '@abp/ng.core';

@Component({
  selector: 'app-languages',
  template: `
    <p-dropdown 
      [options]="dropdownLanguages$ | async" 
      optionLabel="displayName"
      (onChange)="onChangeLang($event.value.cultureName)"
      [appendTo]="'body'"
      >
      <ng-template pTemplate="selectedItem">
        <span *ngIf="defaultLanguage$ | async as defaultLang">
          {{ defaultLang.displayName }}
        </span>
      </ng-template>
      <ng-template let-lang pTemplate="item">
        <span>{{lang.displayName | abpLocalization}}</span>
      </ng-template>
    </p-dropdown>
  `
})
export class LanguagesComponent {
  languages$: Observable<LanguageInfo[]> = this.configState.getDeep$('localization.languages');

  get defaultLanguage$(): Observable<LanguageInfo> {
    return this.languages$.pipe(
      map(
        languages =>
          languages?.find(
            lang => lang.cultureName === this.selectedLangCulture
          ) || {} as LanguageInfo,
      ),
    );
  }

  get dropdownLanguages$(): Observable<LanguageInfo[]> {
    return this.languages$.pipe(
      map(
        languages => languages?.filter(
          lang => lang.cultureName !== this.selectedLangCulture
        ) || [],
      ),
    );
  }

  get selectedLangCulture(): string {
    return this.sessionState.getLanguage();
  }

  constructor(
    private sessionState: SessionStateService,
    private configState: ConfigStateService
  ) { }

  onChangeLang(cultureName: string) {
    this.sessionState.setLanguage(cultureName);
  }
}
