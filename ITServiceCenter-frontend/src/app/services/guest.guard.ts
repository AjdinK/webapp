import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {StorageService} from "./storage.service";

export const guestGuard: CanActivateFn = (route, state) => {

  const localStorage = inject(StorageService);
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
