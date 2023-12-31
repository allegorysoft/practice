import { Component, OnInit } from '@angular/core';
import { StockManagementService } from '../services/stock-management.service';

@Component({
  selector: 'lib-stock-management',
  template: ` <p>stock-management works!</p> `,
  styles: [],
})
export class StockManagementComponent implements OnInit {
  constructor(private service: StockManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
