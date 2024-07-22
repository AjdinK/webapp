import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class MyAuthService {
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

  clearData() {
    localStorage.clear();
  }

  getToken(): string | null {
    return this.getValue('token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

}
