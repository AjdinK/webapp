import {Component, OnInit} from '@angular/core';
import {AdminGetByIdEndpoint, AdminGetByIdResponse} from "../../endpoints/admin-endpoints/admin-get-by-id-endpoint";
import {FormsModule, NgForm, ReactiveFormsModule} from "@angular/forms";
import {NgForOf, NgIf} from "@angular/common";
import {GradGetAllEndpoint, GradGetAllResponseGrad} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit{

  constructor (
    private adminGetByIdEndpoint:AdminGetByIdEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint
    ) {}

  JelPopunjeno: boolean = false
  showAdminForm: boolean = true;
  adminPodaci : AdminGetByIdResponse | null = null;
  gradPodaci: GradGetAllResponseGrad[] | null = null;


  ngOnInit(): void {
    this.fetchAdmin();
    this.fetchGrad();
  }

  fetchAdmin() {
    this.adminGetByIdEndpoint.obradi(1).subscribe({
      next: (x) => {
        this.adminPodaci = x;
      },
      error: (x) => { alert("greska adminGetByIdEndpoint -> " + x.error) },
    });
  }

  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => { alert("greska fetchGrad -> " + x.error) },
    });
  }

  snimi (dodajForm: NgForm) {

  }

  closeEdit() {
    this.showAdminForm = false;
    this.fetchAdmin();
  }

}
