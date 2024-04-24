import {Component, OnInit} from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {
  ServiserGetAllEndpoint,
  ServiserGetAllResponseServiseri
} from "../../endpoints/serviser-endpoints/serviser-get-all-endpoint";
import {ServiserSnimiEndpoint, ServiserSnimiRequest} from "../../endpoints/serviser-endpoints/serviser-snimi-endpoint";
import {ServiserBrisiEndpoint} from "../../endpoints/serviser-endpoints/serviser-brisi-endpoint";
import {GradGetAllEndpoint, GradGetAllResponseGrad} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";

@Component({
  selector: 'app-serviser',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, NgOptimizedImage],
  templateUrl: './serviser.component.html',
  styleUrl: './serviser.component.css'
})
export class ServiserComponent implements OnInit{
  constructor(
    private serviserGetAllEndpoint: ServiserGetAllEndpoint,
    private serviserSnimiEndpoint: ServiserSnimiEndpoint,
    private serviserBrisiEndpoint: ServiserBrisiEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
  ) {}

  ngOnInit(): void {
        this.fetchServiser();
        this.fetchGrad();
    }

  serviserPodaci: ServiserGetAllResponseServiseri[] | null = [];
  gradPodaci: GradGetAllResponseGrad[] | null = null;

  showServiserTable: boolean = true;
  showServiserEdit: boolean = false;
  showServiserForm: boolean = false;
  searchServiser: string = '';

  odabraniServiser: ServiserSnimiRequest | null = null;
  noviServiser : ServiserSnimiRequest | null = null;


  fetchServiser() {
    this.serviserGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.serviserPodaci = x.listaServiser;
      },
      error: (x) => { alert("greska -> " + x.error) },
    });
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

  snimiServiser(msg : string) {
    if (msg == "edit"){
      if (confirm("Da li zelite snimiti izmjene"))
    this.serviserSnimiEndpoint.obradi(this.odabraniServiser!).subscribe({
      next: (x: any) => {
        this.showServiserEdit = false;
        this.showServiserForm = false;
        this.fetchServiser();
        this.showServiserTable = true;
      },
      error: (x) => { alert("greska -> " + x.error) },
    });
    }
    else {
      if (confirm("Da li zelite dodati novog Servisera"))
        this.serviserSnimiEndpoint.obradi(this.noviServiser!).subscribe({
        next: (x: any) => {
          this.showServiserEdit = false;
          this.fetchServiser();
          this.showServiserTable = true;
          this.showServiserForm = false;
        },
          error: (x) => { alert("greska -> " + x.error) },
      });
    }
  }

  brisiServiser (id: number) {
    if (confirm("Da li zelite izbrisati Serviser"))
    this.serviserBrisiEndpoint.obradi(id).subscribe({
      next: (x) => {
        this.fetchServiser();
        this.showServiserTable = true;
      },
      error: (x) => { alert("greska -> " + x.error) }
    });
  }

  editServiser(x: any) {
      this.showServiserEdit = true;
      this.odabraniServiser = x;
      this.showServiserTable = false;
  }

  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => { alert("greska -> " + x.error) },
    });
  }

  closeEdit() {
    this.showServiserEdit = false;
    this.fetchServiser();
    this.showServiserTable = true;
    this.showServiserForm = false;
  }

  dodajNovi() {
    this.showServiserForm = true;
    this.showServiserTable = false;
    this.showServiserEdit = false;
    this.noviServiser = {
      id:0,
      ime:'',
      prezime:'',
      gradID:1,
      spolID:1,
      isServiser:true,
      username:'',
      email:'',
      }
    }
}

