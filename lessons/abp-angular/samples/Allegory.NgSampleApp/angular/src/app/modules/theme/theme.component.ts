import { Component, OnDestroy } from '@angular/core';
import { concat, Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import {
  CROSS_ORIGIN_STRATEGY,
  DOM_STRATEGY,
  LazyLoadService,
  LOADING_STRATEGY,
  StyleLoadingStrategy,
} from '@abp/ng.core';

import { Theme, ThemeService } from './services/theme.service';

const PATH = '/assets/css/theme.css';

@Component({
  selector: 'app-theme',
  templateUrl: './theme.component.html',
})
export class ThemeComponent implements OnDestroy {
  private readonly destroy$ = new Subject<void>();

  theme$: Observable<Theme> = this.themeService.theme$;

  jsLibs$ = concat(
    this.lazyLoad.load(
      LOADING_STRATEGY.AppendScriptToBody(
        'https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js'
      )
    ),
    this.lazyLoad.load(
      LOADING_STRATEGY.AppendScriptToBody(
        '/assets/js/sample-lib.js'
      )
    )
  );

  constructor(
    private readonly themeService: ThemeService,
    private readonly lazyLoad: LazyLoadService
  ) {}

  toggleTheme(): void {
    this.themeService.toggleTheme();
  }

  addLink() {
    this.lazyLoad
      .load(LOADING_STRATEGY.AppendAnonymousStyleToHead(PATH))
      .pipe(takeUntil(this.destroy$))
      .subscribe();
  }

  addJsLib(): void {
    this.jsLibs$.pipe(takeUntil(this.destroy$)).subscribe();
  }

  addRemoteLink(): void {
    const domStrategy = DOM_STRATEGY.PrependToHead();

    const crossOriginStrategy = CROSS_ORIGIN_STRATEGY.Anonymous(
      'sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh'
    );

    const loadingStrategy = new StyleLoadingStrategy(
      'https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css',
      domStrategy,
      crossOriginStrategy
    );

    this.lazyLoad
      .load(loadingStrategy, 1, 2000)
      .pipe(takeUntil(this.destroy$))
      .subscribe();
  }

  ngOnDestroy(): void {
    this.lazyLoad.remove(PATH);
    this.destroy$.next();
    this.destroy$.complete();
  }
}
