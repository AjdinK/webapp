import { Observable } from 'rxjs';

export interface MyBaseEndpoint <TRequest , TRespones>{
  obradi (request : TRequest): Observable<TRespones>;
}

