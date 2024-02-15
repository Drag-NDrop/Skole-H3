import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FDMEVTableMaterialComponent } from './fdm-ev-table-material.component';

describe('FDMEVTableMaterialComponent', () => {
  let component: FDMEVTableMaterialComponent;
  let fixture: ComponentFixture<FDMEVTableMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FDMEVTableMaterialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FDMEVTableMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
