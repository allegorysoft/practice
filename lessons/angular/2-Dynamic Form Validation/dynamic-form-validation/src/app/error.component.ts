import {
  ChangeDetectionStrategy,
  Component,
  ViewEncapsulation,
} from '@angular/core';
import { ValidationErrorComponent } from '@ngx-validate/core';

@Component({
  selector: 'app-error',
  template: `<h3
    class="invalid-feedback font-weight-bold"
    *ngFor="let error of errors; trackBy: trackByFn"
  >
    {{ error.key | translate : error.params }}
  </h3>`,
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None,
})
export class ErrorComponent extends ValidationErrorComponent {
  ngOnInit(): void {
    console.log(this.errors);
  }
}
