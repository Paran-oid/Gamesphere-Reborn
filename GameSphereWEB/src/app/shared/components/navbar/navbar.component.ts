import { CommonModule } from '@angular/common';
import { Component, DoCheck, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { AppUser } from '../../../models/auth/user.model';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterModule, CommonModule, MatIconModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
  providers: [AuthService],
})
export class NavbarComponent implements OnInit {
  isLoggedIn: boolean = false;
  user: AppUser | null = null;
  isAdmin: boolean = false;
  constructor(private authService: AuthService) {}

  ngOnInit() {
    localStorage.getItem('Token')
      ? (this.isLoggedIn = true)
      : (this.isLoggedIn = false);

    this.authService.user.subscribe((user) => {
      this.user = user;
      if (user) {
        this.CheckIsAdmin();
      }
    });
  }

  get UserName() {
    return this.user?.userName;
  }

  Logout() {
    this.authService.Logout();
    window.location.reload();
  }

  CheckIsAdmin() {
    this.authService.IsAdmin(this.user?.id!).subscribe({
      next: (response) => {
        this.isAdmin = response;
      },
    });
  }

  ToggleAdmin() {
    this.authService.ToggleAdmin(this.user?.id!).subscribe({
      next: (response) => {
        this.CheckIsAdmin();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
