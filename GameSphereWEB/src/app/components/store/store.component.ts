import { Component, OnInit } from '@angular/core';
import { Game } from '../../models/site-models/game-related/game.model';
import { AuthService } from '../../services/auth.service';
import { GameService } from '../../services/game.service';
import { CommonModule } from '@angular/common';
import { StorenavComponent } from './storenav/storenav.component';
import { SpinnerComponent } from '../../shared/components/spinner/spinner.component';

@Component({
  selector: 'app-store',
  standalone: true,
  imports: [CommonModule, StorenavComponent, SpinnerComponent],
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss',
  providers: [GameService],
})
export class StoreComponent implements OnInit {
  games: Game[] = [];
  filteredGames: Game[] = [];
  submitted: boolean = false;

  constructor(private gameService: GameService) {}

  ngOnInit() {
    this.gameService.GetAll().subscribe({
      next: (response) => {
        this.games = response;
        this.filteredGames = response;
      },
    });
  }

  Search(query: string) {
    console.log(query);
    if (query != '') {
      if (query === 'free') {
        this.filteredGames = this.games.filter((g) => g.price === 0);
      } else if (query === 'trending') {
        // make this logic another time
        this.filteredGames = this.games;
      } else {
        this.filteredGames = this.games.filter((g) =>
          g.title.toLowerCase().includes(query.toLowerCase())
        );
      }
    } else {
      this.filteredGames = [...this.games];
    }
    this.submitted = true;
  }
}
