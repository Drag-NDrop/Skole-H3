import { ECarsData } from './../../interfaces/ecars-data'; // We want to use the ecars-data interface, so we import it.
import { FossilecarsCreateCarFormComponent } from '../fossilecars-create-car-form/fossilecars-create-car-form.component'; // We want to use the FossilecarsCreateCarFormComponent, so we import it
import { FossilecarsUpdateCarFormComponent } from '../fossilecars-update-car-form/fossilecars-update-car-form.component'; // We want to use the FossilecarsUpdateCarFormComponent, so we import it
import { SeedButtonComponent } from '../seed-button/seed-button.component';
import { DeleteButtonComponent } from "../delete-button/delete-button.component";
import { CarsService } from '../../services/cars.service'; // We want to use the CarsService, so we import it
import {
          AfterViewInit, // AfterViewInit is a lifecycle hook that is called after a component's view has been fully initialized
          Component, // Component is a decorator that marks a class as an Angular component and provides configuration metadata that determines how the component should be processed, instantiated, and used at runtime.
          ViewChild  // ViewChild is a decorator that configures a view query. The change detector looks for the first element or the directive matching the selector in the view DOM. If the view DOM changes, and a new child matches the selector, the property is updated.
        } from '@angular/core'; // We want to use AfterViewInit, Component, ViewChild, so we import it

import {
          Observable, // An Observable is a generic interface for wrapping a single value and asynchronously notifying its subscribers when the value has been updated.
          Subscription, // A Subscription is an object that represents a disposable resource, usually the execution of an Observable.
          of // Creates an Observable that emits some values you specify as arguments, immediately one after the other, and then emits a complete notification.
        } from 'rxjs'; // We want to use Observable, Subscription, of, so we import it

import {
          MatTableDataSource, // MatTableDataSource is a data source that accepts an array of data and includes native support of filtering, sorting, and pagination.
          MatTableModule // MatTableModule is a module that contains all the material design components for the material-table
        } from '@angular/material/table'; // We want to use the MatTableDataSource, MatTableModule, so we import it

import {
          MatPaginator, // MatPaginator is a component used to control the pagination of a table
          MatPaginatorModule // MatPaginatorModule is a module that contains all the material design components for the paginator
       } from '@angular/material/paginator'; // We want to use the MatPaginator, MatPaginatorModule, so we import it

import {
         MatSort, // MatSort is a component used to control the sorting of a table
         MatSortModule // MatSortModule is a module that contains all the material design components for the sorter
        } from '@angular/material/sort';// We want to use the MatSort, MatSortModule, so we import it

import {
         CommonModule // CommonModule is a module that contains all the common directives and pipes, such as NgIf and NgFor
} from '@angular/common';// We want to use the CommonModule, so we import it

import {
         HttpClient // HttpClient is a service for performing HTTP requests
       } from '@angular/common/http'; // We want to use the HttpClient, so we import it

import { animate, state, style, transition, trigger } from '@angular/animations'; // We want to use master/detail view in our table, so we import its dependencies
import { MatIconModule } from '@angular/material/icon'; // We want to use the material icon, so we import it
import { MatButtonModule } from '@angular/material/button'; // We want to use the material button styles, so we import it



@Component({
    selector: 'app-fossilecars',
    standalone: true,
    templateUrl: './fossilecars.component.html',
    styleUrl: './fossilecars.component.css',
    animations: [
        trigger('detailExpand', [
            state('collapsed,void', style({ height: '0px', minHeight: '0' })),
            state('expanded', style({ height: '*' })),
            transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
        ]),
    ],
    imports: [CommonModule,
              MatTableModule,
              MatPaginator,
              MatPaginatorModule,
              MatSortModule,
              MatButtonModule,
              FossilecarsCreateCarFormComponent,
              FossilecarsUpdateCarFormComponent,
              MatIconModule,
              SeedButtonComponent,
              DeleteButtonComponent]
})

export class FossilecarsComponent implements AfterViewInit {
  cars$?: Observable<ECarsData[]>; // Instantiate an observable of ECarsData array
  biler: ECarsData[] = []; // Instantiate an array of ECarsData, which will hold the data from the observable, cars$.
  private subscription: Subscription = new Subscription(); // Instantiate a subscription pool, which will hold all subscriptions


  //dataSource = new MatTableDataSource<ECarsData>(); // Set a datasource for the material-table, of type ECarsData
  dataSource = new MatTableDataSource(this.biler);
  // Table presentation settings
  @ViewChild(MatPaginator) paginator!: MatPaginator; // Define the paginator for the material-table
  @ViewChild(MatSort) sort!: MatSort; // Define the sort for the material-table
  displayedColumns: string[] = ['rank', 'model', 'quantity', 'changeQuantityPercent']; // Define the columns to be displayed in the material-table
  columnsToDisplayWithExpand = [...this.displayedColumns, 'expand'];
  expandedElement!: ECarsData | null;

  constructor(private carService: CarsService, private httpClient: HttpClient){
  // Inject the CarsService: This is a service that fetches the initial data from the backend
  // Inject the HttpClient: This is a service that also fetches and sends data to the backend
  }


