import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {StorageService} from "./storage.service";

export const authGuard: CanActivateFn = (route, state) => {

  const localStorage = inject(StorageService);
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

