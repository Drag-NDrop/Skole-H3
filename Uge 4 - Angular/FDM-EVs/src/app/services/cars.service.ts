import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';


export interface ECarsData {
  rank: number| string | null,
  model: string | null,
  quantity: number | string | null,
  changeQuantityPercent: number | string | null,
  id: number | string | null,
}

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  //public eCarsTop25_2022: Array<ECarsData> = [];
  // private eCarsTop25_2022$: Subject<ECarsData[]> = new BehaviorSubject<ECarsData[]>(this.eCarsTop25_2022);
  private cardata?: Observable<ECarsData[]>;

  //Cars: Observable<ECarsData[]> = this.eCarsTop25_2022$.asObservable();
  constructor(private httpClient: HttpClient) {
  /*

    this.eCarsTop25_2022$.next(this.eCarsTop25_2022);
  */
  }

public demoData: ECarsData[] =  [
  {id:0, rank: 1, model: 'Skoda Enyaq', quantity: 1044, changeQuantityPercent: 284},
  {id:0, rank: 2, model: 'Tesla Model Y', quantity: 989, changeQuantityPercent: 100},
  {id:0, rank: 3, model: 'Polestar 2', quantity: 836, changeQuantityPercent: 1990},
  {id:0, rank: 4, model: 'Audi Q4', quantity: 816, changeQuantityPercent: 586},
  {id:0, rank: 5, model: 'Ford Mustang Mach-E', quantity: 659, changeQuantityPercent: 1333},
  {id:0, rank: 6, model: 'Kia EV6', quantity: 520, changeQuantityPercent: 100},
  {id:0, rank: 7, model: 'VW ID.4', quantity: 458, changeQuantityPercent: -61},
  {id:0, rank: 8, model: 'Volvo XC40', quantity: 416, changeQuantityPercent: 100},
  {id:0, rank: 9, model: 'Hyundai Ioniq 5', quantity: 365, changeQuantityPercent: 100},
  {id:0, rank: 10, model: 'Hyundai Kona', quantity: 359, changeQuantityPercent: -24},
  {id:0, rank: 11, model: 'Tesla Model 3', quantity: 350, changeQuantityPercent: -68},
  {id:0, rank: 12, model: 'Kia Niro', quantity: 346, changeQuantityPercent: -16},
  {id:0, rank: 13, model: 'Peugeot 208', quantity: 330, changeQuantityPercent: 131},
  {id:0, rank: 14, model: 'VW ID.3', quantity: 329, changeQuantityPercent: -54},
  {id:0, rank: 15, model: '	Cupra Born', quantity: 298, changeQuantityPercent: 100},
  {id:0, rank: 16, model: 'Mercedes-Benz EQA', quantity: 289, changeQuantityPercent: 51},
  {id:0, rank: 17, model: 'VW Up', quantity: 229, changeQuantityPercent: 332},
  {id:0, rank: 18, model: 'VW ID.5', quantity: 226, changeQuantityPercent: 100},
  {id:0, rank: 19, model: 'Mercedes-Benz EQB', quantity: 224, changeQuantityPercent: 100},
  {id:0, rank: 20, model: 'Fiat 500', quantity: 202, changeQuantityPercent: -40},
  {id:0, rank: 21, model: 'Renault Zoe', quantity: 185, changeQuantityPercent: -18},
  {id:0, rank: 22, model: 'Peugeot 2008', quantity: 169, changeQuantityPercent: 42},
  {id:0, rank: 23, model: 'Audi E-tron', quantity: 168, changeQuantityPercent: 25},
  {id:0, rank: 24, model: 'Dacia Spring', quantity: 160, changeQuantityPercent: 5233},
  {id:0, rank: 25, model: 'BMW i4', quantity: 142, changeQuantityPercent: 100},
];

  getCarData(): Observable<ECarsData[]> {
    return this.httpClient.get<ECarsData[]>('http://localhost:5197/api/CarStat');
  }

}
