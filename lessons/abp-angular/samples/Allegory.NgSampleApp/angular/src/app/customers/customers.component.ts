import { ABP, eLayoutType, RoutesService } from '@abp/ng.core';
import { eThemeSharedRouteNames } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html'
})
export class CustomersComponent implements OnInit {

  constructor(private readonly routesService: RoutesService) { }

  ngOnInit(): void { }

  patchAndRemoveMenu(): void {
    const dashboardRouteConfig: ABP.Route = {
      path: '/dashboard',
      name: 'Test',
      parentName: '::Menu:Home',
      order: 1,
      layout: eLayoutType.application,
    };

    const newHomeRouteConfig: Partial<ABP.Route> = {
      iconClass: 'fas fa-home',
      parentName: eThemeSharedRouteNames.Administration,
      order: 0,
    };

    this.routesService.add([dashboardRouteConfig]);
    this.routesService.patch('::Menu:Home', newHomeRouteConfig);
    this.routesService.remove(['Config']);
  }
}
