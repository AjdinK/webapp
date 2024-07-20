import {Observable} from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {AuthLoginRequest} from "./auth-login-request";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";
import {Injectable} from "@angular/core";

@Injectable({providedIn: 'root'})
export class AuthLoginEndpoint implements MyBaseEndpoint<AuthLoginRequest, any> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: AuthLoginRequest): Observable<any> {
    let url = ConfigFile.adresa_servera + '/AuthLoginEndpoint';
    return this.httpKlijent.post<any>(url, request);
  }

}
