import { Observable } from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {HttpClient} from "@angular/common/http";
import {ConfigFile} from "../../configFile";
import {Injectable} from "@angular/core";

@Injectable({ providedIn: 'root' })
export class AdminGetByIdEndpoint implements MyBaseEndpoint<number, AdminGetByIdResponse> {
  constructor(private httpKlijent : HttpClient) {}
    obradi(request: number): Observable<AdminGetByIdResponse> {
    let url = ConfigFile.adresa_servera + "/Admin/GetById?Id=" + request;
        return this.httpKlijent.get<AdminGetByIdResponse>(url);
    }
}

export interface AdminGetByIdResponse {
  id:number;
  ime:string;
  prezime:string;
  email:string;
  isAdmin:boolean;
  isServiser:boolean;
  isProdavac:boolean;
  gradId:number;
  spolId:number;
}
