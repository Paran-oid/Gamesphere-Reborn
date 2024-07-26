import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { AppUser } from '../../../models/auth/user.model';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
  providers: [AuthService],
})
export class NavbarComponent implements OnInit {
  isLoggedIn: boolean = false;
  user: AppUser | null = null;
  constructor(private authService: AuthService) {}

  ngOnInit() {
    localStorage.getItem('Token')
      ? (this.isLoggedIn = true)
      : (this.isLoggedIn = false);

    this.authService.user.subscribe((user) => {
      this.user = user;
    });
  }

  get UserName() {
    return this.user?.userName;
  }

  Logout() {
    this.authService.Logout();
    window.location.reload();
  }
}
