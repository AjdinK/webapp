import { Observable } from "rxjs";
import { MyBaseEndpoint } from "../my-base-endpoint";
import { HttpClient } from "@angular/common/http";
import { ConfigFile } from "../../configFile";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class ServiserBrisiEndpoint implements MyBaseEndpoint<number, number> {
  constructor(private httpKlijent: HttpClient) {}
  obradi(request: number): Observable<number> {
    let url = ConfigFile.adresa_servera + "/Serviser/Brisi?ID=" + request;
    return this.httpKlijent.delete<number>(url);
  }
}
