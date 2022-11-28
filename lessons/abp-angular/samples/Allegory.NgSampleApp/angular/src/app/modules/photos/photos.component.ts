import { Component, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Observable, of } from 'rxjs';
import { catchError, delay, map } from 'rxjs/operators';

import { Photo, PhotoService } from '@proxy/photos';
import { User, UserService } from '@proxy/users';

const { required, email } = Validators;

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PhotosComponent {
  //#region Fields
  limit: number = 3;
  limits = [3, 5, 10, 20];
  photos$: Observable<Photo[]> = this.getPhotos()
  hasError: boolean = false;

  users$: Observable<User[]> = this.userService.get();
  form!: FormGroup;
  selectedUser: User;
  //#endregion

  //#region Utilities
  get limitLoop(): number[] {
    return Array(this.limit).fill(0);;
  }

  private getPhotos(): Observable<Photo[]> {
    this.hasError = false;
    const { id } = this.selectedUser || {};
    const req = id
      ? this.photoService.getByUser(this.limit, id)
      : this.photoService.get(this.limit);

    return req.pipe(
      delay(500),
      catchError(error => {
        this.hasError = true;
        return of(error);
      })
    );
  }

  private buildForm(): void {
    this.form = this.fb.group({
      name: [null, [required]],
      username: [null, [required]],
      email: [null, [required, email]]
    });
  }
  //#endregion

  //#region Ctor
  constructor(
    private readonly photoService: PhotoService,
    private readonly userService: UserService,
    private readonly fb: FormBuilder,
    private readonly cd: ChangeDetectorRef
  ) {
    this.buildForm();
  }
  //#endregion

  //#region Methods
  selectedUserChange(): void {
    this.photos$ = this.getPhotos();
  }

  limitChange(): void {
    this.photos$ = this.getPhotos();
  }

  getOrganization(): void {
    this.userService.getOrganization().subscribe();
  }

  onSubmit(): void {
    if (!this.form.valid) return;

    this.userService.create(this.form.value)
      .subscribe(response =>
        console.log(response)
      );
  }

  delete(id: number): void {
    this.photoService.delete(id).subscribe(() => {
      this.photos$ = this.photos$.pipe(map(item => item = item.filter(f => f.id !== id)))
      this.cd.detectChanges();
    });
  }
  //#endregion
}
