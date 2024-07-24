import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  user: string | null = null;
  constructor() {}

  get isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }
  Login() {
    this.loggedIn.next(true);
  }
  Logout() {
    this.loggedIn.next(false);
    this.user = null;
  }
}
