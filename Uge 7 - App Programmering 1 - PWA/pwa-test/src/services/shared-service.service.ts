import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ImageObject } from '../interfaces/image-object';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private sharedObservable = new BehaviorSubject<ImageObject[]>([]);
  sharedObservable$ = this.sharedObservable.asObservable();

  private imageObjects: ImageObject[] = [];

  updateObservable(data: ImageObject) {
    this.imageObjects.push(data);
    this.sharedObservable.next(this.imageObjects);
  }
}
