import { Component, OnInit } from '@angular/core';
import {
  AdminGetByIdEndpoint,
  AdminGetByIdResponse,
} from '../../endpoints/admin-endpoints/admin-get-by-id-endpoint';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { NgForOf, NgIf, NgOptimizedImage } from '@angular/common';
import {
  GradGetAllEndpoint,
  GradGetAllResponseGrad,
} from '../../endpoints/grad-endpoints/grad-get-all-endpoint';
import {
  AdminSnimiEndpoint,
  AdminSnimiRequest,
} from '../../endpoints/admin-endpoints/admin-snimi-endpoint';
import {ConfigFile} from "../../configFile";


@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [FormsModule, NgForOf, NgIf, ReactiveFormsModule, NgOptimizedImage],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css',
})
export class AdminComponent implements OnInit {
  constructor(
    private adminGetByIdEndpoint: AdminGetByIdEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private adminSnimiEndpoint: AdminSnimiEndpoint,
  ) {}

  showAdminForm: boolean = true;
  adminPodaciFetch: AdminGetByIdResponse | null = null;
  adminPodaciEdit: AdminSnimiRequest | null = null;

  gradPodaci: GradGetAllResponseGrad[] | null = null;
  formTitle: string = 'Edit Admin';
  JelPopunjeno: boolean = false;

  ngOnInit(): void {
    this.fetchAdmin();
    this.fetchGrad();
  }


  //fetch Admin data from db
  fetchAdmin() {
    this.adminGetByIdEndpoint.obradi(1).subscribe({
      next: (x) => {
        this.adminPodaciFetch = x;
      },
      error: (x) => {
        alert('greska adminGetByIdEndpoint -> ' + x.error);
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
        alert('greska fetchGrad -> ' + x.error);
      },
    });
  }

  //save admin data from the form and check the form if is it valid? or not
  snimi(editForm: NgForm) {
    if (editForm.form.valid) {
      this.adminSnimiEndpoint.obradi(this.adminPodaciFetch!).subscribe({
        next: (x) => {
          this.showAdminForm = false;
          this.fetchAdmin();
        },
        error: (x) => {
          alert('greska snimiAdmin - ' + x.error);
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

  //to show the image in preview box
  generisiPreview() {
    // @ts-ignore
    let file = document.getElementById('slika-input').files[0];
    if (file && this.adminPodaciFetch) {
      let reader = new FileReader();
      reader.onload = () => {
        this.adminPodaciFetch!.slikaKorisnikaBase64 =
          reader.result?.toString();
      };
      reader.readAsDataURL(file);
    }
  }

  protected readonly ConfigFile = ConfigFile;
}
