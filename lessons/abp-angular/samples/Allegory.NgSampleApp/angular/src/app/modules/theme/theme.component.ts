import { Component, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs';
import { Theme, ThemeService } from './services/theme.service';

@Component({
  selector: 'app-theme',
  templateUrl: './theme.component.html'
})
export class ThemeComponent {
  theme$: Observable<Theme> = this.themeService.theme$;

  constructor(private readonly themeService: ThemeService) {}

  toggleTheme(): void {
    this.themeService.toggleTheme();
  }
}
