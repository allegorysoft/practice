import { Component, OnInit } from '@angular/core';
import { ModuleService } from '../services/module.service';

@Component({
  selector: 'lib-module',
  template: ` <p>module works!</p> `,
  styles: [],
})
export class ModuleComponent implements OnInit {
  constructor(private service: ModuleService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
