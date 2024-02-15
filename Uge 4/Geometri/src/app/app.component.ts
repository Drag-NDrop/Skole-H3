//import { GeometryComponent } from './geometry/geometry.component';

import { SquareInputFieldsComponent } from './square-input-fields/square-input-fields.component';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SquareInputFieldsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Geometri';
}
