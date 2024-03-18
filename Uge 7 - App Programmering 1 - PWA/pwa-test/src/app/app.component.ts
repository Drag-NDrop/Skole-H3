import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SingleFileUploadComponent } from "./single-file-upload/single-file-upload.component";
import { DatagridComponent } from "../datagrid/datagrid.component";
import { trigger, state, style, transition, animate } from '@angular/animations';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [SingleFileUploadComponent, DatagridComponent],
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class AppComponent {
  title = 'pwa-test';
}
