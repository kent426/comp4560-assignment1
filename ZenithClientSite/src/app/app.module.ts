import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';


import { AppComponent } from './app.component';
import { MomentModule } from 'angular2-moment';


import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    MomentModule,
        HttpModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
