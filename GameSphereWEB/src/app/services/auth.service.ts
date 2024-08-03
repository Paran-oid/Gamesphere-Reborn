import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { AppUser, LoginUser, RegisterUser } from '../models/auth/user.model';
import {
  LoginResponse,
  RegisterResponse,
} from '../models/auth/registration.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  baseUrl: string = environment.url;
  loggedIn: boolean = false;
  public user = new BehaviorSubject<AppUser | null>(null);
  isAdmin: boolean = false;

  constructor(private http: HttpClient) {
    this.InitUser();
  }

  InitUser() {
    const token = localStorage.getItem('Token');
    if (token) {
      this.loggedIn = true;
      this.LoadUser(token).subscribe({
        next: (response) => {
          this.user.next(response);
        },
        error: (response) => {
          console.error('Failed to load user:', response);
        },
      });
    }
  }

  SetUser(user: AppUser | null) {
    this.user.next(user);
  }
  public LoadUser(code: string) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
    return this.http.post<AppUser>(
      this.baseUrl + '/UserRegistration/GetUser',
      JSON.stringify(code),
      httpOptions
    );
  }

  public Login(model: LoginUser) {
    return this.http.post<LoginResponse>(
      this.baseUrl + '/UserRegistration/Login',
      model
    );
  }

  public Logout() {
    localStorage.removeItem('Token');
    this.loggedIn = false;
    this.user.next(null);
    return this.http.get(this.baseUrl + '/UserRegistration/Logout');
  }

  public Register(model: RegisterUser) {
    return this.http.post<RegisterResponse>(
      this.baseUrl + '/UserRegistration/Register',
      model,
      {}
    );
  }

  public IsAdmin(ID: string) {
    const headers = new HttpHeaders({
      id: ID,
    });

    return this.http.get<boolean>(this.baseUrl + '/UserRegistration/IsAdmin', {
      headers: headers,
    });
  }

  public ToggleAdmin(ID: string) {
    const headers = new HttpHeaders({
      id: ID,
    });

    return this.http.get(this.baseUrl + '/UserRegistration/ToggleAdmin', {
      responseType: 'text',
      headers: headers,
    });
  }
}
