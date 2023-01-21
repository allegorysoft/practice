import { Component, inject } from '@angular/core';
import { NgFor } from '@angular/common';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [NgFor],
  providers: [UserService],
  templateUrl: './users.component.html'
})
export class UsersComponent {
  users = inject(UserService).users;
}
