import {Observable} from 'rxjs';
import {MyBaseEndpoint} from '../my-base-endpoint';
import {HttpClient} from '@angular/common/http';
import {ConfigFile} from '../../configFile';
import {Injectable} from '@angular/core';

@Injectable({providedIn: 'root'})
export class AdminSnimiEndpoint
  implements MyBaseEndpoint<AdminSnimiRequest, number> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: AdminSnimiRequest): Observable<number> {
    let url = ConfigFile.adresa_servera + '/Admin/Snimi';
    return this.httpKlijent.post<number>(url, request);
  }
}

export interface AdminSnimiRequest {
  id: number;
  ime: string;
  prezime: string;
  username: string;
  email: string;
  lozinka: string;
  isAdmin: boolean;
  isServiser: boolean;
  isProdavac: boolean;
  gradId: number;
  slikaKorisnikaBase64: string | undefined;
}

