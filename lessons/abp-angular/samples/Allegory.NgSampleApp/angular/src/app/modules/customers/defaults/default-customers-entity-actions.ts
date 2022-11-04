import { EntityAction } from '@abp/ng.theme.shared/extensions';
import { Router } from '@angular/router';
import { CustomerDto } from '../models/customer';

export const DEFAULT_CUSTOMERS_ENTITY_ACTIONS = EntityAction.createMany<CustomerDto>([
  {
    text: 'AbpUi::Edit',
    action: data => {
      const { id } = data.record;
      const router = data.getInjected(Router);
      router.navigate(['/customers/edit', id])
    },
    permission: 'NgSampleApp.Customers.Update',
  },
  {
    text: 'AbpUi::Delete',
    action: data => {
      console.log(data.record);
    },
    permission: 'NgSampleApp.Customers.Delete',
  }
]);
