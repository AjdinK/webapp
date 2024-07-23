import {Component, OnInit} from "@angular/core";
import {CommonModule, NgOptimizedImage} from "@angular/common";
import {FormsModule, NgForm, ReactiveFormsModule} from "@angular/forms";
import {
  ServiserGetAllEndpoint,
  ServiserGetAllResponse,
} from "../../endpoints/serviser-endpoints/serviser-get-all-endpoint";
import {ServiserSnimiEndpoint, ServiserSnimiRequest,} from "../../endpoints/serviser-endpoints/serviser-snimi-endpoint";
import {ServiserBrisiEndpoint} from "../../endpoints/serviser-endpoints/serviser-brisi-endpoint";
import {GradGetAllEndpoint, GradGetAllResponseGrad,} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";
import {ConfigFile} from "../../configFile";
import {ServiserDodajRequest} from "../../endpoints/serviser-endpoints/serviser-dodaj-endpoint";


@Component({
  selector: "app-serviser",
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, NgOptimizedImage],
  templateUrl: "./serviser.component.html",
  styleUrls: ["./serviser.component.css", "../../../assets/styles/table_form.css"],
})
export class ServiserComponent implements OnInit {
  currentPage: number = 1;
  JelPopunjeno: boolean = false;
  novaSlikaSerivser: any = null;
  opcionalnaLozinka: string = "";
  serviserPodaci: ServiserGetAllResponse | null = null;
  gradPodaci: GradGetAllResponseGrad[] | null = null;
  showServiserTable: boolean = true;
  showServiserEdit: boolean = false;
  showServiserForm: boolean = false;
  searchServiser: string = "";
  odabraniServiser: ServiserSnimiRequest | null = null;
  noviServiser: ServiserSnimiRequest | null = null;
  formTitle: string = "";
  protected readonly ConfigFile = ConfigFile;

  constructor(
    private serviserGetAllEndpoint: ServiserGetAllEndpoint,
    private serviserSnimiEndpoint: ServiserSnimiEndpoint,
    private serviserBrisiEndpoint: ServiserBrisiEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private serviserDodajRequest: ServiserDodajRequest
  ) {
  }

  ngOnInit(): void {
    this.fetchServiser();
    this.fetchGrad();
  }

  fetchServiser() {
    this.serviserGetAllEndpoint.obradi(this.currentPage!).subscribe({
      next: (x) => {
        this.serviserPodaci = x;
      },
      error: (x) => {
        alert("Greska fetchServiser : " + x.message);
      },
    });
  }

  filtrirajServiser() {
    if (this.serviserPodaci == null) return [];
    return this.serviserPodaci.listaServiser.filter(
      (x) =>
        x.ime.toLowerCase().startsWith(this.searchServiser.toLowerCase()) ||
        x.prezime.toLowerCase().startsWith(this.searchServiser.toLowerCase()) ||
        x.username.toLowerCase().startsWith(this.searchServiser.toLowerCase())
    );
  }

  snimiServiser(editForm: NgForm) {

    if (this.opcionalnaLozinka != null) {
      this.odabraniServiser!.lozinka = this.opcionalnaLozinka;
    }
    if (editForm.form.valid) {
      this.odabraniServiser!.slikaKorisnikaBase64 = this.novaSlikaSerivser;
      this.serviserSnimiEndpoint.obradi(this.odabraniServiser!).subscribe({
        next: (x: any) => {
          this.showServiserEdit = false;
          this.showServiserForm = false;
          this.fetchServiser();
          this.showServiserTable = true;
          window.location.reload();
        },
        error: (x) => {
          alert("greska snimiServiser -> " + x.error);
        },
      });
    }
    this.JelPopunjeno = true;
  }

  brisiServiser(id: number) {
    if (confirm("Da li zelite izbrisati Serviser"))
      this.serviserBrisiEndpoint.obradi(id).subscribe({
        next: (x) => {
          this.fetchServiser();
          this.showServiserTable = true;
        },
        error: (x) => {
          alert("greska grisiServiser -> " + x.message);
        },
      });
  }

  editServiser(x: any) {
    this.formTitle = "Edit Serviser";
    this.showServiserEdit = true;
    this.odabraniServiser = x;
    this.showServiserTable = false;
  }

  //fetch grad data form-element-wrapper db
  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => {
        alert("greska fetchGrad -> " + x.message);
      },
    });
  }

  //close the edit form and show the data table refreshed when press on zatvori button
  closeEdit() {
    this.showServiserEdit = false;
    this.fetchServiser();
    this.showServiserTable = true;
    this.showServiserForm = false;
  }

  //adding new serviser and show the form
  dodajNovi() {
    this.formTitle = "Dodaj Serviser";
    this.showServiserForm = true;
    this.showServiserTable = false;
    this.showServiserEdit = false;
    this.noviServiser = {
      id: 0,
      ime: "",
      prezime: "",
      gradID: 1,
      spolID: 1,
      isServiser: true,
      username: "",
      email: "",
      slikaKorisnikaBase64: "",
      lozinka: ""
    };
  }

  dodajServiser(dodajForm: NgForm) {
    if (dodajForm.form.valid) {
      this.noviServiser!.slikaKorisnikaBase64 = this.novaSlikaSerivser;
      this.serviserSnimiEndpoint.obradi(this.noviServiser!).subscribe({
        next: (x: any) => {
          this.showServiserEdit = false;
          this.fetchServiser();
          this.showServiserTable = true;
          this.showServiserForm = false;
          window.location.reload();
        },
        error: (x) => {
          alert("greska snimiServiser -> " + x.message);
        },
      });
    }
    this.JelPopunjeno = true;
  }

  //preview for the uploaded img
  onFileSelected(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.novaSlikaSerivser = event.target.result;
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
    this.fetchServiser();
  }

  goToPrev(p: number) {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.fetchServiser();
    }
    if (p == this.currentPage) return;
  }

  goToNext(p: number) {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++;
      this.fetchServiser();
    }
    if (p == this.currentPage) return;
  }

  private totalPages() {
    if (this.serviserPodaci != null) return this.serviserPodaci?.totalPages;

    return 1;
  }
}
