import {Component, OnInit} from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import {Router} from '@angular/router';
import {FormsModule} from '@angular/forms';
import {ServiserComponent} from '../serviser/serviser.component';
import {ProdavacComponent} from '../prodavac/prodavac.component';
import {AdminComponent} from '../admin/admin.component';
import {AuthLogoutEndpoint} from "../../endpoints/auth-endpoints/auth-logout-endpoint";
import {StorageService} from "../../services/storage.service";
import {AuthLogoutRequest} from "../../endpoints/auth-endpoints/auth-logout-request";

@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    NgOptimizedImage,
    ServiserComponent,
    ProdavacComponent,
    AdminComponent,
  ],
  templateUrl: './dashboard-admin.component.html',
  styleUrl: './dashboard-admin.component.css',
})
export class DashboardAdminComponent implements OnInit {
  showServiser: boolean = false;
  showProdavac: boolean = false;
  showAdmin: boolean = false;
  logoutRequest: AuthLogoutRequest;

  constructor(
    private router: Router,
    private authLogoutEndpoint: AuthLogoutEndpoint,
    private storageService: StorageService,
  ) {
    this.logoutRequest = {
      token: this.storageService.getValue('token'),
    };
  }

  ngOnInit(): void {
  }

  logout() {
    JSON.stringify(this.logoutRequest);
    this.authLogoutEndpoint.obradi(this.logoutRequest!).subscribe({
        next: (x: any) => {
          this.storageService.removeToken();
          this.storageService.removeRole();
          this.router.navigate(['']);
        },
        error: (x: any) => {
          alert("greska logout -> " + x.message);
        }
      }
    )
  }

  fetchNalog() {
  }

  idiHomepage() {
    this.router.navigate(['']);
  }

  serviser() {
    this.showServiser = !this.showServiser;
    this.showProdavac = false;
    this.showAdmin = false;
  }

  prodavac() {
    this.showProdavac = !this.showProdavac;
    this.showServiser = false;
    this.showAdmin = false;
  }

  admin() {
    this.showAdmin = !this.showAdmin;
    this.showServiser = false;
    this.showProdavac = false;
  }
}
