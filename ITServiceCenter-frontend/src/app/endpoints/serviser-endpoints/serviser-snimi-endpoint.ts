import { Observable } from "rxjs";
import { MyBaseEndpoint } from "../my-base-endpoint";
import { HttpClient } from "@angular/common/http";
import { ConfigFile } from "../../configFile";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class ServiserSnimiEndpoint
  implements MyBaseEndpoint<ServiserSnimiRequest, void> {
  constructor(private httpKlijent: HttpClient) {}
  obradi(request: ServiserSnimiRequest): Observable<void> {
    let url = ConfigFile.adresa_servera + "/Serviser/Snimi";
    return this.httpKlijent.post<void>(url, request);
  }
}

export interface ServiserSnimiRequest {
  id: number;
  ime: string;
  prezime: string;
  email: string;
  username: string;
  isServiser: boolean;
  gradID: number;
  spolID: number;
  slikaKorisnikaNovaString: string | undefined;
}
