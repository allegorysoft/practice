import { ABP } from '@abp/ng.core';
import { ePropType, FormProp } from '@abp/ng.theme.shared/extensions';
import { Validators } from '@angular/forms';
import { of } from 'rxjs';
import { CustomerDto } from '../models/customer';

const { required, minLength, maxLength } = Validators;

export const DEFAULT_CUSTOMERS_CREATE_FORM_PROPS = FormProp.createMany<CustomerDto>([
    {
        type: ePropType.String,
        name: 'name',
        displayName: 'AbpIdentity::DisplayName:Name',
        id: 'name',
        validators: () => [required, minLength(3), maxLength(64)],
    },
    {
        type: ePropType.String,
        name: 'surname',
        displayName: 'AbpIdentity::DisplayName:Surname',
        id: 'surname',
        validators: () => [required, minLength(3), maxLength(64)],
    },
    {
        type: ePropType.Number,
        name: 'gender',
        displayName: 'NgSampleApp::Gender',
        id: 'gender',
        options: () => {
            return of(
                [
                    {
                        key: 'Kadın',
                        value: 0
                    },
                    {
                        key: 'Erkek',
                        value: 1
                    }
                ] as ABP.Option<any>[]
            )
        }
    }
]);

export const DEFAULT_CUSTOMERS_EDIT_FORM_PROPS = DEFAULT_CUSTOMERS_CREATE_FORM_PROPS;
