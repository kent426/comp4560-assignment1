import { Component,OnInit } from '@angular/core';
import {Event} from './event';
import {EventService} from './event.service';
import {ActivityCategory} from './activity-category';
import {EventByWeekService} from './event-by-week.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[EventService,EventByWeekService]
})
export class AppComponent implements OnInit {
  events: Event[];
  thisevents: Event[];
  myDate: Date;

  //button func
  preweek() {
  	//alert("pre");
  	this.weekser.SetPreWeek();
  	 //  	alert(this.weekser.fromDate);
  		// alert(this.weekser.toDate);
	
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));
  }
  	//button func
    nextweek() {
  	
  	this.weekser.SetNextWeek();
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));
  	//alert(this.thisevents);
  	// alert(this.weekser.fromDate);
  	// alert(this.weekser.toDate);

  }

  constructor(public eventser:EventService, public weekser:EventByWeekService) {
  	this.myDate = new Date();
  }

    getEvents():void {
  	this.eventser.getEvents()
  	.then(es => {this.events = es;this.weekser.SetupThisweek();
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));});
  }

  ngOnInit() {
  	this.getEvents();

  	
  }
  title = 'app';
}
