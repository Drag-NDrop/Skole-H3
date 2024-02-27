import { Injectable } from '@angular/core';
import { Subject, Observable, BehaviorSubject } from 'rxjs';
import { ParticipantData } from './../interfaces/participant-data';

@Injectable({
  providedIn: 'root'
})
export class ParticipantService {

  private nextId = 0;
  private participants : Array<ParticipantData> = [];
  private participantSubject$: Subject<ParticipantData[]> = new BehaviorSubject<ParticipantData[]>(this.participants);
  participants$: Observable<ParticipantData[]> = this.participantSubject$.asObservable();

  constructor() {
    this.participants = [
      {id: 0, name: 'Alice', teacher: 'true'},
      {id: 1, name: 'Bob', teacher: 'false'},
      {id: 2, name: 'Charlie', teacher: 'false'}
    ];
    this.participantSubject$.next(this.participants);
    this.nextId = 6;
  }

  addParticipant(participant: ParticipantData): void{
    participant.id = this.nextId;
    this.participants.push(participant);
    this.participantSubject$.next(this.participants);
    this.nextId++;

  }



}
