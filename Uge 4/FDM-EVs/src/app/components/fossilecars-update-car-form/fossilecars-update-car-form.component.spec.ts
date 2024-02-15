import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FossilecarsUpdateCarFormComponent } from './fossilecars-update-car-form.component';

describe('FossilecarsUpdateCarFormComponent', () => {
  let component: FossilecarsUpdateCarFormComponent;
  let fixture: ComponentFixture<FossilecarsUpdateCarFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FossilecarsUpdateCarFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FossilecarsUpdateCarFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
