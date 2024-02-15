import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FossilecarsComponent } from './fossilecars.component';

describe('FossilecarsComponent', () => {
  let component: FossilecarsComponent;
  let fixture: ComponentFixture<FossilecarsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FossilecarsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FossilecarsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
