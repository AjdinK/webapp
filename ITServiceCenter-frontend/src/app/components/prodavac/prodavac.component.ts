import {Component, OnInit} from "@angular/core";
import {CommonModule} from "@angular/common";
import {
  ProdavacGetAllEndpoint,
  ProdavacGetAllResponse,
} from "../../endpoints/prodavac-endpoints/prodavac-get-all-endpoint";
import {ProdavacSnimiEndpoint, ProdavacSnimiRequest,} from "../../endpoints/prodavac-endpoints/prodavac-snimi-endpoint";
import {GradGetAllEndpoint, GradGetAllResponseGrad,} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";
import {FormsModule, NgForm, ReactiveFormsModule} from "@angular/forms";
import {ProdavacBrisiEndpoint} from "../../endpoints/prodavac-endpoints/prodavac-brisi-endpoint";
import {ConfigFile} from "../../configFile";
import {ProdavacDodajEndpoint, ProdavacDodajRequest} from "../../endpoints/prodavac-endpoints/prodavac-dodaj-endpoint";
import {FormElementWrapperComponent} from "../reusable/form-element-wrapper/form-element-wrapper.component";

@Component({
  selector: "app-prodavac",
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, FormElementWrapperComponent],
  templateUrl: "./prodavac.component.html",
  styleUrls: ["./prodavac.component.css", "../../../assets/styles/table_form.css"],
})
export class ProdavacComponent implements OnInit {
  currentPage: number = 1;
  jelPopunjeno: boolean = false;
  novaSlikaProdavac: any = null;
  opcionalnaLozinka: string = "";
  prodavacPodaci: ProdavacGetAllResponse | null = null;
  gradPodaci: GradGetAllResponseGrad[] | null = null;
  showProdavacTable: boolean = true;
  showProdavacEdit: boolean = false;
  showProdavacForm: boolean = false;
  searchProdavac: string = "";
  odabraniProdavac: ProdavacSnimiRequest | null = null;
  noviProdavac: ProdavacDodajRequest | null = null;
  formTitle: string = "";
  protected readonly ConfigFile = ConfigFile;

  constructor(
    private prodavacGetAllEndpoint: ProdavacGetAllEndpoint,
    private prodavacSnimiEndpoint: ProdavacSnimiEndpoint,
    private prodavacBrisiEndpoint: ProdavacBrisiEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private prodavacDodajEndpoint: ProdavacDodajEndpoint,
  ) {
  }

  ngOnInit(): void {
    this.fetchProdavac();
    this.fetchGrad();
  }

  fetchProdavac() {
    this.prodavacGetAllEndpoint.obradi(this.currentPage!).subscribe({
      next: (x) => {
        this.prodavacPodaci = x;
      },
      error: (x) => {
        alert("greska -> " + x.error);
      },
    });
  }

  filtrirajProdavac() {
    if (this.prodavacPodaci == null) return [];
    return this.prodavacPodaci.listaProdavac.filter(
      (x) =>
        x.ime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()) ||
        x.prezime.toLowerCase().startsWith(this.searchProdavac.toLowerCase()) ||
        x.username.toLowerCase().startsWith(this.searchProdavac.toLowerCase())
    );
  }

  snimiProdavac(editForm: NgForm) {

    if (this.opcionalnaLozinka != null) {
      this.odabraniProdavac!.lozinka = this.opcionalnaLozinka;
    }
    if (editForm.form.valid) {
      this.odabraniProdavac!.slikaKorisnikaBase64 = this.novaSlikaProdavac;

      this.prodavacSnimiEndpoint.obradi(this.odabraniProdavac!).subscribe({
        next: (x: any) => {
          this.showProdavacEdit = false;
          this.showProdavacForm = false;
          this.fetchProdavac();
          this.showProdavacTable = true;
          window.location.reload();
        },
        error: (x) => {
          alert("greska snimiProdavac ovdje -> " + x.error);
        },
      });
    }
    this.jelPopunjeno = true;
  }

  brisiProdavac(id: number) {
    if (confirm("Da li zelite izbrisati Prodavac"))
      this.prodavacBrisiEndpoint.obradi(id).subscribe({
        next: (x) => {
          this.fetchProdavac();
          this.showProdavacTable = true;
        },
        error: (x) => {
          alert("greska brisiProdavac -> " + x.error);
        },
      });
  }

  editProdavac(x: any) {
    this.formTitle = "Edit Prodavac";
    this.showProdavacEdit = true;
    this.odabraniProdavac = x;
    this.showProdavacTable = false;
  }

  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => {
        alert("greska fetchGrad -> " + x.error);
      },
    });
  }

  closeEdit() {
    this.showProdavacEdit = false;
    this.fetchProdavac();
    this.showProdavacTable = true;
    this.showProdavacForm = false;
  }

  dodajNovi() {
    this.formTitle = "Dodaj Prodavac";
    this.showProdavacForm = true;
    this.showProdavacTable = false;
    this.showProdavacEdit = false;
    this.noviProdavac = {
      id: 0,
      ime: "",
      prezime: "",
      gradID: 1,
      spolID: 1,
      isProdavac: true,
      username: "",
      email: "",
      slikaKorisnikaBase64: "",
      lozinka: "",
    };
  }

  dodajProdavac(dodajForm: NgForm) {
    if (dodajForm.form.valid) {
      this.noviProdavac!.slikaKorisnikaBase64 = this.novaSlikaProdavac;
      this.prodavacDodajEndpoint.obradi(this.noviProdavac!).subscribe({
        next: (x: any) => {
          this.reloadDodaj();
        },
        error: (x) => {
          alert("greska snimiProdavac: " + x.message);
        },
      });
    }
    this.jelPopunjeno = true;
  }

  reloadDodaj() {
    this.showProdavacForm = false;
    this.fetchProdavac();
    window.location.reload();
  }

  onFileSelected(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.novaSlikaProdavac = event.target.result;
      };
    }
  }

  pageNumbersArray(): number[] {
    let rez = [];
    for (let i = 0; i < this.totalPages(); i++) {
      rez.push(i + 1);
    }
    return rez;
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

  private totalPages() {
    if (this.prodavacPodaci != null) return this.prodavacPodaci?.totalPages;
    return 1;
  }
}
