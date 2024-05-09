import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from "@angular/forms";
import { Router } from "@angular/router";
import { HeaderComponent } from "../homepage/header/header.component";
import { TranslateModule, TranslateService } from "@ngx-translate/core";

@Component({
  selector: "app-login",
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    TranslateModule,
    ReactiveFormsModule,
  ],
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.css",
})
export class LoginComponent implements OnInit {
  passwordRegx: RegExp = /^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\D*\d).{8,}$/;

  loginForm: FormGroup;

  constructor(
    private router: Router,
    private translateService: TranslateService
  ) {
    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", [
        Validators.required,
        Validators.pattern(this.passwordRegx),
      ]),
    });
  }

  lang: string = "";
  JelLogiran: boolean = false;

  ngOnInit(): void {
    this.lang = localStorage.getItem("lang") || "en";
    this.translateService.use(this.lang);
  }

  logirajSe() {
    this.JelLogiran = true;
    this.router.navigate(["dashboard-admin"]);
  }
}
