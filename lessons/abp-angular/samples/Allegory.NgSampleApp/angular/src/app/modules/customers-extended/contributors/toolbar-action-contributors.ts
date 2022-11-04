import { ToolbarAction, ToolbarActionList } from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../../customers/enums';
import { CustomersToolbarActionContributors } from '../../customers/models';
import { CustomerDto } from '../../customers/models/customer';
import { utils, writeFileXLSX } from 'xlsx';

const exportToExcel = new ToolbarAction<CustomerDto[]>({
    text: 'NgSampleApp::ExportToExcel',
    action: data => {
        const fileName = 'customer-list.xlsx';
        const ws = utils.json_to_sheet(data.record);
        const wb = utils.book_new();
        utils.book_append_sheet(wb, ws, "Customers");
        writeFileXLSX(wb, fileName);
    },
    btnClass: 'btn btn-sm btn-success',
    icon: 'fa fa-file-excel-o',
    // permission:'NgSampleApp.Customers.Export'
});

export function exportToExcelContributor(actionList: ToolbarActionList<CustomerDto[]>) {
    actionList.addHead(exportToExcel);
}

export const customersToolbarActionContributors: CustomersToolbarActionContributors = {
    [eCustomersComponents.Customers]: [exportToExcelContributor],
};
