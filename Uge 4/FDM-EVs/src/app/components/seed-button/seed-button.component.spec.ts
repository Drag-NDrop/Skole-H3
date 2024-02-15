import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeedButtonComponent } from './seed-button.component';

describe('SeedButtonComponent', () => {
  let component: SeedButtonComponent;
  let fixture: ComponentFixture<SeedButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SeedButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SeedButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
