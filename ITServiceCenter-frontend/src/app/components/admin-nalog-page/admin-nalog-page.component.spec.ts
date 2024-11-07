import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminNalogPageComponent } from './admin-nalog-page.component';

describe('AdminNalogPageComponent', () => {
  let component: AdminNalogPageComponent;
  let fixture: ComponentFixture<AdminNalogPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminNalogPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminNalogPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
