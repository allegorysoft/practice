import { Component, ChangeDetectionStrategy } from '@angular/core';
import { Observable } from 'rxjs';
import { delay } from 'rxjs/operators';

import { Photo, PhotoService } from '@proxy/photos';
import { User, UserService } from '@proxy/users';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PhotosComponent {
  limit: number = 3;
  limits = [3, 5, 10, 20];
  photos$: Observable<Photo[]> = this.getPhotos()
  users$: Observable<User> = this.userService.get();

  selectedUser: User;

  get limitLoop(): number[] {
    return Array(this.limit).fill(0);;
  }

  private getPhotos(): Observable<Photo[]> {
    const { id } = this.selectedUser || {};
    return id
      ? this.photoService.getByUser(this.limit, id)
      : this.photoService.get(this.limit).pipe(delay(500));
  }

  constructor(
    private readonly photoService: PhotoService,
    private readonly userService: UserService
  ) { }

  selectedUserChange(): void {
    this.photos$ = this.getPhotos();
  }

  limitChange(): void {
    this.photos$ = this.getPhotos();
  }
}
