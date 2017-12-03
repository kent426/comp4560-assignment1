import { Injectable } from '@angular/core';
import { Headers, Http, Response} from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

import {Event} from './event';


@Injectable()
export class EventService {

	private base_url ="http://zenithnetcore.azurewebsites.net/api/Events";
  constructor(public _http:Http) { }


  getEvents(): Promise<Event[]> {
  	return this._http.get(this.base_url)
  	.toPromise()
  	.then(response => response.json() as Event[])
  	.catch(this.handleError);
  }

    private handleError(error: any) : Promise<any> {
  	console.error('An error occured',error);
  	return Promise.reject(error.message || error);
  }

}
