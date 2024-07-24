import {Component, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {CommonModule, NgOptimizedImage} from "@angular/common";
import {TranslateModule, TranslateService} from "@ngx-translate/core";
import {StorageService} from "../../../services/storage.service";

@Component({
  selector: "app-header",
  standalone: true,
  imports: [NgOptimizedImage, CommonModule, TranslateModule],
  templateUrl: "./header.component.html",
  styleUrl: "./header.component.css",
})
export class HeaderComponent implements OnInit {
  lang: string = "";
  openMenu: boolean = false;
  checklogin: boolean = !!this.storageService.isAuthenticated();

  constructor(
    private router: Router,
    private translateService: TranslateService,
    private storageService: StorageService,
  ) {
  }

  ngOnInit(): void {
    this.checkLang();
  }

  logirajSe() {
    this.router.navigate(["/login"]);
  }

  toggleMenu() {
    this.openMenu = !this.openMenu;
  }

  promjeniLang(lang: any) {
    const odabraniJezik = lang.target.value;
    this.lang = odabraniJezik;
    localStorage.setItem("lang", odabraniJezik);
    this.translateService.use(odabraniJezik);
  }

  // logout() {
  //   JSON.stringify(this.logoutRequest);
  //   this.authLogoutEndpoint.obradi(this.logoutRequest!).subscribe({
  //       next: (x: any) => {
  //         this.storageService.removeToken();
  //         this.storageService.removeRole();
  //         this.router.navigate(['']);
  //       },
  //       error: (x: any) => {
  //         alert("greska logout -> " + x.message);
  //       }
  //     }
  //   )
  // }

  private checkLang() {
    if (typeof window !== "undefined" && window.localStorage) {
      this.lang = localStorage.getItem("lang") || "en";
      this.translateService.use(this.lang);
    }
  }
}
