import { Injectable } from '@angular/core';
import {Event} from './event';
import {EventService} from './event.service';
import {ActivityCategory} from './activity-category';
import * as moment from 'moment/moment';

@Injectable()
export class EventByWeekService {

  constructor(public eventser:EventService) {



   }

  fromDate: Date;
  toDate: Date;
  e : Set<Event>;

  getfrom() {
  	return this.fromDate;
  }

  getTo() {
  	return this.toDate;
  }

  filterEvents(es: Event[]) {
  	 this.e = new Set<Event>();
  	 console.log(this.fromDate.getTime());

  	 var num = 0;
  	  for(var inde in es){
  	  	num = num + 1;
  	  }
  	  console.log(num);
  	 console.log(this.toDate.getTime());
  	for (var i = 0; i < num; ++i) {
  		console.log(es[i].eventFromDateTime.substr(0,10));
  		var e = new Date(es[i].eventFromDateTime);
  		if(e.getTime() >= this.fromDate.getTime()&&
  			e.getTime() <= this.toDate.getTime()) {
  			console.log("got");
  			this.e.add(es[i]);

  		}
  	}
  	return this.e;

  }

  SetupThisweek():void {
  	  	this.fromDate = moment().startOf('isoWeek').toDate();
        this.toDate = moment().startOf('isoWeek').add('days', 6).toDate();
  }

  SetNextWeek():void {
  	    this.fromDate = moment(this.fromDate).add('days', 7).toDate();
        this.toDate = moment(this.toDate).add('days', 7).toDate();
  	// this.eventser.getEvents()
  	// .then(es => this.allevents = es);
  }

  SetPreWeek():void {
  	this.fromDate = moment(this.fromDate).add('days', -7).toDate();
        this.toDate = moment(this.toDate).add('days', -7).toDate();


  }

  	
  }

