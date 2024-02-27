import { Component, Output, EventEmitter } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-fossilecars-create-car-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './fossilecars-create-car-form.component.html',
  styleUrl: './fossilecars-create-car-form.component.css'
})
export class FossilecarsCreateCarFormComponent {

  @Output() newCarAddedEvent = new EventEmitter<string>();

  addNewCar() {
    this.newCarAddedEvent.emit(this.insertNewCarGroup.value);
  }

  insertNewCarGroup: FormGroup = new FormGroup( {
    rank: new FormControl('',[
      Validators.required,
      Validators.minLength(2),
    ]),
    model: new FormControl(''),
    quantity: new FormControl(''),
    changeQuantityPercent: new FormControl('')
});



}
