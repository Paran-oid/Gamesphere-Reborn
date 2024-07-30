import { Component } from '@angular/core';
import { StoreComponent } from '../store.component';
import { NavbarComponent } from '../../../shared/components/navbar/navbar.component';
import { StorenavComponent } from '../storenav/storenav.component';

@Component({
  selector: 'app-game',
  standalone: true,
  imports: [StoreComponent, StorenavComponent],
  templateUrl: './game.component.html',
  styleUrl: './game.component.scss',
})
export class GameComponent {}
