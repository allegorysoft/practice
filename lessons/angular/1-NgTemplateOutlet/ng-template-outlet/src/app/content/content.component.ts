import {
  Component,
  Input,
  ContentChild,
  TemplateRef,
  Output,
  EventEmitter,
} from '@angular/core';
import {
  NgIf,
  NgFor,
  NgClass,
  NgTemplateOutlet,
  NgComponentOutlet,
} from '@angular/common';

import { Tab } from '../models/tab';

@Component({
  selector: 'app-content',
  standalone: true,
  imports: [
    NgIf,
    NgFor,
    NgClass,
    NgTemplateOutlet,
    NgComponentOutlet,
  ],
  template: `
  <div class="card">
    <div class="card-header">
      <ng-container
        *ngTemplateOutlet="
          altHeaderTemplate || defaultHeaderTemplate;
          context: { $implicit: tabs, selectedTab: selected }
        "
      ></ng-container>

      <ng-template #defaultHeaderTemplate>
        <ul class="nav nav-tabs card-header-tabs">
          <li class="nav-item" *ngFor="let tab of tabs">
            <a
              class="nav-link"
              [ngClass]="{ active: selected?.name === tab.name }"
              href="#"
              (click)="selectedOnChange(tab)"
            >
              {{ tab.name }}
            </a>
          </li>
        </ul>
      </ng-template>
    </div>

    <div class="card-body p-2">
      <ng-container *ngIf="selected?.component as component; else emptyContent">
        <ng-container *ngComponentOutlet="component"></ng-container>
      </ng-container>

      <ng-template #emptyContent>
        <p>Empty content</p>
      </ng-template>
    </div>

    <ng-content></ng-content>
  </div>
  `
})
export class ContentComponent {
  @Input() tabs!: Tab[];
  @Input() selected: Tab | null = null;

  @ContentChild('altHeaderTemplate') altHeaderTemplate?: TemplateRef<Tab[]>;

  @Output() selectedChange = new EventEmitter<Tab>();

  selectedOnChange(selected: Tab): void {
    this.selected = selected;
    this.selectedChange.emit(selected);
  }
}
