import { Component} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FDMEVTableComponent } from "./fdm-ev-table/fdm-ev-table.component";
import { FDMEVTableMaterialComponent } from "./fdm-ev-table-material/fdm-ev-table-material.component";
import { FossilecarsComponent } from "./components/fossilecars/fossilecars.component";
import {MatTabsModule} from '@angular/material/tabs'; // We want to use the material tabs, so we import it
// import {BrowserAnimationsModule} from '@angular/platform-browser/animations'; // We want to use the BrowserAnimationsModule, so we import it

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterOutlet, FDMEVTableComponent, FDMEVTableMaterialComponent, FossilecarsComponent, MatTabsModule]
})



export class AppComponent {
  title = 'FDM-EVs Material';
}
