import { Component, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-seed-button',
  standalone: true,
  imports: [],
  templateUrl: './seed-button.component.html',
  styleUrl: './seed-button.component.css'
})
export class SeedButtonComponent {

  @Output() seedDbEvent = new EventEmitter<string>();

  seedDb() {
    // console.log(this.updateCarGroup);
     this.seedDbEvent.emit();
     console.log('emitted database re-seed to parent component')
   }
}
