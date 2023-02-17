import { NgFor } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ValidationErrors } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';

export function hasKeys(val: any): boolean {
  return Object.keys(val).length > 0;
}

export interface AppError {
  message: string;
  params: any;
}

@Component({
  selector: 'app-custom-error',
  standalone: true,
  imports: [NgFor, TranslateModule],
  template: `
    <span *ngFor="let error of appErrors">
      {{ error.message | translate : error.params }}
    </span>
  `,
})
export class CustomErrorComponent {
  @Input() errors?: ValidationErrors | null;

  get appErrors(): AppError[] {
    return Object.keys(this.errors || {}).map(val => {
      return {
        message: hasKeys(val) ? val : this.errors![val],
        params: hasKeys(val) ? this.errors![val] : null,
      };
    });
  }
}
