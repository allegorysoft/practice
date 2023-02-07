import { EntityAction } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';
import { NgSampleModuleComponent } from '../components';

export const DEFAULT_CUSTOMERS_ENTITY_ACTIONS =
  EntityAction.createMany<CustomerDto>([
    {
      text: 'AbpUi::Edit',
      icon: 'fa fa-pencil',
      action: data => {
        const component = data.getInjected(NgSampleModuleComponent);
        component.edit(data.record.id);
      },
      // permission: 'NgSampleModule.Customers.Edit',
    },
    {
      text: 'AbpUi::Delete',
      icon: 'fa fa-trash',
      action: data => {
        const component = data.getInjected(NgSampleModuleComponent);
        component.delete(data.record.id, data.record.name);
      },
      // permission: 'NgSampleModule.Customers.Delete',
    },
  ]);
