import { Component, inject } from '@angular/core';
import { AsyncPipe, NgFor } from '@angular/common';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { User } from '../models/users';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [AsyncPipe, NgFor, HttpClientModule],
  templateUrl: './users.component.html'
})
export class UsersComponent {
  users$ = inject(HttpClient).get<User[]>('https://jsonplaceholder.typicode.com/users');
}
