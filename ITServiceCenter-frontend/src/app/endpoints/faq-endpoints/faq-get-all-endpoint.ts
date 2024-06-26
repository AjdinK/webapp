import { Observable } from 'rxjs';
import { MyBaseEndpoint } from './../my-base-endpoint';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { ConfigFile } from '../../configFile';
@Injectable({ providedIn: 'root' })
export class FAQGetAllEndpoint implements MyBaseEndpoint <void, any> {
  constructor(private httpKlijent: HttpClient) {}
  obradi(request: void): Observable<any> {
    let url = ConfigFile.adresa_servera + '/FAQ/GetAll';
    return this.httpKlijent.get<any>(url);
  }
}
