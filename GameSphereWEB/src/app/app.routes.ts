import { Routes } from '@angular/router';
import { StoreComponent } from './components/store/store.component';
import { LibraryComponent } from './components/library/library.component';
import { CommunityComponent } from './components/community/community.component';
import { SupportComponent } from './components/support/support.component';
import { ProfileComponent } from './components/profile/profile.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { GameComponent } from './components/store/game/game.component';

export const routes: Routes = [
  // main routes
  { path: '', component: StoreComponent },
  { path: 'store', redirectTo: '' },
  { path: 'library', component: LibraryComponent },
  { path: 'community', component: CommunityComponent },
  { path: 'support', component: SupportComponent },
  { path: 'profile', component: ProfileComponent },

  // routes with children
  { path: '', children: [{ path: 'game/:title', component: GameComponent }] },

  // authentication

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];
