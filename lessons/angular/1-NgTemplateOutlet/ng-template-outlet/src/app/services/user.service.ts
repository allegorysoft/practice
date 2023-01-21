import { Injectable } from '@angular/core';
import { User } from '../models/users';

@Injectable()
export class UserService {
  users: User[] = [
    {
      id: 1,
      name: "Leanne Graham",
      username: "Bret",
      phone: "1-770-736-8031",
    },
    {
      id: 2,
      name: "Ervin Howell",
      username: "Antonette",
      phone: "010-692-6593",
    },
    {
      id: 3,
      name: "Clementine Bauch",
      username: "Samantha",
      phone: "1-463-123-4447",
    },
    {
      id: 4,
      name: "Patricia Lebsack",
      username: "Karianne",
      phone: "493-170-9623",
    },
    {
      id: 5,
      name: "Chelsey Dietrich",
      username: "Kamren",
      phone: "(254)954-1289",
    },
  ];
}
