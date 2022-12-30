import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { CONTENT_STRATEGY, DomInsertionService } from '@abp/ng.core';

import styles from '../constants/styles';

export interface Theme {
  isDark: boolean;
  element: HTMLStyleElement;
}

const initalState = {
  isDark: false,
  element: undefined
} as Theme;


@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private readonly _themeState = new BehaviorSubject<Theme>(initalState);

  get theme$(): Observable<Theme> {
    return this._themeState.asObservable();
  }

  constructor(private readonly domInsertionService: DomInsertionService) {}

  toggleTheme(): void {
    const curr = this._themeState.value;
    const newState = { isDark: !curr.isDark } as Theme;

    if (curr.isDark) {
      this.domInsertionService.removeContent(curr.element);
      newState.element = undefined;
    }
    else {
      const options = { id: 'themeStyleId' } as HTMLStyleElement;
      newState.element = this.domInsertionService.insertContent(
        CONTENT_STRATEGY.AppendStyleToHead(styles, options)
      );
    }

    this._themeState.next({ ...newState });
  }
}
