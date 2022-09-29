import { Validators } from '@angular/forms';
import { ePropType, FormProp, FormPropList } from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from './customers/enums';
import { CustomersCreateFormPropContributors } from './customers/models';
import { CustomerDto } from './customers/models/customer';

const birthdayProp = new FormProp<CustomerDto>({
    type: ePropType.Date,
    name: 'birthday',
    displayName: 'NgSampleApp::BirthDate',
    validators: () => [Validators.required],
});

export function birthdayPropContributor(propList: FormPropList<CustomerDto>) {
    propList.addByIndex(birthdayProp, 3);
}

export const customersCreateFormPropContributors: CustomersCreateFormPropContributors = {
    [eCustomersComponents.CustomerEdit]: [
        birthdayPropContributor
    ],
};
