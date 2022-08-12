import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Environment, EnvironmentService } from '@abp/ng.core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  get getEnvironment$(): Observable<Environment> {
    return this.environment.getEnvironment$();
  }

  constructor(private environment: EnvironmentService) { }

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
