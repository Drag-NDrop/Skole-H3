import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FDMEVTableComponent } from './fdm-ev-table.component';

describe('FDMEVTableComponent', () => {
  let component: FDMEVTableComponent;
  let fixture: ComponentFixture<FDMEVTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FDMEVTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FDMEVTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
