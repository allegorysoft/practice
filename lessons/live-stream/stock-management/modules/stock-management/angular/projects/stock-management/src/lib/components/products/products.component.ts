import { Component, inject } from '@angular/core';
import { AsyncPipe } from '@angular/common';

import { TableModule } from 'primeng/table';

import { PageModule } from '@abp/ng.components/page';
import { LocalizationModule } from '@abp/ng.core';

import { ProductViewService } from '../../services/product-view.service';
import { ProductsModalComponent } from './create-update-modal/products-modal.component';

@Component({
  standalone: true,
  selector: 'alg-products',
  templateUrl: './products.component.html',
  imports: [AsyncPipe, TableModule, LocalizationModule, PageModule, ProductsModalComponent],
  providers: [ProductViewService],
})
export class ProductsComponent {
  protected readonly viewService = inject(ProductViewService);
}
