import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { first } from 'rxjs';
import { Countries } from '../../../models/misc/country.model';
import { countries } from '../../../services/data/country-date-store';
import { AuthService } from '../../../services/auth.service';
import { RegisterUser } from '../../../models/auth/user.model';
import { Router } from '@angular/router';
import { Capitalize } from '../../../utilities/functions/Capitalize';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  providers: [AuthService],
})
export class RegisterComponent implements OnInit {
  step: number = 1;
  form: FormGroup = new FormGroup({});
  hasErrors: boolean = false;

  countries!: Countries[];

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      fname: ['', Validators.required],
      lname: ['', Validators.required],
      // Make validation for allowed dates
      birth: ['', Validators.required],
      location: ['', Validators.required],
      username: ['', [Validators.required, Validators.minLength(4)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: [''],
      tos: [false, Validators.required],
    });

    this.countries = countries;
  }

  get fname() {
    return this.form.get('fname');
  }

  get lname() {
    return this.form.get('lname');
  }

  get birth() {
    return this.form.get('birth');
  }

  get location() {
    return this.form.get('location');
  }

  get username() {
    return this.form.get('username');
  }

  get email() {
    return this.form.get('email');
  }

  get password() {
    return this.form.get('password');
  }

  get confirmPassword() {
    return this.form.get('confirmPassword');
  }

  get tos() {
    return this.form.get('tos');
  }

  FormBefore() {
    this.step--;
    console.log(this.step);
  }

  FormNext(event: Event) {
    const id = parseInt((event.target as HTMLButtonElement).id);
    if (id === 1) {
      const model = {
        fname: this.fname?.value,
        lname: this.lname?.value,
        birth: this.birth?.value,
        location: this.location?.value,
      };
      for (let value of Object.values(model)) {
        if (value === '') {
          this.hasErrors = true;
          return;
        }
      }
      this.hasErrors = false;
      this.step++;
    } else if (id === 2) {
      const model = {
        username: this.username?.value,
        email: this.email?.value,
        password: this.password?.value,
        confirmPassword: this.confirmPassword?.value,
        tos: this.tos?.value,
      };

      for (let value of Object.values(model)) {
        if (value === '' || value === false) {
          this.hasErrors = true;
          return;
        }
      }
      const newUser: RegisterUser = {
        fname: Capitalize(this.fname?.value),
        lname: Capitalize(this.lname?.value),
        birth: this.birth?.value,
        location: this.location?.value,
        userName: this.username?.value,
        email: this.email?.value,
        password: this.password?.value,
      };

      this.authService.Register(newUser).subscribe({
        next: (response) => {
          this.form.reset();
          localStorage.setItem('Token', response.accessToken);
          this.router.navigate(['/']).then(() => {
            window.location.reload();
            this.router.navigate(['/']);
          });
        },
        error: (error: any) => {
          const message = error.error;
          console.log(message);
          if (message === 'Email already exists.') {
            this.email?.setErrors({ exists: true });
          } else if (message === 'Username already exists.') {
            this.username?.setErrors({ exists: true });
          }
          console.log(error);
        },
      });
    }
  }
}
