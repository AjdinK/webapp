import {MyBaseEndpoint} from "../my-base-endpoint";
import {AuthLoginRequest} from "./auth-login-request";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({providedIn: 'root'})
export class AuthLoginEndpoint implements MyBaseEndpoint<AuthLoginRequest, any> {

  url = "https://localhost:7174/AuthLoginEndpoint";

  constructor(private httpKlijent: HttpClient) {
  }

  obradi(request: AuthLoginRequest): Observable<any> {
    return this.httpKlijent.post(this.url, request);
  }

}
