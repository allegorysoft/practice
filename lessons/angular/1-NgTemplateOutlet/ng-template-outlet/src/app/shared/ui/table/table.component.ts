import {
  Component,
  ContentChild,
  Input,
  TemplateRef,
} from '@angular/core';
import { KeyValuePipe, NgFor, NgTemplateOutlet } from '@angular/common';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [NgFor, KeyValuePipe, NgTemplateOutlet],
  template: `
    <table class="table table-sm table-hover table-bordered">
      <thead>
        <tr>
          <ng-container
            *ngTemplateOutlet="
              headers || defaultHeaderTemplate;
              context: { $implicit: data }
            "
          ></ng-container>
        </tr>
      </thead>

      <tbody>
        <tr *ngFor="let row of data">
          <ng-container
            [ngTemplateOutlet]="rows || defaultRowTemplate"
            [ngTemplateOutletContext]="{ $implicit: row }"
          ></ng-container>
        </tr>
      </tbody>
      <ng-content></ng-content>
    </table>

    <ng-template #defaultHeaderTemplate let-data>
      <th *ngFor="let header of data[0] | keyvalue">{{ header.key }}</th>
    </ng-template>

    <ng-template #defaultRowTemplate let-row>
      <td *ngFor="let row of row | keyvalue">{{ row.value }}</td>
    </ng-template>
  `,
})
export class TableComponent {
  @Input() data!: any[];
  @ContentChild('headers') headers: TemplateRef<any> | undefined;
  @ContentChild('rows') rows: TemplateRef<any> | undefined;
}
