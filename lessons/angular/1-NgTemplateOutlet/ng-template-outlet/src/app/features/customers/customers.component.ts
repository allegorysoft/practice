import { Component } from '@angular/core';
import { ContentComponent } from '../../shared/ui/content/content.component';
import { Tab } from '../../models/tab';
import { TableComponent } from 'src/app/shared/ui/table/table.component';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [ContentComponent, TableComponent],
  template: `
  <div class="row">
    <div class="col-sm-12 col-md-6 col-lg-6">
      <h4>Customer Table</h4>
      <app-table [data]="customers">
        <ng-template #headers>
          <th>Id</th>
          <th>Name</th>
          <th>Surname</th>
        </ng-template>
      </app-table>
    </div>  

    <div class="col-sm-12 col-md-6 col-lg-6">
      <h4>Customer Informations</h4>
      <app-content [tabs]="customerTabs"></app-content>
    </div>
  </div>
  `
})
export class CustomersComponent {
  customers = [
    { id: 1, name: 'Masum', surname: 'ULU' },
    { id: 2, name: 'Ahmet Faruk', surname: 'ULU' },
  ];

  customerTabs = [{ name: 'General' }, { name: 'Details' }] as Tab[];
}
