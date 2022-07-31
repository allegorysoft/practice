import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import {
  AbpApplicationConfigurationService,
  ApplicationConfigurationDto,
  ConfigStateService
} from '@abp/ng.core';

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html'
})
export class ConfigComponent implements OnInit {

  constructor(
    private config: ConfigStateService,
    private abpConfigService: AbpApplicationConfigurationService
  ) { }

  ngOnInit(): void {
    this.showAll();
  }

  showAll(): void {
    console.clear();
    /**
     * this.abpConfigService.get().subscribe(console.log);
     * Aynı veriyi döner
     */
    this.getAll$().subscribe(console.log);
  }

  addRole(): void {
    this.config
      .refreshAppState()
      .pipe(
        map(store => {
          store.currentUser.roles.push('reader');//Role ekler

          const policies = store.auth.grantedPolicies;
          store.auth.grantedPolicies = {
            ...policies,
            'NgSampleApp.Customer': true
          };//Yeni yetki ekler
        })
      )
      .subscribe();
  }

  getAll$(): Observable<ApplicationConfigurationDto> {
    return this.config.getAll$();
  }

  getOne$(key: string): Observable<any> {
    return this.config.getOne$(key);
  }

  getDeep$(keys: string | string[]): Observable<any> {
    return this.config.getDeep$(keys);
  }

  getSettings$(keyword?: string): Observable<Record<string, string>> {
    return this.config.getSettings$(keyword);
  }

  getSetting$(key: string): Observable<string> {
    return this.config.getSetting$(key);
  }

  getFeatures$(keys: string[]): Observable<{}> {
    return this.config.getFeatures$(keys);
  }

  getFeature$(key: string): Observable<string> {
    return this.config.getFeature$(key);
  }
}
