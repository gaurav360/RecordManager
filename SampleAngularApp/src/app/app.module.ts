import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./login/login.component";
import { AppRoutingModule } from "./app-routing.module";
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationService } from './services/authentication.service';
import { TokenInterceptor } from './services/token-interceptor';
import { RegisterComponent } from './register/register.component';
import { UserService } from './services/user.service';
import { MySecureService } from './services/mysecure.service';
import { RouterService } from './services/Router.Service';

@NgModule({
  declarations: [AppComponent, LoginComponent, DashboardComponent, RegisterComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [AuthenticationService, UserService, MySecureService, RouterService,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
