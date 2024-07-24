import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

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
  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.isLoggedIn.subscribe((status: boolean) => {
      this.isLoggedIn = status;
    });
  }

  Logout() {
    this.authService.Logout();
  }

  // dropdownShown: boolean = false;
  // input: string = '';

  // HidePlaceholder(event: Event) {
  //   let input = event.target as HTMLInputElement;
  //   if (input.value === '') {
  //     input.classList.remove('hidden-placeholder');
  //   } else {
  //     input.classList.add('hidden-placeholder');
  //   }
  // }

  // toggleMenu() {
  //   this.dropdownShown = !this.dropdownShown;
  // }
  // clickedOutside() {
  //   this.dropdownShown = false;
  // }
}
