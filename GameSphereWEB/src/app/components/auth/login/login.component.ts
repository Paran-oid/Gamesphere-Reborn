import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoginUser } from '../../../models/auth/user.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [AuthService],
})
export class LoginComponent {
  form: FormGroup = new FormGroup({});
  hasSubmitted: boolean = false;
  constructor(private authService: AuthService, private fb: FormBuilder) {}

  ngOnInit() {
    this.form = this.fb.group({
      usernameOrEmail: ['', Validators.required],
      password: ['', Validators.required],
      remember: [false],
    });
  }

  get usernameOrEmail() {
    return this.form.get('usernameOrEmail');
  }

  get password() {
    return this.form.get('password');
  }

  OnSubmit(event: Event) {
    this.hasSubmitted = true;
    event.preventDefault();

    if (this.form.invalid) {
      this.form.markAllAsTouched();
    } else {
      const model: LoginUser = {
        usernameOrEmail: this.usernameOrEmail?.value,
        password: this.password?.value,
      };
      this.authService.Login(model).subscribe({
        next: (response) => {
          console.log('sucess!!');
          console.log(response);
          localStorage.setItem('Token', response.accessToken);
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }
}
