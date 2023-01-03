import { LazyLoadService, LOADING_STRATEGY } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const THEME_KEY = 'theme';
const defaultTheme = 'lara-light-blue.css';

export const THEME_STYLES_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureTheme,
    deps: [LazyLoadService],
    multi: true,
  },
];

export function configureTheme(lazyLoad: LazyLoadService) {
  return () => {
    const theme = localStorage.getItem(THEME_KEY);

    if (!theme)
      localStorage.setItem(THEME_KEY, defaultTheme);

    return lazyLoad.load(
      LOADING_STRATEGY.AppendAnonymousStyleToHead(theme || defaultTheme)
    );
  };
}
