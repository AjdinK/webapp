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

  showServiserTable: boolean = true;
  serviserPodaci: ServiserGetAllResponseServiseri[] | null = [];
  searchServiser: string = '';
  editOdabraniServiser: boolean = false;
  odabraniServiser: ServiserSnimiRequest | null = null;
  showNoviServiserForm: boolean = false;
  noviServiser : ServiserSnimiRequest | null = null;

  gradPodaci: GradGetAllResponseGrad[] | null = null;

  fetchServiser() {
    this.serviserGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.serviserPodaci = x.listaServiser;
      },
      error: (x) => {},
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

  sacuvajServiser(msg : string) {
    if (msg == "edit"){
      if (confirm("Da li zelite spasiti izmjene"))
    this.serviserSnimiEndpoint.obradi(this.odabraniServiser!).subscribe({
      next: (x: any) => {
        this.editOdabraniServiser = false;
        this.showNoviServiserForm = false;
        this.fetchServiser();
        this.showServiserTable = true;
      },
      error: (x: any) => {},
    });
    }
    else {
      if (confirm("Da li zelite dodati novog Servisera"))
        this.serviserSnimiEndpoint.obradi(this.noviServiser!).subscribe({
        next: (x: any) => {
          this.editOdabraniServiser = false;
          this.fetchServiser();
          this.showServiserTable = true;
          this.showNoviServiserForm = false;
        },
        error: (x: any) => {},
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
      error: (x) => {},
    });
  }

  editServiser(x: any) {
      this.editOdabraniServiser = true;
      this.odabraniServiser = x;
      this.showServiserTable = false;
  }

  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => {},
    });
  }

  zatvoriServiserEdit() {
    this.editOdabraniServiser = false;
    this.fetchServiser();
    this.showServiserTable = true;
    this.showNoviServiserForm = false;
  }

  dodajNovi() {
    this.showNoviServiserForm = true;
    this.showServiserTable = false;
    this.editOdabraniServiser = false;
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

