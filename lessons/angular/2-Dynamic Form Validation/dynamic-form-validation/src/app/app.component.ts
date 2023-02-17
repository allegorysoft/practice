import { Component, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  template: `
    <div class="container">
      <h2 class="text-primary">Dynamic Form Validation</h2>
      <div class="d-flex justify-content-center mt-3 mb-3">
        <select
          class="form-select"
          (change)="translate.use($event.target.value)"
        >
          <option selected value="tr">Türkçe</option>
          <option value="en">English</option>
        </select>
      </div>
      <nav>
        <div id="nav-tab" class="nav nav-tabs" role="tablist">
          <button
            *ngFor="let route of routes"
            type="button"
            class="nav-link"
            [id]="route.id"
            [routerLink]="[route.path]"
            [routerLinkActive]="route.activeClass"
          >
            {{ route.displayName }}
          </button>
        </div>
      </nav>

      <div id="nav-tab-content" class="tab-content">
        <div class="card">
          <div class="card-body">
            <router-outlet></router-outlet>
          </div>
        </div>
      </div>
    </div>
  `,
})
export class AppComponent {
  public readonly translate = inject(TranslateService);

  routes = [
    {
      id: 'manuel-validation',
      path: 'manuel-validation',
      activeClass: 'active',
      displayName: 'Siparişler (Manuel Validation)',
    },
    {
      id: 'ngx-validate',
      path: 'ngx-validate',
      activeClass: 'active',
      displayName: 'Ürünler (Ngx Validate)',
    },
    {
      id: 'ngx-validate-2',
      path: 'ngx-validate-2',
      activeClass: 'active',
      displayName: 'Müşteriler (Ngx Validate)',
    },
  ];
}
