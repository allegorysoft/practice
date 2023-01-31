import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { NgSampleModuleComponent } from './components/ng-sample-module.component';
import { NgSampleModuleService } from '@allegory/ng-sample-module';
import { of } from 'rxjs';

describe('NgSampleModuleComponent', () => {
  let component: NgSampleModuleComponent;
  let fixture: ComponentFixture<NgSampleModuleComponent>;
  const mockNgSampleModuleService = jasmine.createSpyObj('NgSampleModuleService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [NgSampleModuleComponent],
      providers: [
        {
          provide: NgSampleModuleService,
          useValue: mockNgSampleModuleService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NgSampleModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
