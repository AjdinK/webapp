import { afterNextRender, Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CommonModule, NgOptimizedImage } from "@angular/common";
import { TranslateModule, TranslateService } from "@ngx-translate/core";

@Component({
  selector: "app-header",
  standalone: true,
  imports: [NgOptimizedImage, CommonModule, TranslateModule],
  templateUrl: "./header.component.html",
  styleUrl: "./header.component.css",
})
export class HeaderComponent implements OnInit {
  constructor(
    private router: Router,
    private translateService: TranslateService
  ) {}

  lang: string = "";
  ngOnInit(): void {
    if (typeof window !== "undefined" && window.localStorage) {
      this.lang = localStorage.getItem("lang") || "en";
      this.translateService.use(this.lang);
    }
  }
  openMenu: boolean = false;

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
}
