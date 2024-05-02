import { Observable } from 'rxjs';
import { MyBaseEndpoint } from '../my-base-endpoint';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigFile } from '../../configFile';

@Injectable({ providedIn: 'root' })
export class ProdavacGetAllEndpoint
  implements MyBaseEndpoint<number, ProdavacGetAllResponse>
{
  constructor(private httpKlijent: HttpClient) {}
  obradi(pageNumber: number): Observable<ProdavacGetAllResponse> {
    //https://localhost:7174/Prodavac/GetAll?PageNumber=1&PageSize=5
    let url =
      ConfigFile.adresa_servera +
      '/Prodavac/GetAll?PageNumber=' +
      pageNumber +
      '&PageSize=' +
      5;
    return this.httpKlijent.get<ProdavacGetAllResponse>(url);
  }
}

export interface ProdavacGetAllRequest {
  pageSize: number;
  pageNumber: number;
}

export interface ProdavacGetAllResponse {
  listaProdavac: ProdavacGetAllResponseProdavac[];
  currentPage: number;
  totalPages: number;
  pageSize: number;
  totalCount: number;
  hasPrevios: boolean;
  hasNext: boolean;
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
