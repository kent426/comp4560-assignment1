import { Component,OnInit } from '@angular/core';
import {Event} from './event';
import {EventService} from './event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[EventService]
})
export class AppComponent implements OnInit {
  events: Event[];

  constructor(public eventser:EventService) {}

    getEvents():void {
  	this.eventser.getEvents()
  	.then(es => this.events = es);
  }

  ngOnInit() {
  	this.getEvents();
  }
  title = 'app';
}
