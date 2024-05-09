import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { Router } from "@angular/router";
import { HeaderComponent } from "../homepage/header/header.component";
import { TranslateModule, TranslateService } from "@ngx-translate/core";

@Component({
  selector: "app-login",
  standalone: true,
  imports: [CommonModule, FormsModule, HeaderComponent, TranslateModule],
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.css",
})
export class LoginComponent implements OnInit {
  constructor(
    private router: Router,
    private translateService: TranslateService
  ) {}

  lang: string = "";
  JelLogiran: boolean = false;

  ngOnInit(): void {
    this.lang = localStorage.getItem("lang") || "en";
    this.translateService.use(this.lang);
  }

  email: string = "";
  lozinka: string = "";

  logirajSe() {
    this.JelLogiran = true;
    this.router.navigate(["dashboard-admin"]);
  }
}
