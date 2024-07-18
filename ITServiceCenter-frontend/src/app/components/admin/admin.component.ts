import {Component, OnInit} from "@angular/core";
import {AdminGetByIdEndpoint, AdminGetByIdResponse,} from "../../endpoints/admin-endpoints/admin-get-by-id-endpoint";
import {FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators} from "@angular/forms";
import {NgForOf, NgIf, NgOptimizedImage} from "@angular/common";
import {GradGetAllEndpoint, GradGetAllResponseGrad,} from "../../endpoints/grad-endpoints/grad-get-all-endpoint";
import {AdminSnimiEndpoint, AdminSnimiRequest,} from "../../endpoints/admin-endpoints/admin-snimi-endpoint";
import {ConfigFile} from "../../configFile";
import {HttpClient} from "@angular/common/http";
import {FormElementWrapperComponent} from "../reusable/form-element-wrapper/form-element-wrapper.component";

@Component({
  selector: "app-admin",
  standalone: true,
  imports: [FormsModule, NgForOf, NgIf, ReactiveFormsModule, NgOptimizedImage, FormElementWrapperComponent],
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.css", "../../../assets/styles/table_form.css"],
})
export class AdminComponent implements OnInit {
  novaSlikaAdmin: any;
  showAdminForm: boolean = true;
  adminPodaciFetch: AdminGetByIdResponse | null = null;
  adminPodaciEdit: AdminSnimiRequest | null = null;
  gradPodaci: GradGetAllResponseGrad[] | null = null;
  formTitle: string = "Edit Admin";
  JelPopunjeno: boolean = false;
  adminForm: FormGroup;
  protected readonly ConfigFile = ConfigFile;

  constructor(
    private adminGetByIdEndpoint: AdminGetByIdEndpoint,
    private gradGetAllEndpoint: GradGetAllEndpoint,
    private adminSnimiEndpoint: AdminSnimiEndpoint,
    private httpKlijent: HttpClient
  ) {
    this.adminForm = new FormGroup({
      ime: new FormControl('', [Validators.required, Validators.pattern('[A-Za-z\\sčćžđ]+'), Validators.minLength(3)]),
      prezime: new FormControl('', [Validators.pattern('[A-Za-z\\sčćžđ]+'), Validators.required, Validators.minLength(3)]),
      username: new FormControl('', [Validators.required, Validators.minLength(5), Validators.pattern('[A-Za-z\\sčćžđ]+')]),
    });
  }

  //fetch Admin data form-element-wrapper db

  ngOnInit(): void {
    this.fetchAdmin();
    this.fetchGrad();
  }

  //TODO: take the id form-element-wrapper the login admin
  fetchAdmin() {
    this.adminGetByIdEndpoint.obradi(1).subscribe({
      next: (x) => {
        this.adminPodaciFetch = x;
      },
      error: (x) => {
        alert("greska adminGetByIdEndpoint -> " + x.error);
      },
    });
  }

  //fetch grad data form-element-wrapper db
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

  //save admin data form-element-wrapper the form and check the form if is it valid? or not
  snimi(editForm: NgForm) {
    if (editForm.form.valid) {
      this.adminPodaciFetch!.slikaKorisnikaBase64 = this.novaSlikaAdmin;
      this.adminSnimiEndpoint.obradi(this.adminPodaciFetch!).subscribe({
        next: (x) => {
          this.showAdminForm = false;
          this.fetchAdmin();
          window.location.reload();
        },
        error: (x) => {
          alert("greska snimiAdmin - " + x.error);
        },
      });
    }
    this.JelPopunjeno = true;
  }

  //close and refresh admin data form-element-wrapper db
  closeEdit() {
    this.showAdminForm = false;
    this.fetchAdmin();
  }

  //preview for the uploaded img
  onFileSelected(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.novaSlikaAdmin = event.target.result;
      };
    }
  }
}
