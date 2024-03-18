import { Component } from "@angular/core";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { throwError } from "rxjs";
import { CommonModule } from "@angular/common";
import { SharedService } from '../../services/shared-service.service';
import { ImageObject } from '../../interfaces/image-object';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-single-file-upload',
  standalone: true,
  imports: [CommonModule, HttpClientModule, MatTableModule],
  templateUrl: './single-file-upload.component.html',
  styleUrl: './single-file-upload.component.scss'
})
export class SingleFileUploadComponent {
  status: "initial" | "uploading" | "success" | "fail" = "initial";
  file: File | null = null;

  constructor(private http: HttpClient, private sharedService: SharedService) {}



  onChange(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      this.status = "initial";
      this.file = file;
    }
  }

  onUpload() {
    if (this.file) {

      let myFile: ImageObject = {
        file: this.file,
        name: this.file.name
      };

      this.status = "uploading";
      this.sharedService.updateObservable(myFile);

    }
  }
  ngOnInit(): void {}
}
