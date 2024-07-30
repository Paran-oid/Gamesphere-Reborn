import { Component, OnInit } from '@angular/core';
import { GameService } from '../../../services/game.service';
import { Router, RouterLink } from '@angular/router';
import { Game } from '../../../models/site-models/game-related/game.model';
import { SpinnerComponent } from '../../../shared/components/spinner/spinner.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-main-store',
  standalone: true,
  imports: [SpinnerComponent, CommonModule, RouterLink],
  templateUrl: './main-store.component.html',
  styleUrl: './main-store.component.scss',
})
export class MainStoreComponent implements OnInit {
  games: Game[] = [];
  filteredGames: Game[] = [];
  submitted: boolean = false;

  constructor(private gameService: GameService, private router: Router) {}

  ngOnInit() {
    this.gameService.GetAll().subscribe({
      next: (response) => {
        this.games = response;
        this.filteredGames = response;
      },
    });
  }
}
