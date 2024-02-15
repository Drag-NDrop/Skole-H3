import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ECarsData } from '../interfaces/ecars-data'; // Make interface visible
import { CommonModule } from '@angular/common'; // Import CommonModule


@Component({
  selector: 'app-fdm-ev-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './fdm-ev-table.component.html',
  styleUrl: './fdm-ev-table.component.css'
})
export class FDMEVTableComponent {

  eCarsTop25_2022: Array<ECarsData> = [
    {id: 1, rank: 1, model: 'Skoda Enyaq', quantity: 1044, changeQuantityPercent: 284},
    {id: 2, rank: 2, model: 'Tesla Model Y', quantity: 989, changeQuantityPercent: 100},
    {id: 3, rank: 3, model: 'Polestar 2', quantity: 836, changeQuantityPercent: 1990},
    {id: 4, rank: 4, model: 'Audi Q4', quantity: 816, changeQuantityPercent: 586},
    {id: 5, rank: 5, model: 'Ford Mustang Mach-E', quantity: 659, changeQuantityPercent: 1333},
    {id: 6, rank: 6, model: 'Kia EV6', quantity: 520, changeQuantityPercent: 100},
    {id: 7, rank: 7, model: 'VW ID.4', quantity: 458, changeQuantityPercent: -61},
    {id: 8, rank: 8, model: 'Volvo XC40', quantity: 416, changeQuantityPercent: 100},
    {id: 9, rank: 9, model: 'Hyundai Ioniq 5', quantity: 365, changeQuantityPercent: 100},
    {id: 10, rank: 10, model: 'Hyundai Kona', quantity: 359, changeQuantityPercent: -24},
    {id: 11, rank: 11, model: 'Tesla Model 3', quantity: 350, changeQuantityPercent: -68},
    {id: 12, rank: 12, model: 'Kia Niro', quantity: 346, changeQuantityPercent: -16},
    {id: 13, rank: 13, model: 'Peugeot 208', quantity: 330, changeQuantityPercent: 131},
    {id: 14, rank: 14, model: 'VW ID.3', quantity: 329, changeQuantityPercent: -54},
    {id: 15, rank: 15, model: '	Cupra Born', quantity: 298, changeQuantityPercent: 100},
    {id: 16, rank: 16, model: 'Mercedes-Benz EQA', quantity: 289, changeQuantityPercent: 51},
    {id: 17, rank: 17, model: 'VW Up', quantity: 229, changeQuantityPercent: 332},
    {id: 18, rank: 18, model: 'VW ID.5', quantity: 226, changeQuantityPercent: 100},
    {id: 19, rank: 19, model: 'Mercedes-Benz EQB', quantity: 224, changeQuantityPercent: 100},
    {id: 20, rank: 20, model: 'Fiat 500', quantity: 202, changeQuantityPercent: -40},
    {id: 21, rank: 21, model: 'Renault Zoe', quantity: 185, changeQuantityPercent: -18},
    {id: 22, rank: 22, model: 'Peugeot 2008', quantity: 169, changeQuantityPercent: 42},
    {id: 23, rank: 23, model: 'Audi E-tron', quantity: 168, changeQuantityPercent: 25},
    {id: 24, rank: 24, model: 'Dacia Spring', quantity: 160, changeQuantityPercent: 5233},
    {id: 25, rank: 25, model: 'BMW i4', quantity: 142, changeQuantityPercent: 100},

  ];

  subscriber$?: Observable<Array<ECarsData>>

  ngOnInit(){
    let observable = new Observable<Array<ECarsData>>((publisher)=>{
      publisher.next(this.eCarsTop25_2022);
      publisher.complete();
    })

    this.subscriber$ = observable;

  }


}
