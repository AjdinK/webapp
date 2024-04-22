import { Component, OnInit } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ServiserComponent } from '../serviser/serviser.component';
import { ProdavacComponent } from '../prodavac/prodavac.component';
@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    NgOptimizedImage,
    ServiserComponent,
    ProdavacComponent,
  ],
  templateUrl: './dashboard-admin.component.html',
  styleUrl: './dashboard-admin.component.css',
})
export class DashboardAdminComponent implements OnInit {

  constructor(
    private router: Router,
  ) {}


  showServiser: boolean = false;
  showProdavac: boolean = false;

  ngOnInit(): void {}
  logout() {
    this.router.navigate(['/homepage']);
  }

  fetchNalog() {}

  dodaj() {
    alert('radi');
  }

  idiHomepage() {
    this.router.navigate(['/homepage']);
  }

  serviser() {
    this.showServiser = !this.showServiser;
    this.showProdavac = false;
  }
  prodavac() {
    this.showProdavac = !this.showProdavac;
    this.showServiser = false;
  }


}
