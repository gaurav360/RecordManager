import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class RouterService {

  constructor(private route: Router, private location: Location) { }

  routeToDashboard() {
    return this.route.navigate(['dashboard']);
  }

  routeToLogin() {
    return this.route.navigate(['login']);
  }

  routeToRegister() {
    this.route.navigate(['register']);
  }

  routeBack() {
    this.location.back();
  }

  routeToProfile(userId: string) {
    return this.route.navigate(['profile', userId]);
  }

  routeToNoteEdit(noteId: number) {
    return this.route.navigate(['editNote', noteId]);
  }

  routeToNoteAdd(noteId: number) {
    return this.route.navigate(['addNote', noteId]);
  }
}
