import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { first } from 'rxjs';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit {
  step: number = 1;
  form: FormGroup = new FormGroup({});
  hasErrors: boolean = false;

  constructor(private fb: FormBuilder) {}

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
      // Validation for making sure both are same
      confirmPassword: ['', Validators.required],
    });
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
          // Finish with error display
        }
      }
      this.step++;
    }
  }
}
