import {Component, OnInit} from "@angular/core";
import {AdminGetByIdEndpoint, AdminGetByIdResponse,} from "../../endpoints/admin-endpoints/admin-get-by-id-endpoint";
import {FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators} from "@angular/forms";
import {NgForOf, NgIf, NgOptimizedImage} from "@angular/common";
import {GradGetAllEndpoint, GradGetAllResponseGrad,} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";
import {AdminSnimiEndpoint, AdminSnimiRequest,} from "../../endpoints/admin-endpoints/admin-snimi-endpoint";
import {ConfigFile} from "../../configFile";
import {FormElementWrapperComponent} from "../reusable/form-element-wrapper/form-element-wrapper.component";


@Component({
  selector: "app-admin",
  standalone: true,
  imports: [FormsModule, NgForOf, NgIf, ReactiveFormsModule, NgOptimizedImage, FormElementWrapperComponent],
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.css", "../../../assets/styles/table_form.css"],
})
export class AdminComponent implements OnInit {
  novaSlika: any;
  showForm: boolean = true;
  adminPodaci: AdminGetByIdResponse | null = null;
  snimiRequest: AdminSnimiRequest | null = null;
  gradPodaci: GradGetAllResponseGrad[] | null = null;
  formTitle: string = "Edit Admin";
  jelPopunjeno: boolean = false;
  adminForm: FormGroup;
  protected readonly ConfigFile = ConfigFile;

  constructor(
    private adminGetByIdEndpoint: AdminGetByIdEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private adminSnimiEndpoint: AdminSnimiEndpoint,
  ) {
    this.adminForm = new FormGroup({
      ime: new FormControl('', [Validators.required, Validators.pattern('[A-Za-z\\sčćžđ]+'), Validators.minLength(3)]),
      prezime: new FormControl('', [Validators.pattern('[A-Za-z\\sčćžđ]+'), Validators.required, Validators.minLength(3)]),
      username: new FormControl('', [Validators.required, Validators.minLength(5), Validators.pattern('[A-Za-z\\sčćžđ]+')]),
    });
  }

  dto(adminPodaciFetch: AdminGetByIdResponse) {
    this.snimiRequest = {
      id: adminPodaciFetch!.id,
      ime: adminPodaciFetch!.ime,
      prezime: adminPodaciFetch!.prezime,
      username: adminPodaciFetch!.username,
      email: adminPodaciFetch!.email,
      lozinka: adminPodaciFetch!.lozinka,
      isAdmin: adminPodaciFetch!.isAdmin,
      isServiser: adminPodaciFetch!.isServiser,
      isProdavac: adminPodaciFetch!.isProdavac,
      gradId: adminPodaciFetch!.gradId,
      slikaKorisnikaBase64: this.novaSlika
    }
  }

  ngOnInit(): void {
    this.fetchAdmin();
    this.fetchGrad();
  }

  //TODO: take the id form-element-wrapper the login admin
  fetchAdmin() {
    this.adminGetByIdEndpoint.obradi(1).subscribe({
      next: (x) => {
        this.adminPodaci = x;
      },
      error: (x) => {
        alert("greska adminGetByIdEndpoint -> " + x.error);
      },
    });
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

  snimi(editForm: NgForm) {
    if (editForm.form.valid) {
      this.dto(this.adminPodaci!);
      this.adminSnimiEndpoint.obradi(this.snimiRequest!).subscribe({
        next: (x) => {
          this.reload();
        },
        error: (x) => {
          alert("Greska, snimi admin : " + x.message);
        },
      });
    }
    this.jelPopunjeno = true;
  }

  close() {
    this.showForm = false;
    this.fetchAdmin();
  }

  onFileSelected(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.novaSlika = event.target.result;
      };
    }
  }

  private reload() {
    this.showForm = false;
    this.fetchAdmin();
    window.location.reload();
  }
}
