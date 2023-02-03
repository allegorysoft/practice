import { Validators } from '@angular/forms';
import { ePropType, FormProp } from '@abp/ng.theme.shared/extensions';
import { CustomerDto } from '../proxy/samples';

const { required, minLength, maxLength } = Validators;

export const DEFAULT_CUSTOMERS_CREATE_FORM_PROPS =
  FormProp.createMany<CustomerDto>([
    {
      type: ePropType.String,
      id: 'name',
      name: 'name',
      displayName: 'NgSampleModule::DisplayName:Name',
      validators: () => [required, minLength(3), maxLength(64)],
    },
    {
      type: ePropType.Number,
      id: 'salary',
      name: 'salary',
      displayName: 'NgSampleModule::DisplayName:Salary',
      validators: () => [required, minLength(3), maxLength(64)],
    },
    {
      type: ePropType.Date,
      id: 'birthDate',
      name: 'birthDate',
      displayName: 'NgSampleModule::DisplayName:BirthDate',
      validators: () => [required],
    },
  ]);

export const DEFAULT_CUSTOMERS_EDIT_FORM_PROPS =
  DEFAULT_CUSTOMERS_CREATE_FORM_PROPS;
