import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterOutlet, RouterModule } from "@angular/router";
import { HomepageComponent } from "./components/homepage/homepage.component";
import { LoginComponent } from "./components/login/login.component";
import { DashboardAdminComponent } from "./components/dashboard-admin/dashboard-admin.component";
import { FormsModule } from "@angular/forms";
import { HeaderComponent } from "./components/homepage/header/header.component";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    RouterModule,
    HomepageComponent,
    LoginComponent,
    DashboardAdminComponent,
    FormsModule,
    HeaderComponent,
  ],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  title = "ITServiceCenter";
}
