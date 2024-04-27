import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ProdavacGetAllEndpoint,
  ProdavacGetAllResponseProdavac,
} from '../../endpoints/prodavac-endpoints/prodavac-get-all-endpoint';
import {
  ProdavacSnimiEndpoint,
  ProdavacSnimiRequest,
} from '../../endpoints/prodavac-endpoints/prodavac-snimi-endpoint';
import {
  GradGetAllEndpoint,
  GradGetAllResponseGrad,
} from '../../endpoints/grad-endpoints/grad-get-all-endpoint';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { ProdavacBrisiEndpoint } from '../../endpoints/prodavac-endpoints/prodavac-brisi-endpoint';
import { ServiserSnimiRequest } from '../../endpoints/serviser-endpoints/serviser-snimi-endpoint';
import { ServiserGetAllResponseServiseri } from '../../endpoints/serviser-endpoints/serviser-get-all-endpoint';

@Component({
  selector: 'app-prodavac',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './prodavac.component.html',
  styleUrl: './prodavac.component.css',
})
export class ProdavacComponent implements OnInit {
  constructor(
    private prodavacGetAllEndpoint: ProdavacGetAllEndpoint,
    private prodavacSnimiEndpoint: ProdavacSnimiEndpoint,
    private prodavacBrisiEndpoint: ProdavacBrisiEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint
  ) {}

  ngOnInit(): void {
    this.fetchProdavac();
    this.fetchGrad();
  }

  JelPopunjeno: boolean = false;

  prodavacPodaci: ProdavacGetAllResponseProdavac[] | null = [];
  gradPodaci: GradGetAllResponseGrad[] | null = null;

  showProdavacTable: boolean = true;
  showProdavacEdit: boolean = false;
  showProdavacForm: boolean = false;
  searchProdavac: string = '';

  formTitle: string = '';

  odabraniProdavac: ProdavacSnimiRequest | null = null;
  noviProdavac: ProdavacSnimiRequest | null = null;

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

  fetchProdavac() {
    this.prodavacGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.prodavacPodaci = x.listaProdavac;
      },
      error: (x) => {
        alert('greska fetchProdavac -> ' + x.error);
      },
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

  snimiProdavac(editForm: NgForm) {
    if (editForm.form.valid) {
      this.prodavacSnimiEndpoint.obradi(this.odabraniProdavac!).subscribe({
        next: (x: any) => {
          this.showProdavacEdit = false;
          this.showProdavacForm = false;
          this.fetchProdavac();
          this.showProdavacTable = true;
        },
        error: (x) => {
          alert('greska snimiProdavac -> ' + x.error);
        },
      });
    }
    this.JelPopunjeno = true;
  }

  editProdavac(x: any) {
    this.formTitle = 'Edit Prodavac';
    this.showProdavacTable = false;
    this.showProdavacEdit = true;
    this.odabraniProdavac = x;
  }

  closeEdit() {
    this.showProdavacEdit = false;
    this.fetchProdavac();
    this.showProdavacTable = true;
    this.showProdavacForm = false;
  }

  brisiProdavac(id: number) {
    if (confirm('Da li zelite izbrisati Prodavaca'))
      this.prodavacBrisiEndpoint.obradi(id).subscribe({
        next: (x) => {
          this.fetchProdavac();
          this.showProdavacTable = true;
        },
        error: (x) => {
          alert('greska brisiProdavac -> ' + x.error);
        },
      });
  }

  dodajNovi() {
    this.formTitle = 'Dodaj Prodavac';
    this.showProdavacForm = true;
    this.showProdavacTable = false;
    this.showProdavacEdit = false;
    this.noviProdavac = {
      id: 0,
      ime: '',
      prezime: '',
      gradID: 1,
      spolID: 1,
      isProdavac: true,
      username: '',
      email: '',
      slikaKorisnikaNovaString: 'Not_Found',
    };
  }

  dodajProdavac(dodajForm: NgForm) {
    if (dodajForm.form.valid) {
      this.prodavacSnimiEndpoint.obradi(this.noviProdavac!).subscribe({
        next: (x: any) => {
          this.showProdavacEdit = false;
          this.fetchProdavac();
          this.showProdavacTable = true;
          this.showProdavacForm = false;
        },
        error: (x) => {
          alert('greska dodajProdavac -> ' + x.error);
        },
      });
    }
    this.JelPopunjeno = true;
  }

  //to show the image in preview box
  generisiPreview() {
    // @ts-ignore
    let file = document.getElementById('slika-input').files[0];
    if (file && this.odabraniProdavac) {
      let reader = new FileReader();
      reader.onload = () => {
        this.odabraniProdavac!.slikaKorisnikaNovaString =
          reader.result?.toString();
      };
      reader.readAsDataURL(file);
    }
  }

  generisiPreviewZaNovi() {
    // @ts-ignore
    let file = document.getElementById('slika-input').files[0];
    if (file && this.noviProdavac) {
      let reader = new FileReader();
      reader.onload = () => {
        this.noviProdavac!.slikaKorisnikaNovaString = reader.result?.toString();
      };
      reader.readAsDataURL(file);
    }
  }

  //to load the image from db and to add the missing part
  showSlikaFromDB() {
    return (
      'data:image/png;base64,' + this.odabraniProdavac!.slikaKorisnikaNovaString
    );
  }
}
