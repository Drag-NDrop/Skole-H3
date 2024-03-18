import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { SharedService } from '../services/shared-service.service';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ImageObject } from '../interfaces/image-object';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { Observable, Subscription } from 'rxjs';
import { DialogueBoxDialogueComponent, DialogueboxComponent } from '../app/dialoguebox/dialoguebox.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-datagrid',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, MatIconModule, CommonModule, DialogueboxComponent, MatDialogModule],
  templateUrl: './datagrid.component.html',
  styleUrl: './datagrid.component.scss',
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
  ]),
],
})
export class DatagridComponent implements OnInit {
  constructor(private sharedService: SharedService, private dialog: MatDialog) {}
  sub!: Subscription | null;
  displayedColumns: string[] = ['file', 'name']; // replace with your actual column names
  columnsToDisplayWithExpand = [...this.displayedColumns, 'expand'];
  expandedElement!: ImageObject | null;

  dataSource = new MatTableDataSource<ImageObject>(); // specify the type of dataSource

  openImage(file: File) {
    const fileReader = new FileReader();
    fileReader.onload = (e) => {
      if (e.target && e.target.result) {
        window.open(e.target.result.toString());
      }
    };
    fileReader.readAsDataURL(file);
  }
  openDialog(imageObject: ImageObject) {
    const dialogRef = this.dialog.open(DialogueBoxDialogueComponent, {
      data: { imageObject: imageObject }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  ngOnInit(): void {
    this.sub = this.sharedService.sharedObservable$.subscribe((data: ImageObject[]) => {
      if (data) {
        data.forEach(imageObject => {
          const reader = new FileReader();
          reader.onload = (event) => {
            if (event.target && event.target.result) {
              imageObject.dataUrl = event.target.result as string;
            }
          };
          reader.readAsDataURL(imageObject.file);
        });
        this.dataSource.data = data;
      }
    });
  }

  ngOnDestroy() {
    // When the component is destroyed, we unsubscribe all subscriptions in the subscription pool
    this.sub?.unsubscribe();
  }
}
