import { Component, OnInit } from '@angular/core';
import { Game } from '../../models/site-models/game-related/game.model';
import { AuthService } from '../../services/auth.service';
import { GameService } from '../../services/game.service';
import { CommonModule } from '@angular/common';
import { StorenavComponent } from './storenav/storenav.component';
import { SpinnerComponent } from '../../shared/components/spinner/spinner.component';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { MainStoreComponent } from './main-store/main-store.component';

@Component({
  selector: 'app-store',
  standalone: true,
  imports: [
    CommonModule,
    StorenavComponent,
    SpinnerComponent,
    RouterLink,
    MainStoreComponent,
    RouterOutlet,
  ],
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss',
  providers: [GameService],
})
export class StoreComponent {}
