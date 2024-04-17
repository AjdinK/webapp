import {Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {Router} from "@angular/router";
import {
  ServiserGetAllEndpoint, ServiserGetAllResponse,
  ServiserGetAllResponseServiseri
} from "../../endpoints/serviser-endpoints/serviser-get-all-endpoint";


@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard-admin.component.html',
  styleUrl: './dashboard-admin.component.css'
})
export class DashboardAdminComponent implements OnInit{
  constructor(
    private router : Router,
    private serviserGetAllEndpoint : ServiserGetAllEndpoint,
  ) {}

  serviserPodaci : ServiserGetAllResponse | null = null;

  ngOnInit(): void {
    this.fetchServiser();
  }

  logout() {
  this.router.navigate(["/homepage"])
  }

  fetchServiser() {
    this.serviserGetAllEndpoint.obradi().subscribe({
      next: x=> {
        this.serviserPodaci = x;
      },
      error: x=> {}
    })
  }

  fetchProdavac() {

  }

  fetchNalog() {

  }

  dodaj() {
    alert("radi")
  }

  onNoClick() {

  }
}
