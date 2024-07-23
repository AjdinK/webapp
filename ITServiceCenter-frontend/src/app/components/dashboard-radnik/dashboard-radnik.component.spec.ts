import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardRadnikComponent } from './dashboard-radnik.component';

describe('DashboardRadnikComponent', () => {
  let component: DashboardRadnikComponent;
  let fixture: ComponentFixture<DashboardRadnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardRadnikComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DashboardRadnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
