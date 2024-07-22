import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";

export const authGuard: CanActivateFn = (route, state) => {
  let token: any;
  let role: any;
  if (typeof window !== "undefined" && window.localStorage) {
    token = localStorage.getItem('token');
    role = localStorage.getItem('role');
  }
  const router = inject(Router);


  if (!token || !role) {
    router.navigateByUrl('/401');
    return false;
  } else {
    const roleObj = JSON.parse(role);
    return roleObj.isAdmin ? true : router.navigateByUrl('/401');
  }
};
