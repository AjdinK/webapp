import { Component, OnInit } from "@angular/core";
import {
  AdminGetByIdEndpoint,
  AdminGetByIdResponse,
} from "../../endpoints/admin-endpoints/admin-get-by-id-endpoint";
import { FormsModule, NgForm, ReactiveFormsModule } from "@angular/forms";
import { NgForOf, NgIf, NgOptimizedImage } from "@angular/common";
import {
  GradGetAllEndpoint,
  GradGetAllResponseGrad,
} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";
import {
  AdminSnimiEndpoint,
  AdminSnimiRequest,
} from "../../endpoints/admin-endpoints/admin-snimi-endpoint";
import { ConfigFile } from "../../configFile";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-admin",
  standalone: true,
  imports: [FormsModule, NgForOf, NgIf, ReactiveFormsModule, NgOptimizedImage],
  templateUrl: "./admin.component.html",
  styleUrl: "./admin.component.css",
})
export class AdminComponent implements OnInit {
  constructor(
    private adminGetByIdEndpoint: AdminGetByIdEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private adminSnimiEndpoint: AdminSnimiEndpoint,
    private httpKlijent: HttpClient
  ) {}

  novaSlikaAdmin: any;
  showAdminForm: boolean = true;
  adminPodaciFetch: AdminGetByIdResponse | null = null;
  adminPodaciEdit: AdminSnimiRequest | null = null;

  gradPodaci: GradGetAllResponseGrad[] | null = null;
  formTitle: string = "Edit Admin";
  JelPopunjeno: boolean = false;

  ngOnInit(): void {
    this.fetchAdmin();
    this.fetchGrad();
  }

  //fetch Admin data from db
  //TODO: take the id from the login admin
  fetchAdmin() {
    this.adminGetByIdEndpoint.obradi(1).subscribe({
      next: (x) => {
        this.adminPodaciFetch = x;
      },
      error: (x) => {
        alert("greska adminGetByIdEndpoint -> " + x.error);
      },
    });
  }

  //fetch grad data from db
  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => {
        alert("greska fetchGrad -> " + x.error);
      },
    });
  }

  //save admin data from the form and check the form if is it valid? or not
  snimi(editForm: NgForm) {
    if (editForm.form.valid) {
      this.adminPodaciFetch!.slikaKorisnikaBase64 = this.novaSlikaAdmin;
      this.adminSnimiEndpoint.obradi(this.adminPodaciFetch!).subscribe({
        next: (x) => {
          this.showAdminForm = false;
          this.fetchAdmin();
          window.location.reload();
        },
        error: (x) => {
          alert("greska snimiAdmin - " + x.error);
        },
      });
    }
    this.JelPopunjeno = true;
  }

  //close and refresh admin data from db
  closeEdit() {
    this.showAdminForm = false;
    this.fetchAdmin();
  }

  //preview for the uploaded img
  onFileSelected(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.novaSlikaAdmin = event.target.result;
      };
    }
  }

  protected readonly ConfigFile = ConfigFile;
}
