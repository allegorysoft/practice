import { eIdentityComponents, IdentityEntityActionContributors } from '@abp/ng.identity';
import { IdentityUserDto } from '@abp/ng.identity/proxy';
import { EntityAction, EntityActionList } from '@abp/ng.theme.shared/extensions';
import { UsersExtendedComponent } from '../components/users-extended/users-extended.component';

const editAction = new EntityAction<IdentityUserDto>({
    text: 'AbpIdentity::Edit',
    action: data => {
        const component = data.getInjected(UsersExtendedComponent);
        component.edit(data.record.id);
    },
    icon: 'fa fa-pencil',
    permission: 'AbpIdentity.Users.Update',
});

export function usersModalContributor(actionList: EntityActionList<IdentityUserDto>) {
    actionList.dropByIndex(0)
    actionList.addByIndex(editAction, 0);
}

export const identityEntityActionContributors: IdentityEntityActionContributors = {
    [eIdentityComponents.Users]: [usersModalContributor],
};
