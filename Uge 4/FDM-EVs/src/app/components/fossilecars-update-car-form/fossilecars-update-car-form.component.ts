import { Component,Output, EventEmitter, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ECarsData } from '../../interfaces/ecars-data';

// Contains both update form and delete car button hooking to parent component(CR ->UD)


@Component({
  selector: 'app-fossilecars-update-car-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './fossilecars-update-car-form.component.html',
  styleUrl: './fossilecars-update-car-form.component.css'
})
export class FossilecarsUpdateCarFormComponent implements OnInit, OnChanges  {
  @Output() updateCarEvent = new EventEmitter<string>();
  @Output() deleteCarEvent = new EventEmitter<string>();
  @Input() carData!: ECarsData;


  updateCarGroup = new FormGroup({
    rank: new FormControl(''),
    model: new FormControl(''),
    quantity: new FormControl(''),
    changeQuantityPercent: new FormControl(''),
    id: new FormControl('')
  });

  updateCar() {
   // console.log(this.updateCarGroup);
   if (this.updateCarGroup.valid) {
    console.log(JSON.stringify(this.updateCarGroup.value))
    this.updateCarEvent.emit(JSON.stringify(this.updateCarGroup.value));
    console.log('Form is valid - emitted it to parent component')
   }
   else {
     console.log('Form is invalid')
   }
  }


  deleteCar() {
    // console.log(this.updateCarGroup);
     this.deleteCarEvent.emit(JSON.stringify(this.updateCarGroup.value));
     console.log('emitted DeleteCar to parent component')
   }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['carData'] && changes['carData'].currentValue) {
      const carData = changes['carData'].currentValue;
      this.updateCarGroup = new FormGroup({
        rank: new FormControl(carData.rank ? carData.rank.toString() : ''),
        model: new FormControl(carData.model ? carData.model.toString() : ''),
        quantity: new FormControl(carData.quantity ? carData.quantity.toString() : ''),
        changeQuantityPercent: new FormControl(carData.changeQuantityPercent ? carData.changeQuantityPercent.toString() : ''),
        id: new FormControl(carData.id ? carData.id.toString() : '')
      });
    }
  }
  ngOnInit() {
    if (this.carData) {
      this.updateCarGroup = new FormGroup({
        rank: new FormControl(this.carData.rank ? this.carData.rank.toString() : ''),
        model: new FormControl(this.carData.model ? this.carData.model.toString() : ''),
        quantity: new FormControl(this.carData.quantity ? this.carData.quantity.toString() : ''),
        changeQuantityPercent: new FormControl(this.carData.changeQuantityPercent ? this.carData.changeQuantityPercent.toString() : ''),
        id: new FormControl(this.carData.id ? this.carData.id.toString() : '')
      })
    }
  }

}
