import { Router } from '@angular/router';
import { ToolbarAction } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../models/customer';

export const DEFAULT_CUSTOMERS_TOOLBAR_ACTIONS = ToolbarAction.createMany<CustomerDto[]>([
  {
    text: 'NgSampleApp::Create',
    action: data => {
      const router = data.getInjected(Router);
      router.navigate(['/customers/edit'])
    },
    permission: 'NgSampleApp.Customers.Create',
    icon: 'fa fa-plus',
  },
]);
