import { ABP, AuthService, ConfigStateService, CurrentUserDto, LocalizationService, NAVIGATE_TO_MANAGE_PROFILE, RoutesService, TreeNode } from '@abp/ng.core';
import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject<void>();

  currentUser$: Observable<CurrentUserDto> = this.config.getOne$('currentUser');
  items: MenuItem[] = [];
  navItems: MenuItem[] = [
    {
      icon: 'pi pi-fw pi-user-edit',
      label: this.localizationService.instant('AbpAccount::MyAccount'),
      routerLink: '/account/manage'
    },
    {
      icon: 'pi pi-fw pi-power-off',
      label: this.localizationService.instant('AbpUi::Logout'),
      command: (e) => this.logOut()
    }
  ];

  private initMenu(): void {
    this.routesService.visible$
      .pipe(takeUntil(this.destroy$))
      .subscribe(response => {
        this.items = [];
        response.map(root => {
          const menuItem = {
            label: this.localizationService.instant(root.name),
            icon: `pi pi-fw ${root.iconClass ?? 'circle'}`,
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
        icon: `pi pi-fw ${child.iconClass ?? 'circle'}`,
        visible: !child.invisible,
        routerLink: child.path,
      } as MenuItem;

      if (!child.isLeaf)
        this.loadChilds(child, childItem);

      menuItem.items.push(childItem);
    });
  }

  get isAuthenticated(): boolean {
    return this.config.getDeep('currentUser.isAuthenticated') as boolean;
  }

  constructor(
    private readonly routesService: RoutesService,
    private readonly localizationService: LocalizationService,
    private readonly config: ConfigStateService,
    private readonly authService: AuthService
  ) { }

  ngOnInit(): void {
    this.initMenu();
  }

  navigateToLogin = (): void => this.authService.navigateToLogin();

  logOut = (): any => this.authService.logout().pipe(takeUntil(this.destroy$)).subscribe()

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
