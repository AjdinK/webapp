import { Component, OnInit } from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import { Router } from '@angular/router';
import {
  ServiserGetAllEndpoint,
  ServiserGetAllResponse,
  ServiserGetAllResponseServiseri,
} from '../../endpoints/serviser-endpoints/serviser-get-all-endpoint';
import { FormsModule } from '@angular/forms';
import {
  ProdavacGetAllEndpoint,
  ProdavacGetAllResponseProdavac,
} from '../../endpoints/prodavac-endpoints/prodavac-get-all-endpoint';
import {
  ServiserSnimiEndpoint,
  ServiserSnimiRequest,
} from '../../endpoints/serviser-endpoints/serviser-snimi-endpoint';
import {
  GradGetAllEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGrad,
} from '../../endpoints/grad-endpoints/grad-get-all-endpoint';
import {ServiserBrisiEndpoint} from "../../endpoints/serviser-endpoints/serviser-brisi-endpoint";
import {ProdavacSnimiEndpoint, ProdavacSnimiRequest} from "../../endpoints/prodavac-endpoints/prodavac-snimi-endpoint";

@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  imports: [CommonModule, FormsModule, NgOptimizedImage],
  templateUrl: './dashboard-admin.component.html',
  styleUrl: './dashboard-admin.component.css',
})
export class DashboardAdminComponent implements OnInit {
  constructor(
    private router: Router,
    private serviserGetAllEndpoint: ServiserGetAllEndpoint,
    private prodavacGetAllEndpoint: ProdavacGetAllEndpoint,
    private serviserSnimiEndpoint: ServiserSnimiEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private serviserBrisiEndpoint : ServiserBrisiEndpoint,
    private prodavacSnimiEndpoint: ProdavacSnimiEndpoint,
  ) {}

  showServiserTable: boolean = false;
  serviserPodaci: ServiserGetAllResponseServiseri[] | null = [];
  searchServiser: string = '';
  editOdabraniServiser: boolean = false;
  odabraniServiser: ServiserSnimiRequest | null = null;

  prodavacPodaci: ProdavacGetAllResponseProdavac[] | null = [];
  showProdavacTable: boolean = false;
  searchProdavac: string = '';
  editOdabraniProdavac: boolean = false;
  odabraniProdavac: ProdavacSnimiRequest | null = null;


  gradPodaci: GradGetAllResponseGrad[] | null = null;

  ngOnInit(): void {
    this.fetchGrad();
  }

  logout() {
    this.router.navigate(['/homepage']);
  }

  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => {},
    });
  }

  fetchServiser() {
    this.serviserGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.serviserPodaci = x.listaServiser;
        this.showServiserTable = !this.showServiserTable;
        this.showProdavacTable = false;
        this.editOdabraniProdavac = false;
        this.editOdabraniServiser = false;
      },
      error: (x) => {},
    });
  }

  fetchProdavac() {
    this.prodavacGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.prodavacPodaci = x.listaProdavac;
        this.showServiserTable = false;
        this.editOdabraniProdavac = false;
        this.editOdabraniServiser = false;
        this.showProdavacTable = !this.showProdavacTable;
      },
      error: (x) => {},
    });
  }

  fetchNalog() {}

  dodaj() {
    alert('radi');
  }

  idiHomepage() {
    this.router.navigate(['/homepage']);
  }

  editServiser(x: any) {
    this.showServiserTable = false;
    this.editOdabraniServiser = true;
    this.odabraniServiser = x;
  }

  filtrirajServiser() {
    if (this.serviserPodaci == null) return [];
    return this.serviserPodaci.filter(
      (x) =>
        x.ime.toLowerCase().startsWith(this.searchServiser.toLowerCase()) ||
        x.prezime.toLowerCase().startsWith(this.searchServiser.toLowerCase()) ||
        x.username.toLowerCase().startsWith(this.searchServiser.toLowerCase())
    );
  }
  filtrirajProdavac() {
    if (this.prodavacPodaci == null) return [];
    return this.prodavacPodaci.filter(
      (x) =>
        x.ime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()) ||
        x.prezime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()) ||
        x.username.toLowerCase().startsWith(this.searchProdavac.toLowerCase())
    );
  }

  zatvoriServiserEdit() {
    this.editOdabraniServiser = false;
    this.editOdabraniProdavac = false;
    this.fetchServiser();
  }

  zatvoriProdavacEdit() {
    this.editOdabraniServiser = false;
    this.editOdabraniProdavac = false;
    this.fetchProdavac();
  }

  editProdavac(x: any) {
    this.showProdavacTable = false;
    this.editOdabraniProdavac = true;
    this.odabraniProdavac = x;
  }

  sacuvajServiser() {
    this.serviserSnimiEndpoint.obradi(this.odabraniServiser!).subscribe({
      next: (x: any) => {
        this.editOdabraniServiser = false;
        this.fetchServiser();
      },
      error: (x: any) => {},
    });
  }

  sacuvajProdavac() {
    this.prodavacSnimiEndpoint.obradi(this.odabraniProdavac!).subscribe({
      next: (x: any) => {
        this.editOdabraniProdavac = false;
        this.fetchProdavac();
      },
      error: (x: any) => {},
    });
  }

  DeleteServiser(id:number) {
    this.serviserBrisiEndpoint.obradi(id).subscribe({
      next:x=> {
        this.fetchServiser();
        this.showServiserTable= true;
      },
      error:x=>{
      },
    })

  }

  DeleteProdavac(id:number) {

  }
}
