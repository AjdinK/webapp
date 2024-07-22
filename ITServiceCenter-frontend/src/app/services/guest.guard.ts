import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";

export const guestGuard: CanActivateFn = (route, state) => {
  let token: any;
  let role: any;
  const router = inject(Router);
  if (typeof window !== "undefined" && window.localStorage) {
    token = localStorage.getItem('token');
    role = localStorage.getItem('role');
  }
  if (token && role) {
    const roleObj = JSON.parse(role);
    if (roleObj.isAdmin) {
      router.navigateByUrl('/dashboard-admin');
    } else {
      router.navigateByUrl('/dashboard-radnik');
    }
    return false;
  }
  return true;
};
