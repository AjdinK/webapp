import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ProdavacGetAllEndpoint,
  ProdavacGetAllResponse,
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

  currentPage: number = 1;
  JelPopunjeno: boolean = false;

  prodavacPodaci: ProdavacGetAllResponse | null = null;
  gradPodaci: GradGetAllResponseGrad[] | null = null;

  showProdavacTable: boolean = true;
  showProdavacEdit: boolean = false;
  showProdavacForm: boolean = false;
  searchProdavac: string = '';

  odabraniProdavac: ProdavacSnimiRequest | null = null;
  noviProdavac: ProdavacSnimiRequest | null = null;
  formTitle: string = '';

  //fetch Prodavac data from db
  fetchProdavac() {
    this.prodavacGetAllEndpoint.obradi(this.currentPage!).subscribe({
      next: (x) => {
        this.prodavacPodaci = x;
      },
      error: (x) => {
        alert('greska -> ' + x.error);
      },
    });
  }

  //search for Prodavac using ime , prezime or username
  filtrirajProdavac() {
    if (this.prodavacPodaci == null) return [];
    return this.prodavacPodaci.listaProdavac.filter(
      (x) =>
        x.ime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()) ||
        x.prezime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()) ||
        x.username.toLowerCase().startsWith(this.searchProdavac.toLowerCase())
    );
  }

  //save Prodavac data from the form and check the form if is it valid? or not
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

  //soft delete the user from the data
  brisiProdavac(id: number) {
    if (confirm('Da li zelite izbrisati Prodavac'))
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

  //show the edit form and hide the data table when press on edit button
  editProdavac(x: any) {
    this.formTitle = 'Edit Prodavac';
    this.showProdavacEdit = true;
    this.odabraniProdavac = x;
    this.showProdavacTable = false;
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

  //close the edit form and show the data table refreshed when press on zatvori button
  closeEdit() {
    this.showProdavacEdit = false;
    this.fetchProdavac();
    this.showProdavacTable = true;
    this.showProdavacForm = false;
  }

  //adding new Prodavac and show the form
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
      slikaKorisnikaNovaString: '',
    };
  }

  //save Prodavac data from the form and check the data if is it valid? or not
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
          alert('greska snimiProdavac -> ' + x.error);
        },
      });
    }
    this.JelPopunjeno = true;
  }

  //to show the image in preview box for the edit form
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

  //to show the image in preview box for the new user
  generisiPreviewZaNovi() {
    // @ts-ignore
    let file = document.getElementById('slika-input_1').files[0];
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

  pageNumbersArray(): number[] {
    let rez = [];
    for (let i = 0; i < this.totalPages(); i++) {
      rez.push(i + 1);
    }
    return rez;
  }

  private totalPages() {
    if (this.prodavacPodaci != null) return this.prodavacPodaci?.totalPages;

    return 1;
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.fetchProdavac();
  }

  goToPrev(p: number) {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.fetchProdavac();
    }
    if (p == this.currentPage) return;
  }
  goToNext(p: number) {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++;
      this.fetchProdavac();
    }
    if (p == this.currentPage) return;
  }
}