  seedDb(){
    this.carService.demoData.forEach(element => {
      this.httpClient.post<ECarsData>('http://localhost:5197/api/CarStat', element).subscribe((response) => {
        console.log(response);
      });
    });
      // After updating, fetch the data again from the API. Normally, we would just update the array of cars with the new data, but in this example, we fetch the data again from the API.
      // This is to demonstrate how to update the data in the table after an update. Not for production use. I'm fully aware that it is completely necessary. But i needed to get moving to something else.
      //this.subscription.unsubscribe();
      // 1 seconds timeout to allow the operations to finish before fetching the data again from the API
      setTimeout(() => {
        // After updating, fetch the data again from the API. Normally, we would just update the array of cars with the new data, but in this example, we fetch the data again from the API.
        // This is to demonstrate how to update the data in the table after an update. Not for production use. I'm fully aware that it is completely necessary. But i needed to get moving to something else.
        //this.subscription.unsubscribe();

        this.carService.getCarData().subscribe(newDataFromObservable => {
          this.biler = newDataFromObservable; // update the array of cars with the new data
          this.dataSource.data = this.biler; // update the datasource
          this.cars$ = of(this.biler); // update the observable
        });
      }, 1000);
  }

deleteDb(){
    if (confirm('Are you sure you want to delete the database?')) {
      this.biler.forEach(element => {
        this.httpClient.delete(`http://localhost:5197/api/CarStat/${element.id}`).subscribe((response) => {
          console.log(response);
        });
      });

      // 1 seconds timeout to allow the operations to finish before fetching the data again from the API
      setTimeout(() => {
        // After updating, fetch the data again from the API. Normally, we would just update the array of cars with the new data, but in this example, we fetch the data again from the API.
        // This is to demonstrate how to update the data in the table after an update. Not for production use. I'm fully aware that it is completely necessary. But i needed to get moving to something else.
        //this.subscription.unsubscribe();

        this.carService.getCarData().subscribe(newDataFromObservable => {
          this.biler = newDataFromObservable; // update the array of cars with the new data
          this.dataSource.data = this.biler; // update the datasource
          this.cars$ = of(this.biler); // update the observable
        });
      }, 1000);


    }
}





  // Test insertion of a car. Only used for debugging.
  insertNewCar(){
    // Start a post request to the backend, with the data of a new car. The data is hardcoded in this example. The response is then pushed to the array of cars, and the datasource is updated.
    // We subscribe to the post request, to get the response from the backend.
    this.httpClient.post<ECarsData>('http://localhost:5197/api/CarStat', {rank: 26, model: 'BMW i4', quantity: 142, changeQuantityPercent: 100}).subscribe((response) => { // the http call is made here
      console.log(response); // log the response to the console
      this.biler.push(response); // push the response to the array of cars
      this.dataSource.data = this.biler // update the datasource
      this.cars$ = of(this.biler); // update the observable
    });
  }

  // API Calls triggered by event bindings from child components -->>
  // Create Car: Insert data from the insertNewCarFormGroup in the FossilecarsCreateCarFormComponent. This method is called from the FossilecarsCreateCarFormComponent.
  insertNewCarFormGroupSubmit(cardata: string){
    this.httpClient.post<ECarsData>('http://localhost:5197/api/CarStat', cardata).subscribe((response) => {
      console.log("new car data from form: " + cardata); // log the response to the console
      console.log(response); // log the response to the console
      this.biler.push(response); // push the response to the array of cars
      this.dataSource.data = this.biler // update the datasource
      this.cars$ = of(this.biler); // update the observable
    });
  }
  updateCarFormGroupSubmit(cardata: string){
      let carDataObj = JSON.parse(cardata);
      // remove id from the object
      let id = carDataObj.id;
      delete carDataObj.id;

      this.httpClient.put<ECarsData>(`http://localhost:5197/api/CarStat/${id}`, carDataObj).subscribe((response) => {

      // After updating, fetch the data again from the API. Normally, we would just update the array of cars with the new data, but in this example, we fetch the data again from the API.
      // This is to demonstrate how to update the data in the table after an update. Not for production use. I'm fully aware that it is completely necessary. But i needed to get moving to something else.
      //this.subscription.unsubscribe();
      this.carService.getCarData().subscribe(newDataFromObservable => {
      this.biler = newDataFromObservable; // update the array of cars with the new data
      this.dataSource.data = this.biler; // update the datasource
      this.cars$ = of(this.biler); // update the observable
});
      });
    }

  deleteCar(cardata: string){
    let carDataObj = JSON.parse(cardata);
    let id = carDataObj.id;
    this.httpClient.delete<ECarsData>(`http://localhost:5197/api/CarStat/${id}`).subscribe((response) => {
      console.log('response: ' + response);
      this.biler = this.biler.filter(car => car.id !== id); // remove the car from the array of cars
      this.dataSource.data = this.biler; // update the datasource
      this.cars$ = of(this.biler); // update the observable

      this.carService.getCarData().subscribe(newDataFromObservable => {
        this.biler = newDataFromObservable; // update the array of cars with the new data
        this.dataSource.data = this.biler; // update the datasource
        this.cars$ = of(this.biler); // update the observable
      });
    });
  }
  // <--- API Calls triggered by event bindings from child components

  // Lifecycle management

  ngOnInit() {
    // Subscribe to the observable, cars$. When new data is emitted from the observable, the data is pushed to the array of cars, and the datasource is updated.
    const sub = this.carService.getCarData().subscribe({next: (newDataFromObservable)=>{
      this.biler = newDataFromObservable; // push the new data to the array of cars
      console.log(newDataFromObservable); // log the new data to the console
      this.dataSource = new MatTableDataSource<ECarsData>(this.biler); // update the datasource
      this.dataSource.paginator = this.paginator; // update the paginator
      this.dataSource.sort = this.sort; // update the sorter
      this.cars$ = of(this.biler); // update the observable
    }})
    this.subscription.add(sub); // add the subscription to the subscription pool
  }

  ngAfterViewInit() {
    // After the view is initialized, we set the paginator and sorter for the material-table
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnDestroy() {
    // When the component is destroyed, we unsubscribe all subscriptions in the subscription pool
    this.subscription.unsubscribe(); // Clean up subscription
  }

}
