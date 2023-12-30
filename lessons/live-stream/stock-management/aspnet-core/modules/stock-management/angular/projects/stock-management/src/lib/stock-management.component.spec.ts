import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { StockManagementComponent } from './components/stock-management.component';
import { StockManagementService } from '@allegory/stock-management';
import { of } from 'rxjs';

describe('StockManagementComponent', () => {
  let component: StockManagementComponent;
  let fixture: ComponentFixture<StockManagementComponent>;
  const mockStockManagementService = jasmine.createSpyObj('StockManagementService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [StockManagementComponent],
      providers: [
        {
          provide: StockManagementService,
          useValue: mockStockManagementService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
