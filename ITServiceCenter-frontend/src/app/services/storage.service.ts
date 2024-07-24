import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class StorageService {

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getValue(key: string) {

    let value: any;
    if (typeof window !== "undefined" && window.localStorage) {
      value = localStorage.getItem(key);
    }
    return value;
  }

  removeToken() {
    localStorage.removeItem('token');
  }

  removeRole() {
    localStorage.removeItem('role');
  }

  clearData() {
    localStorage.clear();
  }


  isAuthenticated(): boolean {
    return this.getValue('token') !== null;
  }

}
