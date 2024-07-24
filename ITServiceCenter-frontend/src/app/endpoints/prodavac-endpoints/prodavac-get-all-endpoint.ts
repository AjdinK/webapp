import {Observable} from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";

@Injectable({providedIn: "root"})
export class ProdavacGetAllEndpoint
  implements MyBaseEndpoint<number, ProdavacGetAllResponse> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(pageNumber: number): Observable<ProdavacGetAllResponse> {
    let url =
      ConfigFile.adresa_servera +
      "/prodavac/getall?PageNumber=" +
      pageNumber +
      "&PageSize=" +
      6;
    return this.httpKlijent.get<ProdavacGetAllResponse>(url);
  }
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
  slikaKorisnikaBase64: string | undefined;
}
