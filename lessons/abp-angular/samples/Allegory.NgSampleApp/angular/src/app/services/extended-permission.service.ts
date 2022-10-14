import { ConfigStateService, PermissionService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ExtendedPermissionService extends PermissionService {

  constructor(configState: ConfigStateService) {
    super(configState);
  }

  //Kendi metodlarımızı buraya yazabiliriz..
}
