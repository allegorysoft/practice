import { LocalizationService } from "@abp/ng.core";
import { of } from "rxjs";
import { EntityProp, EntityPropList, ePropType } from "@abp/ng.theme.shared/extensions";
import { eCustomersComponents } from "../../customers/enums";
import { CustomersEntityPropContributors } from "../../customers/models";
import { CustomerDto } from "../../customers/models/customer";

const genderProp = new EntityProp<CustomerDto>({
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
});

export function genderPropContributor(propList: EntityPropList<CustomerDto>) {
    propList.addAfter(genderProp, 'surname', (value, name) => value.name === name);
}


export const customersEntityPropContributors: CustomersEntityPropContributors = {
    [eCustomersComponents.Customers]: [genderPropContributor],
};