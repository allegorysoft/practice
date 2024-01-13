import { Component, EventEmitter, Output, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';

import { LocalizationModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';

import { ProductCreateUpdateDto, ProductDto } from '../../../proxy/products';
import { ProductViewService } from '../../../services/product-view.service';

const { required } = Validators;

@Component({
  standalone: true,
  selector: 'alg-products-modal',
  templateUrl: './products-modal.component.html',
  imports: [ReactiveFormsModule, LocalizationModule, ThemeSharedModule, InputTextModule],
})
export class ProductsModalComponent {
  protected readonly fb = inject(FormBuilder);
  protected readonly viewService = inject(ProductViewService);

  productForm = this.fb.group({
    code: ['', required],
    name: [null as string],
  });

  @Output() visibleChange = new EventEmitter<boolean>();

  ngOnInit(): void {
    if (this.viewService.id) {
      this.viewService
        .get(this.viewService.id)
        .subscribe(product => this.productForm.patchValue(product));
    }
  }

  save() {
    if (this.productForm.invalid) {
      return;
    }

    this.viewService.save(this.productForm.value as ProductCreateUpdateDto);
  }

  onClose(visible: boolean) {
    if (!visible) {
      this.viewService.closeModal();
    }

    this.visibleChange.emit(visible);
  }
}
