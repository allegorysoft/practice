import { Component, OnInit } from '@angular/core';
import { SampleService } from '../proxy/samples';

@Component({
  selector: 'lib-ng-sample-module',
  template: `NgSampleModule works!`,
})
export class NgSampleModuleComponent implements OnInit {
  constructor(private service: SampleService) {}

  ngOnInit(): void {
    this.service.getAuthorized().subscribe(console.log);
  }
}
