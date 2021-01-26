import { Component, Input, Output, EventEmitter } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { AppDetailService } from "./../../shared/app-detail.service";

@Component({
  selector: 'app-app-download',
  templateUrl: './app-download.component.html',
  styles: [
  ]
})
export class AppDownloadComponent {
  @Input() public disabled: boolean=false;
  @Input() public fileName: number=0;
  // @Output() public downloadStatus: EventEmitter<progressstatus>;
  
  constructor(private service: AppDetailService) {
    //this.downloadStatus = new EventEmitter<progressstatus>();
  }
  
  public download() {
    //this.downloadStatus.emit( {status: ProgressStatusEnum.START});
    this.service.appDownload(this.fileName).subscribe(
      data => {
        //console.log(this.fileName);
       //switch (data.type) {
          // case HttpEventType.DownloadProgress:
          //   this.downloadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
          //   break;
          // case HttpEventType.Response:
            //this.downloadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
            //this.fileName.toLocaleString();
            const downloadedFile = new Blob();            
            const a = document.createElement('a');
            a.setAttribute('style', 'display:none;');
            document.body.appendChild(a);
            a.download = this.fileName.toString();
            a.href = URL.createObjectURL(downloadedFile);
            a.target = '_blank';
            a.click();
            document.body.removeChild(a);
            //break;
        }
      //},
      // error => {
      //   this.downloadStatus.emit( {status: ProgressStatusEnum.ERROR});
      // }
    );
  }
}