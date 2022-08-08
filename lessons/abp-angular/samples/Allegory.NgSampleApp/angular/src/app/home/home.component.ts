import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Environment, EnvironmentService } from '@abp/ng.core';
import { eLayoutType, RoutesService } from '@abp/ng.core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  get getEnvironment$(): Observable<Environment> {
    return this.environment.getEnvironment$();
  }

  constructor(
    private environment: EnvironmentService,
    private readonly routesService: RoutesService
  ) { }

  addMenu(): void {
    this.routesService.add([
      {
        path: '/customers',
        name: 'Müşteriler',
        order: 3,
        layout: eLayoutType.application,
        iconClass: 'fa fa-users',
      }
    ]);
  }

  /**
   * 
   * @param key API adı
   * @returns Key değerine uygun url bulamazsa varsayılan api url'i döndürür.
   */
  apiUrl$(key: string): Observable<string> {
    return this.environment.getApiUrl$(key);
  }

  //Yeni Environment Atama
  change(): void {
    const oldEnvironment = Object.assign({}, this.environment.getEnvironment());

    const newEnvironment = {
      ...oldEnvironment,
      apis: {
        ...oldEnvironment.apis,
        ProductManagement: {
          url: 'https://localhost:44314'
        }
      }
    } as Environment;

    this.environment.setState(newEnvironment);
  }
}
