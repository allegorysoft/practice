import {
  Component,
  Input,
  ContentChild,
  TemplateRef,
  SimpleChanges,
  OnChanges,
} from '@angular/core';
import {
  NgIf,
  NgFor,
  NgClass,
  NgTemplateOutlet,
  NgComponentOutlet,
} from '@angular/common';

import { Tab } from '../../../models/tab';

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
          headerTemplate || defaultHeaderTemplate;
        "
      ></ng-container>

      <ng-template #defaultHeaderTemplate>
        <ul class="nav nav-tabs card-header-tabs">
          <li class="nav-item" *ngFor="let tab of tabs">
            <button
              class="nav-link"
              [ngClass]="{ active: selected?.name === tab.name }"
              (click)="selectedOnChange(tab)"
            >
              {{ tab.name }}
            </button>
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
  </div>
  `
})
export class ContentComponent implements OnChanges {
  @Input() tabs!: Tab[];
  @Input() selected: Tab | null = null;

  // @Input('headerTemplate') headerTemplate?: TemplateRef<Tab[]>;
  @ContentChild('headerTemplate') headerTemplate?: TemplateRef<Tab[]>;

  selectedOnChange(selected: Tab): void {
    this.selected = selected;
  }

  ngOnChanges(changes: SimpleChanges): void {
    const _tabs = changes['tabs']
    if (_tabs && _tabs.currentValue) {
      this.selected = _tabs.currentValue[0];
    }
  }
}
