import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SquareInputFieldsComponent } from './square-input-fields.component';

describe('SquareInputFieldsComponent', () => {
  let component: SquareInputFieldsComponent;
  let fixture: ComponentFixture<SquareInputFieldsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SquareInputFieldsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SquareInputFieldsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
