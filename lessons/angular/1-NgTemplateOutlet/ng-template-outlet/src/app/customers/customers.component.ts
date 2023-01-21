import { Component } from '@angular/core';
import { ContentComponent } from '../content/content.component';
import { Tab } from '../models/tab';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [ContentComponent],
  templateUrl: './customers.component.html'
})
export class CustomersComponent {
  customerInfoTabs: Tab[] = [
    { name: 'General' },
    { name: 'Details' },
  ] as Tab[];
  
  selected = this.customerInfoTabs[0];
}
