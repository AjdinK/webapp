import { Component, OnInit } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {
  ProdavacGetAllEndpoint,
  ProdavacGetAllResponseProdavac,
} from '../../endpoints/prodavac-endpoints/prodavac-get-all-endpoint';
import {
  GradGetAllEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGrad,
} from '../../endpoints/grad-endpoints/grad-get-all-endpoint';
import { ServiserBrisiEndpoint } from '../../endpoints/serviser-endpoints/serviser-brisi-endpoint';
import {
  ProdavacSnimiEndpoint,
  ProdavacSnimiRequest,
} from '../../endpoints/prodavac-endpoints/prodavac-snimi-endpoint';
import {ServiserComponent} from "../serviser/serviser.component";

@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  imports: [CommonModule, FormsModule, NgOptimizedImage, ServiserComponent],
  templateUrl: './dashboard-admin.component.html',
  styleUrl: './dashboard-admin.component.css',
})
export class DashboardAdminComponent implements OnInit {
  constructor(
    private router: Router,

    private prodavacGetAllEndpoint: ProdavacGetAllEndpoint,
    private prodavacSnimiEndpoint: ProdavacSnimiEndpoint
  ) {}





  prodavacPodaci: ProdavacGetAllResponseProdavac[] | null = [];
  showProdavacTable: boolean = false;
  searchProdavac: string = '';
  editOdabraniProdavac: boolean = false;
  odabraniProdavac: ProdavacSnimiRequest | null = null;



  ngOnInit(): void {}

  logout() {
    this.router.navigate(['/homepage']);
  }


  fetchProdavac() {
    this.prodavacGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.prodavacPodaci = x.listaProdavac;
        this.editOdabraniProdavac = false;
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

  // editServiser(x: any) {
  //   this.showServiserTable = false;
  //   this.editOdabraniServiser = true;
  //   this.odabraniServiser = x;
  // }
  showServiser: boolean = false;


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
    // this.editOdabraniServiser = false;
    this.editOdabraniProdavac = false;
    // this.fetchServiser();
  }

  zatvoriProdavacEdit() {
    // this.editOdabraniServiser = false;
    this.editOdabraniProdavac = false;
    this.fetchProdavac();
  }

  editProdavac(x: any) {
    this.showProdavacTable = false;
    this.editOdabraniProdavac = true;
    this.odabraniProdavac = x;
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
  DeleteProdavac(arg0: number) {
    throw new Error('Method not implemented.');
  }

  serviser() {
    this.showServiser = !this.showServiser;
  }

  sacuvajServiser() {

  }
}
