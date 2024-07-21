import {Component, OnInit} from "@angular/core";
import {CommonModule} from "@angular/common";
import {FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators,} from "@angular/forms";
import {Router} from "@angular/router";
import {HeaderComponent} from "../homepage/header/header.component";
import {TranslateModule, TranslateService} from "@ngx-translate/core";
import {AuthLoginRequest} from "../../endpoints/auth-endpoints/auth-login-request";
import {AuthLoginEndpoint} from "../../endpoints/auth-endpoints/auth-login-endpoint";

@Component({
  selector: "app-login",
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    TranslateModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.css",
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  lang: string = "";
  JelLogiran: boolean = false;
  authRequest: AuthLoginRequest;

  constructor(
    private router: Router,
    private translateService: TranslateService,
    private authLoginEndpoint: AuthLoginEndpoint
  ) {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required]),
    });
    this.authRequest = new AuthLoginRequest();
  }

  ngOnInit(): void {
    if (typeof window !== "undefined" && window.localStorage) {
      this.lang = localStorage.getItem("lang") || "en";
      this.translateService.use(this.lang);
    }
  }

  logirajSe(login: NgForm) {

    this.authRequest.korisnickoIme = this.loginForm.value.username;
    this.authRequest.lozinka = this.loginForm.value.password;

    if (login.form.valid) {
      this.authLoginEndpoint.obradi(this.authRequest!).subscribe({
        next: (x) => {
          if (x.token) {
            this.router.navigate(["dashboard-admin"]);
            localStorage.setItem("token", x.token);
            localStorage.setItem('role', JSON.stringify(x.role));
          }
        },
        error: (x) => {
          alert("Error: Nevazeci podaci za prijavu");
          this.JelLogiran = true;
        },
      });
    }
  }
}
