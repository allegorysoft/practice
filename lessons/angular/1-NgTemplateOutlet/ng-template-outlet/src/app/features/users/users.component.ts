import { Component, inject } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { UserService } from '../../services/user.service';
import { TableComponent } from '../../shared/ui/table/table.component';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [NgFor, NgIf, TableComponent],
  providers: [UserService],
  template: `
  <!-- <app-table [data]="users"></app-table> -->
  
  <app-table [data]="users">
    <ng-template #headers>
      <th [style.width]="'10px'">Actions</th>
      <th>Name</th>
      <th>Phone</th>
      <th>Username</th>
    </ng-template>

    <ng-template #rows let-row>
      <td class="text-center">
        <button class="btn btn-sm rounded btn-outline-danger" (click)="remove(row.id)">
          <i class="fa fa-trash"></i>
        </button>
      </td>
      <td>{{ row.name }}</td>
      <td>{{ row.phone }}</td>
      <td>{{ row.username }}</td>
    </ng-template>

    <tfoot *ngIf="users.length > 0" >
      <tr>
        <td colspan="6">
          <h5>Total: {{users.length}}</h5>
        </td>
      </tr>
    </tfoot>
  </app-table>
  `
})
export class UsersComponent {
  users = inject(UserService).users;

  remove(id: number): void {
    this.users = this.users.filter(f => f.id !== id);
  }
}
