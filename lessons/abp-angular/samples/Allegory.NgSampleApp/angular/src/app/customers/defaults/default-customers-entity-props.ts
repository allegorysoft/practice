import { EntityProp, ePropType } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../models/customer';

export const DEFAULT_CUSTOMERS_ENTITY_PROPS = EntityProp.createMany<CustomerDto>([
  {
    type: ePropType.String,
    name: 'id',
    displayName: 'NgSampleApp::Id',
    sortable: false,
    columnWidth: 300
  },
  {
    type: ePropType.String,
    name: 'identityNumber',
    displayName: 'NgSampleApp::IdentityNumber',
    sortable: false,
    columnWidth: 200
  },
  {
    type: ePropType.String,
    name: 'name',
    displayName: 'AbpIdentity::DisplayName:Name',
    sortable: false,
    columnWidth: 200
  },
  {
    type: ePropType.String,
    name: 'surname',
    displayName: 'AbpIdentity::DisplayName:Surname',
    sortable: false,
    columnWidth: 200
  }
]);
