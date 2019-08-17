import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MyRecords } from '../models/myrecords';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MySecureService {

  private serviceUrl = 'http://localhost:60930/myservice/getall/';
  public recordChange = new Subject<boolean>();
  public recordError = new Subject<string>();
  
  constructor(private httpClient: HttpClient) { }

  SaveRecord(record: MyRecords) {
     return this.httpClient.post<boolean>(this.serviceUrl, record);
  }

  GetAllRecords() {
   return this.httpClient.get<MyRecords[]>(this.serviceUrl);
 }

  
}