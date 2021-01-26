import { Injectable } from '@angular/core';
import { AppDetail } from './app-detail.model';
import { HttpClient, HttpEvent, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PlatformDetail } from 'src/app/shared/platform-detail.model';

@Injectable({
  providedIn: 'root'
})
export class AppDetailService {

  formData: AppDetail = new AppDetail();
  readonly baseURL = 'http://localhost:5000/api/';
  list : AppDetail[] = [];

  test:any;
  constructor(private http: HttpClient) { }

  httpOptionsPlain = {
    headers: new HttpHeaders({
      'Accept': 'text/plain',
      'Content-Type': 'text/plain'
    }),
    'responseType': 'text'
  };

  //app
  postApp(){
    console.log("xd");
    return this.http.post(this.baseURL + 'app', this.formData);
  }

  patchApp(val: any){
    return this.http.patch(this.baseURL + 'app/', val);
  }

  deleteApp(val: any){
    return this.http.delete(this.baseURL + 'app/' + val);
  }

  getAppList(): Observable<AppDetail[]>{
    return this.http.get<AppDetail[]>(this.baseURL + 'app');
  }

  //platform
  postPlatform(){
    console.log("xd");
    return this.http.post(this.baseURL + 'platform', this.formData);
  }

  patchPlatform(val: any){
    return this.http.patch(this.baseURL + 'platform/', val);
  }

  deletePlatform(val: any){
    return this.http.delete(this.baseURL + 'platform/' + val);
  }

  getPlatformList(): Observable<PlatformDetail[]>{
    return this.http.get<PlatformDetail[]>(this.baseURL + 'platform');
  }

  getAppsForSelectedPlatform(selectedPlatformId:string): Observable<any>
  {
    let params1 = new HttpParams().set('PlatformId', selectedPlatformId); 
    console.log(this.baseURL + 'app/' + params1, {params:params1});
    return this.http.get(this.baseURL + 'app/' + params1, {params:params1});
  }

  appDownload(val: any): Observable<HttpEvent<Blob>>{
    //return this.http.get(this.baseURL + 'app/' + val + '/Download');
    return this.http.request(new HttpRequest(
      'GET',
      `${this.baseURL}app/${val}/Download`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }

}
