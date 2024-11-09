import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiserAddNalogComponent } from './serviser-add-nalog.component';

describe('ServiserAddNalogComponent', () => {
  let component: ServiserAddNalogComponent;
  let fixture: ComponentFixture<ServiserAddNalogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServiserAddNalogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ServiserAddNalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
