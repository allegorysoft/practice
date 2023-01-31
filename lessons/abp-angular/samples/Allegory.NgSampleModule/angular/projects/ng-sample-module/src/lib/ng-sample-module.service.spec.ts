import { TestBed } from '@angular/core/testing';
import { NgSampleModuleService } from './services/ng-sample-module.service';
import { RestService } from '@abp/ng.core';

describe('NgSampleModuleService', () => {
  let service: NgSampleModuleService;
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
    service = TestBed.inject(NgSampleModuleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
