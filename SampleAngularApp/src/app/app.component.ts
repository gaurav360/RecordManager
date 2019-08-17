import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
import { RouterService } from './services/Router.Service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SampleAngularApp';

  constructor(private authService:AuthenticationService, private routerService:RouterService){}

  logout() {
    this.authService.logout();
    this.routerService.routeToLogin();
  }
}
