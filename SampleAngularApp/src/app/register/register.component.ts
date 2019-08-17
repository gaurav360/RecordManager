import { Component, OnInit } from '@angular/core';
import { User } from '../models/User';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: User;
  submitMessage: string;
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.user = new User();
  }
  register() {
    this.user.addedDate = new Date(0);

      this.userService.registerUser(this.user).subscribe(u => {
        this.submitMessage = null;
        alert('User successfully registered');
      },
      err => {
        if(err.status === 409)
        {
          this.submitMessage = "User id already exists";
        }
        else{
          this.submitMessage = 'Error registering user';
        }
      });
  }

  closeAlert() {
    this.submitMessage = null;
  }
}
