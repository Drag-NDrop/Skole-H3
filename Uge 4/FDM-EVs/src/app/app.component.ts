import { Component} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FDMEVTableComponent } from "./fdm-ev-table/fdm-ev-table.component";
import { FDMEVTableMaterialComponent } from "./fdm-ev-table-material/fdm-ev-table-material.component";
import { FossilecarsComponent } from "./components/fossilecars/fossilecars.component";
// import {BrowserAnimationsModule} from '@angular/platform-browser/animations'; // We want to use the BrowserAnimationsModule, so we import it

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterOutlet, FDMEVTableComponent, FDMEVTableMaterialComponent, FossilecarsComponent]
})



export class AppComponent {
  title = 'FDM-EVs Material';
}
