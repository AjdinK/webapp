import { Observable } from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";
import exp from "node:constants";
@Injectable({ providedIn: 'root' })
export class GradGetAllEndpoint implements MyBaseEndpoint<void, GradGetAllResponse> {
  constructor(private httpKlijent : HttpClient) {}
    obradi(request: void): Observable<GradGetAllResponse> {
      let url = ConfigFile.adresa_servera + "/Grad/GetAll";
      return this.httpKlijent.get<GradGetAllResponse>(url);
    }
}
export interface GradGetAllResponse {
  gradovi : GradGetAllResponseGrad [];
}
export interface GradGetAllResponseGrad {
  id:number;
  naziv:string;
}
