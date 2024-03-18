import { Component, Inject } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialog, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { ImageObject } from '../../interfaces/image-object';

@Component({
  selector: 'app-dialoguebox',
  standalone: true,
  imports: [MatButtonModule, MatDialogModule],
  templateUrl: './dialoguebox.component.html',
  styleUrl: './dialoguebox.component.scss'
})
export class DialogueboxComponent {
    constructor(public dialog: MatDialog) {}

    openDialog() {
      const dialogRef = this.dialog.open(DialogueBoxDialogueComponent);
      dialogRef.afterClosed().subscribe(result => {
        console.log(`Dialog result: ${result}`);
      });
    }

}
@Component({
  selector: 'app-dialogue-box-dialogue',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './dialogue-box-dialogue.component.html',
  styleUrl: './dialogue-box-dialogue.component.scss'
})

export class DialogueBoxDialogueComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: { imageObject: ImageObject }) { }
 }

