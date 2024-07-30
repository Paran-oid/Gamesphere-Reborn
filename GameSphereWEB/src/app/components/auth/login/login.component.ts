import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoginUser } from '../../../models/auth/user.model';
import { SpinnerComponent } from '../../../shared/components/spinner/spinner.component';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, CommonModule, SpinnerComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [AuthService],
})
export class LoginComponent {
  form: FormGroup = new FormGroup({});
  hasSubmitted: boolean = false;
  httpError: boolean = false;
  isloading: boolean = false;
  buttonContent: string = 'Sign in';

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) {}

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
    this.isloading = true;

    if (this.form.invalid) {
      this.form.markAllAsTouched();
    } else {
      const model: LoginUser = {
        usernameOrEmail: this.usernameOrEmail?.value,
        password: this.password?.value,
      };
      this.authService
        .Login(model)
        .pipe(
          finalize(() => {
            this.isloading = false;
          })
        )
        .subscribe({
          next: (response) => {
            this.form.reset();
            localStorage.setItem('Token', response.accessToken);
            this.router.navigate(['/']).then(() => {
              window.location.reload();
            });
          },
          error: (error: any) => {
            if (error.error === 'Invalid Credentials') {
              this.httpError = true;
            }
            console.log(error);
          },
        });
    }
  }
}
