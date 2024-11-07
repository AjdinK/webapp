import { NgIf } from "@angular/common";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { TranslateModule } from "@ngx-translate/core";
import {Router} from "@angular/router";

@Component({
  selector: "app-search-bar",
  standalone: true,
  imports: [FormsModule, NgIf, TranslateModule],
  templateUrl: "./search-bar.component.html",
  styleUrl: "./search-bar.component.css",
})
export class SearchBarComponent {
  constructor(private  router : Router) {}

  jelPopunjeno: boolean = false;

  pretregaObj: any = {
    id: 0,
    sifra: "",
  };
  pretrega() {
    this.router.navigate(['/search-page']);
    this.jelPopunjeno = true;
    throw new Error("Method not implemented.");
  }
}
