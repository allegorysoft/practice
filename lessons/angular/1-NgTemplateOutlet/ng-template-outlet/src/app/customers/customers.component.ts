import { Component, inject } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ContentComponent } from '../content/content.component';
import { Tab } from '../models/tab';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [HttpClientModule, ContentComponent],
  templateUrl: './customers.component.html'
})
export class CustomersComponent {
  http = inject(HttpClient);

  productTabs: Tab[] = [
    { name: 'General' },
    { name: 'Details' },
  ] as Tab[];
  selected: Tab = this.productTabs[0];

  ngOnInit(): void {
    console.log('customers worked');
  }

  ngOnDestroy(): void {
    console.clear();
  }
}
