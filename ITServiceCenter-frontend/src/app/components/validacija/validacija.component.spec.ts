import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidacijaComponent } from './validacija.component';

describe('ValidacijaComponent', () => {
  let component: ValidacijaComponent;
  let fixture: ComponentFixture<ValidacijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ValidacijaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ValidacijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
