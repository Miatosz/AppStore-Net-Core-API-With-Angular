import { Component, OnInit } from '@angular/core';
import { AppDetail } from '../shared/app-detail.model';
import { PlatformDetail } from 'src/app/shared/platform-detail.model';
import { AppDetailService } from "./../shared/app-detail.service";
import { MatCardModule } from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';


@Component({
  selector: 'app-app-details',
  templateUrl: './app-details.component.html',
  styles: [ 'app-details.component.css']
})
export class AppDetailsComponent implements OnInit {

  appDetail: AppDetail[] = [];
  platformDetail: PlatformDetail[] = [];

  platformSelected:number=0;

  lineCounter:number=0;

  appImagePath:string='';



  constructor(public service: AppDetailService) { }

  ngOnInit(): void {   
    console.log(this.service.appDownload(10));
    this.service.getAppList().subscribe(data => 
      {this.appDetail = data; 
      //this.appImagePath = 'otomoto.png';
      console.log(this.appDetail)})

    this.service.getPlatformList().subscribe(data => 
      {this.platformDetail = data;      
      })
    
  }

  onAppSelected(selectedPlatformId:any):void{
    this.service.getAppsForSelectedPlatform(selectedPlatformId).subscribe
    (
      data => {
        this.appDetail = data;
      }
    );
    
  }

  

}
