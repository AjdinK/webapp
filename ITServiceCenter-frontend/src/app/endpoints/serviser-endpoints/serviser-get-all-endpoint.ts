import { Observable } from "rxjs";
import {MyBaseEndpoint} from "../my-base-endpoint";
import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {ConfigFile} from "../../configFile";

@Injectable({ providedIn: 'root' })
export class ServiserGetAllEndpoint implements MyBaseEndpoint<void, ServiserGetAllResponse> {
  constructor(private httpKlijent : HttpClient) {}
    obradi(request: void): Observable<ServiserGetAllResponse> {
       let url = ConfigFile.adresa_servera + "/Serviser/GetAll";
        return  this.httpKlijent.get<ServiserGetAllResponse>(url);
    }
}

export interface ServiserGetAllResponse {
  listaServiser : ServiserGetAllResponseServiseri [] ;
}

export interface ServiserGetAllResponseServiseri {
id:number;
ime:string;
prezime:string;
username:string;
email:string;
gradID:number;
spolID:number;
isServiser:boolean;
}
