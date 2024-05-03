import { Observable } from "rxjs";
import { MyBaseEndpoint } from "../my-base-endpoint";
import { HttpClient } from "@angular/common/http";
import { ConfigFile } from "../../configFile";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class ProdavacSnimiEndpoint
  implements MyBaseEndpoint<ProdavacSnimiRequest, void> {
  constructor(private httpKlijent: HttpClient) {}
  obradi(request: ProdavacSnimiRequest): Observable<void> {
    let url = ConfigFile.adresa_servera + "/Prodavac/Snimi";
    return this.httpKlijent.post<void>(url, request);
  }
}
export interface ProdavacSnimiRequest {
  id: number;
  ime: string;
  prezime: string;
  email: string;
  username: string;
  isProdavac: boolean;
  gradID: number;
  spolID: number;
  slikaKorisnikaNovaString: string | undefined;
}
