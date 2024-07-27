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
import {ServiserDodajEndpoint, ServiserDodajRequest} from "../../endpoints/serviser-endpoints/serviser-dodaj-endpoint";


@Component({
  selector: "app-serviser",
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, NgOptimizedImage],
  templateUrl: "./serviser.component.html",
  styleUrls: ["./serviser.component.css", "../../../assets/styles/table_form.css"],
})
export class ServiserComponent implements OnInit {
  currentPage: number = 1;
  jelPopunjeno: boolean = false;
  serviserPodaci: ServiserGetAllResponse | null = null;
  gradPodaci: GradGetAllResponseGrad[] | null = null;
  showServiserTable: boolean = true;
  showServiserEdit: boolean = false;
  showServiserForm: boolean = false;
  searchServiser: string = "";
  odabraniServiser: ServiserSnimiRequest | null = null;
  noviServiser: ServiserDodajRequest | null = null;
  opcionalnaLozinka: string = "";
  formTitle: string = "";
  novaSlika: any = null;
  protected readonly ConfigFile = ConfigFile;

  constructor(
    private serviserGetAllEndpoint: ServiserGetAllEndpoint,
    private serviserSnimiEndpoint: ServiserSnimiEndpoint,
    private serviserBrisiEndpoint: ServiserBrisiEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private serviserDodajEndpoint: ServiserDodajEndpoint,
  ) {
  }

  ngOnInit(): void {
    this.fetchData();
    this.resetPassword();
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
    if (editForm.form.valid) {
      this.odabraniServiser!.slikaKorisnikaBase64 = this.novaSlika;
      this.serviserSnimiEndpoint.obradi(this.odabraniServiser!).subscribe({
        next: (x: any) => {
          this.realodSnimi();
        },
        error: (x) => {
          alert("greska snimiServiser -> " + x.error);
        },
      });
    }
    this.jelPopunjeno = true;
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

  fetchGrad() {
    this.gradGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.gradPodaci = x.gradovi;
      },
      error: (x) => {
        alert("Greska fetchGrad: " + x.message);
      },
    });
  }

  closeEditWindow() {
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
      this.noviServiser!.slikaKorisnikaBase64 = this.novaSlika;
      this.serviserDodajEndpoint.obradi(this.noviServiser!).subscribe({
        next: (x: any) => {
          this.reloadDodaj();
        },
        error: (x) => {
          alert("Greska serviser dodaj : " + x.message);
        },
      });
    }
    this.jelPopunjeno = true;
  }

  //preview for the uploaded img
  onFileSelected(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.novaSlika = event.target.result;
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

  private reloadDodaj() {
    this.showServiserEdit = false;
    this.fetchServiser();
    this.showServiserTable = true;
    this.showServiserForm = false;
    window.location.reload();
  }

  private fetchData() {
    this.fetchServiser();
    this.fetchGrad();
  }

  private resetPassword() {
    this.opcionalnaLozinka = '';
  }

  private realodSnimi() {
    this.showServiserEdit = false;
    this.showServiserForm = false;
    this.fetchServiser();
    this.showServiserTable = true;
    window.location.reload();
  }
}
