import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { Router } from "@angular/router";
import { HeaderComponent } from "../homepage/header/header.component";
import { TranslateModule } from "@ngx-translate/core";

@Component({
  selector: "app-login",
  standalone: true,
  imports: [CommonModule, FormsModule, HeaderComponent, TranslateModule],
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.css",
})
export class LoginComponent {
  JelLogiran: boolean = false;
  constructor(private router: Router) {}

  email: string = "";
  lozinka: string = "";

  logirajSe() {
    this.JelLogiran = true;
    this.router.navigate(["dashboard-admin"]);
  }
}
