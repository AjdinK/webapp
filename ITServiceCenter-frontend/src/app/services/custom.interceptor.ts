import {HttpInterceptorFn} from '@angular/common/http';
import {inject} from "@angular/core";
import {StorageService} from "./storage.service";

export const customInterceptor: HttpInterceptorFn = (req, next) => {

  const localStorage = inject(StorageService);
  const token = localStorage.getValue('token');

  const authReq = req.clone({
    headers: req.headers.set('Authorization', 'Bearer ' + token)
  });

  return next(authReq);
};
