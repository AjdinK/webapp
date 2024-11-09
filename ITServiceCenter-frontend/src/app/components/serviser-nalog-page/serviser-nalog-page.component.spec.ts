import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiserNalogPageComponent } from './serviser-nalog-page.component';

describe('ServiserNalogPageComponent', () => {
  let component: ServiserNalogPageComponent;
  let fixture: ComponentFixture<ServiserNalogPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServiserNalogPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ServiserNalogPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
