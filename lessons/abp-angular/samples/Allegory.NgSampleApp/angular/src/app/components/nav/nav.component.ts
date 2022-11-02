import { Component, OnInit, OnDestroy } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import {
  ABP,
  AuthService,
  ConfigStateService,
  CurrentUserDto,
  LocalizationService,
  RoutesService,
  TreeNode
} from '@abp/ng.core';

import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit, OnDestroy {
  //#region Fields
  private destroy$ = new Subject<void>();

  currentUser$: Observable<CurrentUserDto> = this.config.getOne$('currentUser');
  items: MenuItem[] = [];
  navItems: MenuItem[] = [
    {
      icon: 'pi pi-fw pi-user-edit',
      label: this.localizationService.instant('AbpAccount::MyAccount'),
      routerLink: '/account/manage',
    },
    {
      icon: 'pi pi-fw pi-power-off',
      label: this.localizationService.instant('AbpUi::Logout'),
      command: (e) => this.logOut()
    }
  ];

  get isAuthenticated(): boolean {
    return this.config.getDeep('currentUser.isAuthenticated') as boolean;
  }
  //#endregion

  //#region Utilities
  private initMenu(): void {
    this.routesService.visible$
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe(response => {
        this.items = [];
        response.map(root => {
          const menuItem = {
            label: this.localizationService.instant(root.name),
            icon: `pi pi-fw ${root.iconClass ?? 'pi-circle'}`,
            visible: !root.invisible,
            routerLink: root.path,
          } as MenuItem;

          if (!root.isLeaf)
            this.loadChilds(root, menuItem);

          this.items.push(menuItem);
        })
      });
  }

  private loadChilds(root: TreeNode<ABP.Route>, menuItem: MenuItem): void {
    menuItem.items = [];
    root.children.map(child => {
      const childItem = {
        label: this.localizationService.instant(child.name),
        icon: `pi pi-fw ${child.iconClass ?? 'pi-circle'}`,
        visible: !child.invisible,
        routerLink: child.path,
      } as MenuItem;

      if (!child.isLeaf)
        this.loadChilds(child, childItem);

      menuItem.items.push(childItem);
    });
  }
  //#endregion

  //#region Ctor
  constructor(
    private readonly routesService: RoutesService,
    private readonly localizationService: LocalizationService,
    private readonly config: ConfigStateService,
    private readonly authService: AuthService
  ) { }
  //#endregion

  //#region Methods
  ngOnInit(): void {
    this.initMenu();
  }

  navigateToLogin = (): void => this.authService.navigateToLogin();

  logOut = (): any => this.authService.logout().pipe(takeUntil(this.destroy$)).subscribe()

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  //#endregion
}
