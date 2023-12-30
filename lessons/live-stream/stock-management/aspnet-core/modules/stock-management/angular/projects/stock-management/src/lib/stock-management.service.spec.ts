import { TestBed } from '@angular/core/testing';
import { StockManagementService } from './services/stock-management.service';
import { RestService } from '@abp/ng.core';

describe('StockManagementService', () => {
  let service: StockManagementService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(StockManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
