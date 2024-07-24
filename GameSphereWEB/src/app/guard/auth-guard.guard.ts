import { CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const authGuardGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  if (authService.loggedIn) {
    return true;
  } else {
    return false;
  }
};
