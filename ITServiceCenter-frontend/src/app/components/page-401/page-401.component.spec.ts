import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Page401Component } from './page-401.component';

describe('Page401Component', () => {
  let component: Page401Component;
  let fixture: ComponentFixture<Page401Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Page401Component]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(Page401Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
