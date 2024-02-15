import { Component, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-delete-button',
  standalone: true,
  imports: [],
  templateUrl: './delete-button.component.html',
  styleUrl: './delete-button.component.css'
})
export class DeleteButtonComponent {
  @Output() deleteDbEvent = new EventEmitter<string>();


  deleteDb() {
    // console.log(this.updateCarGroup);
     this.deleteDbEvent.emit();
     console.log('emitted Delete All Data to parent component')
   }

}
