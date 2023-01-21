import { NgClass, NgFor, NgIf, CommonModule } from '@angular/common';
import { Component } from '@angular/core';

import { Tab } from '../models/tab';
import { ContentComponent } from '../content/content.component';
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
  templateUrl: './home.component.html'
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

  reset(): void {
    this.tabs = this._tabs;
    this.selected = this.tabs[0];
  }

  closeTab(name: string): void {
    this.tabs = this.tabs.filter(f => f.name !== name);

    if (this.selected?.name === name) {
      this.selected = null;
    }
    if (this.tabs?.length > 0) {
      this.selected = this.tabs[0];
    }
  }

  selectedOnChange(selected: Tab): void {
    this.selected = selected;
  }
}
