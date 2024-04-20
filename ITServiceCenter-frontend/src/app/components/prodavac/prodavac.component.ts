import {Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ProdavacGetAllEndpoint,
  ProdavacGetAllResponseProdavac
} from "../../endpoints/prodavac-endpoints/prodavac-get-all-endpoint";
import {ProdavacSnimiEndpoint, ProdavacSnimiRequest} from "../../endpoints/prodavac-endpoints/prodavac-snimi-endpoint";
import {GradGetAllEndpoint, GradGetAllResponseGrad} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {ProdavacBrisiEndpoint} from "../../endpoints/prodavac-endpoints/prodavac-brisi-endpoint";
import {ServiserSnimiRequest} from "../../endpoints/serviser-endpoints/serviser-snimi-endpoint";

@Component({
  selector: 'app-prodavac',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './prodavac.component.html',
  styleUrl: './prodavac.component.css'
})
export class ProdavacComponent implements OnInit{
  constructor(
    private prodavacGetAllEndpoint: ProdavacGetAllEndpoint,
    private prodavacSnimiEndpoint: ProdavacSnimiEndpoint,
    private prodavacBrisiEndpoint : ProdavacBrisiEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
  ) {}

  ngOnInit(): void {
    this.fetchProdavac();
    this.fetchGrad();
  }

  showProdavacTable: boolean = true;
  prodavacPodaci: ProdavacGetAllResponseProdavac[] | null = [];
  searchProdavac: string = '';
  editOdabraniProdavac: boolean = false;
  odabraniProdavac: ProdavacSnimiRequest | null = null;
  showNoviProdavacForm: boolean = false;
  noviProdavac : ProdavacSnimiRequest | null = null;

  gradPodaci: GradGetAllResponseGrad[] | null = null;

  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => {},
    });
  }
  fetchProdavac() {
    this.prodavacGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.prodavacPodaci = x.listaProdavac;
      },
      error: (x) => {},
    });
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
  sacuvajProdavac() {
    this.prodavacSnimiEndpoint.obradi(this.odabraniProdavac!).subscribe({
      next: (x: any) => {
        this.editOdabraniProdavac = false;
        this.fetchProdavac();
        this.showProdavacTable = true;
      },
      error: (x: any) => {},
    });
  }
  editProdavac(x: any) {
    this.showProdavacTable = false;
    this.editOdabraniProdavac = true;
    this.odabraniProdavac = x;
  }

  zatvoriProdavacEdit() {
    this.editOdabraniProdavac = false;
    this.fetchProdavac();
  }
  brisiProdavac(id:number) {
    this.prodavacBrisiEndpoint.obradi(id).subscribe({
      next: (x) => {
        this.fetchProdavac();
        this.showProdavacTable = true;
      },
      error: (x) => {},
    });
  }

  dodajNovi() {

  }
}
