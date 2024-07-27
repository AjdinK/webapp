import {Observable} from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";
import {Injectable} from "@angular/core";

@Injectable({providedIn: "root"})
export class ProdavacDodajEndpoint
  implements MyBaseEndpoint<ProdavacDodajRequest, number> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: ProdavacDodajRequest): Observable<number> {
    let url = ConfigFile.adresa_servera + "/prodavac/dodaj";
    return this.httpKlijent.post<number>(url, request);
  }
}

export interface ProdavacDodajRequest {
  id: number;
  ime: string;
  prezime: string;
  email: string;
  username: string;
  isProdavac: boolean;
  gradID: number;
  spolID: number;
  slikaKorisnikaBase64: string | undefined;
  lozinka: string;
}
