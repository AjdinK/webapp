import {MyBaseEndpoint} from "../my-base-endpoint";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";
import {Injectable} from "@angular/core";
import {AuthLogoutRequest} from "./auth-logout-request";

@Injectable({providedIn: 'root'})
export class AuthLogoutEndpoint implements MyBaseEndpoint<AuthLogoutRequest, any> {
  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: AuthLogoutRequest): Observable<any> {
    let url = ConfigFile.adresa_servera + "/auth/logout";
    return this.httpKlijent.post(url, request, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + request.token
      }
    });
  }
}
