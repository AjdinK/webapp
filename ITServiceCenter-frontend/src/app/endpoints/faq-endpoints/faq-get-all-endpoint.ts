import {Observable} from 'rxjs';
import {MyBaseEndpoint} from './../my-base-endpoint';
import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {ConfigFile} from '../../configFile';

@Injectable({providedIn: 'root'})
export class FAQGetAllEndpoint implements MyBaseEndpoint <void, any> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: void): Observable<any> {
    let url = ConfigFile.adresa_servera + '/faq/getall';
    return this.httpKlijent.get<any>(url);
  }
}
