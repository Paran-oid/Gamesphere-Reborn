import { Component, OnInit } from '@angular/core';
import { Game } from '../../models/site-models/game-related/game.model';
import { AuthService } from '../../services/auth.service';
import { GameService } from '../../services/game.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-store',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss',
  providers: [GameService],
})
export class StoreComponent implements OnInit {
  games: Game[] = [];

  constructor(private gameService: GameService) {}

  ngOnInit() {
    this.gameService.GetAll().subscribe({
      next: (response) => {
        this.games = response;
      },
    });
  }
}
