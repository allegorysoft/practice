import { Component, OnInit } from '@angular/core';
import { NgSampleModuleService } from '../services/ng-sample-module.service';

@Component({
  selector: 'lib-ng-sample-module',
  template: ` <p>ng-sample-module works!</p> `,
  styles: [],
})
export class NgSampleModuleComponent implements OnInit {
  constructor(private service: NgSampleModuleService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
