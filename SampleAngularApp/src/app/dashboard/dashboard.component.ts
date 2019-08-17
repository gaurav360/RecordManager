import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { MySecureService } from '../services/mysecure.service';
import { MyRecords } from '../models/myrecords';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {
  private userId: string;
  submitMessage: string;
  records : MyRecords[]
  constructor(private secureService: MySecureService, private authService: AuthenticationService) { }

  ngOnInit() {

    this.userId = this.authService.getCurrentUserId();

    this.refreshRecords();

    // this.secureService.GetAllRecords().subscribe(x => {
    //       if(x)
    //       {
    //         this.refreshRecords();
    //       }
    // });

    this.secureService.recordError.subscribe(x => this.submitMessage = x);
  }

  refreshRecords() {    
    this.secureService.GetAllRecords().subscribe(n => this.records = n,
      e => {
        if(e.status === 401)
        {
          this.authService.logout();
        }
        else
        {
          this.submitMessage = 'Error getting records';
          this.records = [];
        }
      });
  }

}
