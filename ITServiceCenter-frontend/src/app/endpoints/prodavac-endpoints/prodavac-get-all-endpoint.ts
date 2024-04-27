import { Observable } from 'rxjs';
import { MyBaseEndpoint } from '../my-base-endpoint';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigFile } from '../../configFile';

@Injectable({ providedIn: 'root' })
export class ProdavacGetAllEndpoint
  implements MyBaseEndpoint<void, ProdavacGetAllResponse>
{
  constructor(private httpKlijent: HttpClient) {}
  obradi(request: void): Observable<ProdavacGetAllResponse> {
    let url = ConfigFile.adresa_servera + '/Prodavac/GetAll';
    return this.httpKlijent.get<ProdavacGetAllResponse>(url);
  }
}

export interface ProdavacGetAllResponse {
  listaProdavac: ProdavacGetAllResponseProdavac[];
}

export interface ProdavacGetAllResponseProdavac {
  id: number;
  ime: string;
  prezime: string;
  username: string;
  email: string;
  gradID: number;
  spolID: number;
  isProdavac: boolean;
  slikaKorisnikaNovaString: string | undefined;
}
