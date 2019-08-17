import { Component, OnInit } from '@angular/core';
import { User } from '../models/User';
import { AuthenticationService } from '../services/authentication.service';
import { RouterService } from '../services/Router.Service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  submitMessage: string;
  user: User;

  constructor(private authService: AuthenticationService, private routerService: RouterService) { 

  }

  ngOnInit() {
    this.user = new User();
  }
 
  login(){
    this.authService.login(this.user).subscribe(u => {
      this.routerService.routeToDashboard();
    },
    err => {
      console.log(err);
      if (err.status === 403) {
        this.submitMessage = err.error.message;
      }
      else if(err.status === 404) {
        this.submitMessage = "User name or password incorrect";
      } else {
        this.submitMessage = "Unknown error occured. Please try again later";
      }
    });
  }


}
