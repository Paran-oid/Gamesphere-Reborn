import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  Renderer2,
  ViewChild,
} from '@angular/core';
import { StoreComponent } from '../store.component';
import { NavbarComponent } from '../../../shared/components/navbar/navbar.component';
import { StorenavComponent } from '../storenav/storenav.component';
import { Game } from '../../../models/site-models/game-related/game.model';
import { CommonModule } from '@angular/common';
import { GameService } from '../../../services/game.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game',
  standalone: true,
  imports: [StoreComponent, StorenavComponent, CommonModule, CommonModule],
  templateUrl: './game.component.html',
  styleUrl: './game.component.scss',
})
export class GameComponent implements OnInit {
  game!: Game;
  imgDisplayed: number = 0;
  trailerIsAdded: boolean = false;
  pics: string[] = [];

  constructor(
    private gameService: GameService,
    private route: ActivatedRoute,
    private render: Renderer2
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      const title: string = params['title'];
      this.gameService.Get(title.replaceAll('_', ' ')).subscribe({
        next: (response) => {
          this.game = response;
          this.game.picturesPaths = response.picturesPaths.splice(1, 1);
        },
        error: (error) => {
          console.log(error);
        },
      });
    });
  }
}
