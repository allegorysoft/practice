import { EntityAction, EntityActionList } from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../../customers/enums';
import { CustomersEntityActionContributors } from '../../customers/models';
import { CustomerDto } from '../../customers/models/customer';
import { CustomersExtendedComponent } from '../customers-extended.component';

const viewAction = new EntityAction<CustomerDto>({
    text: 'NgSampleApp::View',
    action: data => {
        const component = data.getInjected(CustomersExtendedComponent);
        component.openUserQuickView(data.record);
    },
    icon: 'fa fa-eye',
    // permission: 'NgSampleApp.Customers.View',
});

export function customersModalContributor(actionList: EntityActionList<CustomerDto>) {
    actionList.addTail(viewAction);
}

export const customersEntityActionContributors: CustomersEntityActionContributors = {
    [eCustomersComponents.Customers]: [customersModalContributor],
};
