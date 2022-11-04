import { eIdentityComponents, IdentityEntityPropContributors } from "@abp/ng.identity";
import { IdentityUserDto } from "@abp/ng.identity/proxy";
import { EntityProp, EntityPropList, ePropType } from "@abp/ng.theme.shared/extensions";
import { of } from "rxjs";

//#region Tabloya yeni sütun ekleme
const nameProp = new EntityProp<IdentityUserDto>({
    type: ePropType.String,
    name: 'name',
    displayName: 'AbpIdentity::Name',
    sortable: true,
    columnWidth: 250,
});

export function namePropContributor(propList: EntityPropList<IdentityUserDto>) {
    propList.addAfter(nameProp, 'userName', (value, name) => value.name === name);
}
//#endregion

//#region Tablo da var olan sütunları özelleştirme
export function emailPropContributor(propList: EntityPropList<IdentityUserDto>) {
    const index = propList.indexOf('email', (value, name) => value.name === name);
    const droppedNode = propList.dropByIndex(index);
    const emailProp = new EntityProp<IdentityUserDto>({
        ...droppedNode.value,
        valueResolver: data => {
            const { email, emailConfirmed } = data.record;
            const icon = email && !emailConfirmed ? `<i class="fa fa-times text-danger ml-1"></i>` : '';

            return of((email || '') + icon); // should return an observable
        },
    });

    propList.addByIndex(emailProp, index);
}

export function phonePropContributor(propList: EntityPropList<IdentityUserDto>) {
    const index = propList.indexOf('phoneNumber', (value, name) => value.name === name);
    const droppedNode = propList.dropByIndex(index);
    const phoneProp = new EntityProp<IdentityUserDto>({
        ...droppedNode.value,
        valueResolver: data => {
            const { phoneNumber, phoneNumberConfirmed } = data.record;
            const icon =
                phoneNumber && !phoneNumberConfirmed ? `<i class="fa fa-times text-danger ml-1"></i>` : '';

            return of((phoneNumber || '') + icon); // should return an observable
        },
    });

    propList.addByIndex(phoneProp, index);
}
//#endregion

export const identityEntityPropContributors: IdentityEntityPropContributors = {
    [eIdentityComponents.Users]: [
        namePropContributor,
        emailPropContributor,
        phonePropContributor
    ]
};
