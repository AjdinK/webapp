import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {MyAuthService} from "./my-auth-service";

export const authGuard: CanActivateFn = (route, state) => {

  const localStorage = inject(MyAuthService);
  const router = inject(Router);

  const token = localStorage.getValue('token');
  const role = localStorage.getValue('role');


  if (token !== null || role !== null) {
    const roleObj = JSON.parse(role);
    return (roleObj.isAdmin) ? true : router.navigateByUrl('/401');
  }

  router.navigateByUrl('/401');
  return false;
};

