import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppDetailsComponent } from './app-details/app-details.component';
import { AppDetailAddFormComponent } from './app-details/app-detail-add-form/app-detail-add-form.component';
import { HttpClientModule } from '@angular/common/http';
import { AppDetailService } from './shared/app-detail.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import { FormsModule  } from '@angular/forms';
import {MatGridListModule} from '@angular/material/grid-list';
import { AppDownloadComponent } from './../app/app-details/app-download/app-download.component';


@NgModule({
  declarations: [
    AppComponent,
    AppDetailsComponent,
    AppDetailAddFormComponent,
    AppDownloadComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatCardModule,
    FormsModule,
    MatGridListModule
  ],
  providers: [AppDetailService, AppDetailsComponent, AppDownloadComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
