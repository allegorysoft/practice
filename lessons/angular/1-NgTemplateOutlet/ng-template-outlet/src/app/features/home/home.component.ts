import { NgClass, NgFor, NgIf, CommonModule } from '@angular/common';
import { Component } from '@angular/core';

import { Tab } from '../../models/tab';
import { ContentComponent } from '../../shared/ui/content/content.component';
import { UsersComponent } from '../users/users.component';
import { CustomersComponent } from '../customers/customers.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    NgClass,
    NgIf,
    NgFor,
    //CommonModule, Eklenirse üstde ki 3 sınıfa ihtiyaç duyulmaz
    ContentComponent,
  ],
  template: `
  <button class="btn btn-warning" (click)="reset()">Reset</button>
  <hr />
  <app-content [tabs]="tabs" [selected]="selected">
    <ng-template #headerTemplate>
      <ul class="nav nav-pills card-header-pills">
        <li class="nav-item" *ngIf="tabs.length < 1">
          <a class="nav-link active" href="#"> Empty tab </a>
        </li>

        <li class="nav-item" *ngFor="let tab of tabs">
          <button
            class="nav-link rounded"
            [ngClass]="{ active: selected?.name === tab.name }"
            (click)="selectedChange(tab)"
          >
            {{ tab.name }}
            <i (click)="closeTab(tab.name)" class="fa fa-times text-danger"></i>
          </button>
        </li>
      </ul>
    </ng-template>
  </app-content>
  `
})
export default class HomeComponent {
  tabs: Tab[] = this._tabs;
  selected: Tab | null = this.tabs[0];

  private get _tabs(): Tab[] {
    return [
      {
        name: 'Users',
        component: UsersComponent
      },
      {
        name: 'Customers',
        component: CustomersComponent
      }
    ];
  }

  selectedChange(selected: Tab): void {
    this.selected = selected;
  }

  reset(): void {
    this.tabs = this._tabs;
    this.selected = this.tabs[0];
  }

  closeTab(name: string): void {
    this.tabs = this.tabs.filter(f => f.name !== name);

    if (this.selected?.name === name) {
      this.selected = null;
    }
    if (this.tabs.length > 0) {
      this.selected = this.tabs[0];
    }
  }
}
