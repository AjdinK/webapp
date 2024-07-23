import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {MyAuthService} from "./my-auth-service";

export const guestGuard: CanActivateFn = (route, state) => {

  const localStorage = inject(MyAuthService);
  const router = inject(Router);

  const token = localStorage.getValue('token');
  const role = localStorage.getValue('role');


  if (token && role) {
    const roleObj = JSON.parse(role);
    if (roleObj.isAdmin) {
      router.navigateByUrl('/dashboard-admin');
    } else {
      router.navigateByUrl('/dashboard-radnik');
    }
  }
  return true;
};
