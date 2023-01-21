import {
  Component,
  ContentChild,
  EventEmitter,
  Input,
  Output,
  TemplateRef,
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
  templateUrl: './content.component.html'
})
export class ContentComponent {
  @Input() tabs!: Tab[];
  @Input() selected: Tab | null = null;

  @ContentChild('altHeaderTemplate') altHeaderTemplate?: TemplateRef<Tab[]>;
  // @ContentChild('altBodyTemplate') altBodyTemplate?: TemplateRef<any>;

  @Output() selectedChange = new EventEmitter<Tab>();

  selectedOnChange(selected: Tab): void {
    this.selected = selected;
    this.selectedChange.emit(selected);
  }
}
