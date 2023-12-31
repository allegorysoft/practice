import { Injectable, inject } from '@angular/core';
import { filter, switchMap, tap } from 'rxjs';
import { TableLazyLoadEvent } from 'primeng/table';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

import {
  GetProductsInput,
  ProductCreateUpdateDto,
  ProductDto,
  ProductService,
} from '../proxy/products';

@Injectable()
export class ProductViewService {
  protected readonly productService = inject(ProductService);
  protected readonly confirmationService = inject(ConfirmationService);

  id: string | null = null;
  modalVisible = false;
  products: ProductDto[] = [];
  totalCount = 0;

  getList(event: TableLazyLoadEvent | undefined = undefined) {
    const input = {
      maxResultCount: 10,
      skipCount: event?.first || 0,
    } as GetProductsInput;

    this.productService.getList(input).subscribe(({ items, totalCount }) => {
      this.products = items;
      this.totalCount = totalCount;
    });
  }

  get(id: string) {
    return this.productService.get(id);
  }

  create() {
    this.modalVisible = true;
  }

  edit(id: string) {
    this.id = id;
    this.modalVisible = true;
  }

  save(input: ProductCreateUpdateDto) {
    const request = this.id
      ? this.productService.update(this.id, input)
      : this.productService.create(input);

    request.pipe(tap(() => this.getList({} as any))).subscribe(this.closeModal);
  }

  delete(id: string) {
    this.confirmationService
      .warn('::AreYouSureToDelete', '::AreYouSure')
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.productService.delete(id)),
        tap(() => this.getList())
      )
      .subscribe();
  }

  closeModal = () => {
    this.modalVisible = false;
    this.id = null;
  };
}
