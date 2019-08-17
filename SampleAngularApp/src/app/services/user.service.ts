import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private authUrl = 'http://localhost:64811/auth/register';
  
  constructor(private httpClient: HttpClient) { }

  registerUser(user: User) {
     return this.httpClient.post<boolean>(this.authUrl, user);
  }

  
}