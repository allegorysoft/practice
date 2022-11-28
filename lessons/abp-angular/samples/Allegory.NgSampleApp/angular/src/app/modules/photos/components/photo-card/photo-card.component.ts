import { Component, ChangeDetectionStrategy, Input, Output, EventEmitter } from '@angular/core';
import { Photo } from '@proxy/photos/models';

@Component({
  selector: 'app-photo-card',
  templateUrl: './photo-card.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PhotoCardComponent {
  @Input() photo!: Photo;
  @Output() delete = new EventEmitter<number>();

  deleteOnClick(): void {
    this.delete.emit(this.photo.id);
  }
}
