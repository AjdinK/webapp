import {Observable} from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";
import {Injectable} from "@angular/core";

@Injectable({providedIn: "root"})
export class ServiserDodajEndpoint
  implements MyBaseEndpoint<ServiserDodajRequest, number> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: ServiserDodajRequest): Observable<number> {
    let url = ConfigFile.adresa_servera + "/Serviser/Dodaj";
    return this.httpKlijent.post<number>(url, request);
  }
}

export interface ServiserDodajRequest {
  id: number;
  ime: string;
  prezime: string;
  email: string;
  username: string;
  isServiser: boolean;
  gradID: number;
  spolID: number;
  slikaKorisnikaBase64: string | undefined;
  lozinka: string;
}
