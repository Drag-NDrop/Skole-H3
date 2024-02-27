import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { ParticipantData } from './interfaces/participant-data';
import { HttpClientModule } from '@angular/common/http';
import { ParticipantService } from './services/participant.service';
import { FakeNameApiService } from './services/fake-name-api.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'play-with-observables';

  participant$: Observable<ParticipantData> | undefined;
  participants$: Observable<ParticipantData[]> | undefined;

  constructor(private participantService: ParticipantService, private fakeNameApiService: FakeNameApiService){
    this.participants$ = this.participantService.participants$;
  }

  ngOnInit(){
    setInterval(() => {
      this.participant$ = this.fakeNameApiService.emitRandomParticipant();
      let fakeName: string | null;
      this.fakeNameApiService.fetchRandomFakeName().subscribe((fake: FakeName) => {
        next: {
          fakeName = fake.name;
          this.participantService.addParticipant({id: null, name: fakeName!, teacher: fake.eye == 'Amber'? true:false});
        }
  }

}

14:25:00.000
