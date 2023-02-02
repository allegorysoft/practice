import { formatCurrency } from '@angular/common';
import { of } from 'rxjs';
import { ConfigStateService } from '@abp/ng.core';
import { EntityProp, ePropType } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';

export const DEFAULT_CUSTOMERS_ENTITY_PROPS =
  EntityProp.createMany<CustomerDto>([
    {
      type: ePropType.String,
      name: 'id',
      displayName: 'NgSampleModule::Id',
      sortable: true,
      columnWidth: 200,
    },
    {
      type: ePropType.String,
      name: 'name',
      displayName: 'NgSampleModule::Name',
      sortable: true,
    },
    {
      type: ePropType.Number,
      name: 'salary',
      displayName: 'NgSampleModule::Salary',
      sortable: true,
      valueResolver: data => {
        const config = data.getInjected(ConfigStateService);
        const { name } = config.getDeep([
          'localization',
          'currentCulture',
        ]);
        return of(formatCurrency(data.record.salary, name, ''));
      },
    },
    {
      type: ePropType.Date,
      name: 'birthDate',
      displayName: 'NgSampleModule::BirthDate',
      sortable: true,
    },
  ]);
