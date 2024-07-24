import {Observable} from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";
import {Injectable} from "@angular/core";

@Injectable({providedIn: 'root'})
export class ProdavacBrisiEndpoint implements MyBaseEndpoint<number, number> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: number): Observable<number> {
    let url = ConfigFile.adresa_servera + "/prodavac/brisi?ID=" + request;
    return this.httpKlijent.delete<number>(url);
  }
}

