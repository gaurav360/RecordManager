import { Injectable, OnInit } from "@angular/core";
import { User } from '../models/User';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import * as jwt_decode from 'jwt-decode';

export const TOKEN_NAME = 'BearerToken';
export const CURRENT_USER = 'CurrentUser';

@Injectable({
    providedIn: "root"
})
export class AuthenticationService implements OnInit {
    
    private loginUrl = 'http://localhost:64811/auth/login';
    authStateChange = new Subject<boolean>();

    constructor(private httpClient: HttpClient) { }
    
    ngOnInit() { }

    isAuthenticated():boolean {

        var token = this.getToken();
        if (!token) {
            return false;
        }
        
        //**used to decode token
        var decoded = jwt_decode(token);

        if (!decoded.exp) {
            return false;
        }

        var currentTime = new Date(0);
        var expiryTime = new Date(decoded.exp);
        return expiryTime > currentTime;
    }

    login(user:User) : Observable<User>
    {
        return this.httpClient.post<User>(this.loginUrl, user, {observe: 'response'})
        .pipe(map(newresponse => {
                var token = newresponse.headers.get(TOKEN_NAME);
                if (token) {
                    this.setToken(token);
                    localStorage.setItem(CURRENT_USER, newresponse.body.userId);
                    this.authStateChange.next(true);
                }
                return newresponse.body;
            }));
    }

    setToken(token: string) {
        localStorage.setItem(TOKEN_NAME, token);
    }
    getToken() : string {
        return localStorage.getItem(TOKEN_NAME);
    }
    getCurrentUserId()
    {
      return localStorage.getItem(CURRENT_USER);
    }  
    logout()
    {
      localStorage.removeItem(TOKEN_NAME);
      localStorage.removeItem(CURRENT_USER);
      this.authStateChange.next(false);
    }

}
