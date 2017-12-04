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
  	this.thisevents.sort(this.comparebyd);
  }
  	//button func
    nextweek() {
  	
  	this.weekser.SetNextWeek();
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));
  	this.thisevents.sort(this.comparebyd);
  	//alert(this.thisevents);
  	// alert(this.weekser.fromDate);
  	// alert(this.weekser.toDate);

  }

  constructor(public eventser:EventService, public weekser:EventByWeekService) {
  	this.myDate = new Date();
  }

    getEvents():void {
  	this.eventser.getEvents()
  	.then(es => {this.events = es;
  		for (var i = 0; i < this.events.length; ++i) {
  	  		this.events[i].ef = new Date(this.events[i].eventFromDateTime);
  	  		this.events[i].et = new Date(this.events[i].eventToDateTime);
  	  }
  		this.weekser.SetupThisweek();
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));

  	this.thisevents.sort(this.comparebyd);
  		});
  }

  comparebyd(a : Event, b : Event) {
  	  if (a.ef < b.ef)
	    return -1;
	  if (a.ef > b.ef)
	    return 1;
	  return 0;

  }




  ngOnInit() {
  	this.getEvents();


  	
  }
  title = 'app';
}
