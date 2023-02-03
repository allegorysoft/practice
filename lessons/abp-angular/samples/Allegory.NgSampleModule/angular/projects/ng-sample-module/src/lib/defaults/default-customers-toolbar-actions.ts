import { ToolbarAction } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { NgSampleModuleComponent } from '../components';

export const DEFAULT_CUSTOMERS_TOOLBAR_ACTIONS = ToolbarAction.createMany<
  CustomerDto[]
>([
  {
    text: 'NgSampleModule::Create',
    action: data => {
      const component = data.getInjected(NgSampleModuleComponent);
      component.add();
    },
    // permission: 'NgSampleModule.Customers.Create',
    icon: 'fa fa-plus',
  },
]);
