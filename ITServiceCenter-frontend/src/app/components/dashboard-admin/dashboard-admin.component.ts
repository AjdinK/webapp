import {Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {Router} from "@angular/router";
import {
  ServiserGetAllEndpoint, ServiserGetAllResponse,
  ServiserGetAllResponseServiseri
} from "../../endpoints/serviser-endpoints/serviser-get-all-endpoint";
import {FormsModule} from "@angular/forms";
import {
  ProdavacGetAllEndpoint,
  ProdavacGetAllResponseProdavac
} from "../../endpoints/prodavac-endpoints/prodavac-get-all-endpoint";


@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './dashboard-admin.component.html',
  styleUrl: './dashboard-admin.component.css'
})
export class DashboardAdminComponent implements OnInit{
  constructor(
    private router : Router,
    private serviserGetAllEndpoint : ServiserGetAllEndpoint,
    private prodavacGetAllEndpoint : ProdavacGetAllEndpoint,
  ) {}


  showServiser:boolean = false;
  serviserPodaci : ServiserGetAllResponseServiseri [] | null = [];
  searchServiser: string = "";

  prodavacPodaci : ProdavacGetAllResponseProdavac [] | null = [];
  showProdavac:boolean = false;
  searchProdavac: string = "";

  jelOtvorenMenu: boolean = true;

  ngOnInit(): void {

  }

  logout() {
  this.router.navigate(["/homepage"])
  }

  fetchServiser() {
    this.serviserGetAllEndpoint.obradi().subscribe({
      next: x=> {
        this.serviserPodaci = x.listaServiser;
        this.showServiser = !this.showServiser;
        this.showProdavac = false;
      },
      error: x=> {}
    })
  }

  fetchProdavac() {
    this.prodavacGetAllEndpoint.obradi().subscribe({
      next: x=> {
        this.prodavacPodaci = x.listaProdavac;
        this.showServiser = false;
        this.showProdavac = !this.showProdavac;
      },
      error: x=> {}
  })
  }


  fetchNalog() {

  }

  dodaj() {
    alert("radi")
  }

  onNoClick() {

  }

  otvoriMenu() {
    this.jelOtvorenMenu = !this.jelOtvorenMenu;
  }

  idiHomepage() {
    this.router.navigate(["/homepage"]);
  }

  softDelete() {

  }

  editServiser() {

  }

  filtrirajServiser() {
    if (this.serviserPodaci == null)
      return [];
    return this.serviserPodaci.filter( x =>
      (x.ime.toLowerCase().startsWith(this.searchServiser.toLowerCase()))||
      (x.prezime.toLowerCase().startsWith(this.searchServiser.toLowerCase()))||
      (x.username.toLowerCase().startsWith(this.searchServiser.toLowerCase()))
    );
  }
  filtrirajProdavac() {
    if (this.prodavacPodaci == null)
      return [];
    return this.prodavacPodaci.filter( x =>
      (x.ime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()))||
      (x.prezime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()))||
      (x.username.toLowerCase().startsWith(this.searchProdavac.toLowerCase()))
    );
  }

}
