import { Injectable } from '@angular/core';
import { FakeName } from './../interfaces/fake-name';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class FakeNameApiService {

  constructor(private httpClient: HttpClient) { }

  fetchRandomFakeName(){
    return this.httpClient.get<FakeName>('/fakename');
  }
}
