import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PotvrdaDijalogComponent } from './potvrda-dijalog.component';

describe('PotvrdaDijalogComponent', () => {
  let component: PotvrdaDijalogComponent;
  let fixture: ComponentFixture<PotvrdaDijalogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PotvrdaDijalogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PotvrdaDijalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
