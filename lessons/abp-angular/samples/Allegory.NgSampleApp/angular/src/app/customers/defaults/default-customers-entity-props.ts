import { LocalizationService } from '@abp/ng.core';
import { EntityProp, ePropType } from '@abp/ng.theme.shared/extensions';
import { of } from 'rxjs';
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
  },
  {
    type: ePropType.Number,
    name: 'gender',
    displayName: 'NgSampleApp::Gender',
    sortable: false,
    columnWidth: 200,
    valueResolver: (data) => {
      const { gender } = data.record;
      const l10n = data.getInjected(LocalizationService);
      const t = l10n.instant.bind(l10n);

      const icon = `<i class="fa ${gender === 0 ? 'fa-venus' : 'fa-mars'} m-1"></i>`
      const _gender = t(gender === 0 ? 'NgSampleApp::Female' : 'NgSampleApp::Male');
      return of(icon + _gender);
    }
  }
]);
