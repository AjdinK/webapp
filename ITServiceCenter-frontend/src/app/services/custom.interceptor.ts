import {HttpInterceptorFn} from '@angular/common/http';

export const customInterceptor: HttpInterceptorFn = (req, next) => {

  let token: any;
  let role: any;
  if (typeof window !== "undefined" && window.localStorage) {
    token = localStorage.getItem('token');
    role = localStorage.getItem('role');
  }
  const authReq = req.clone({
    headers: req.headers.set('Authorization', 'Bearer ' + token)
  });

  return next(authReq);
};
