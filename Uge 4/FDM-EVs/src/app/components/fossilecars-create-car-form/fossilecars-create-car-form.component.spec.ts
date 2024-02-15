import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FossilecarsCreateCarFormComponent } from './fossilecars-create-car-form.component';

describe('FossilecarsCreateCarFormComponent', () => {
  let component: FossilecarsCreateCarFormComponent;
  let fixture: ComponentFixture<FossilecarsCreateCarFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FossilecarsCreateCarFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FossilecarsCreateCarFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
