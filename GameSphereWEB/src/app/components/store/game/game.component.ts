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
import { SpinnerComponent } from '../../../shared/components/spinner/spinner.component';
import { MatIconModule } from '@angular/material/icon';
import { AuthService } from '../../../services/auth.service';
import { AppUser } from '../../../models/auth/user.model';

@Component({
  selector: 'app-game',
  standalone: true,
  imports: [
    StoreComponent,
    StorenavComponent,
    CommonModule,
    CommonModule,
    SpinnerComponent,
    MatIconModule,
  ],
  templateUrl: './game.component.html',
  styleUrl: './game.component.scss',
})
export class GameComponent implements OnInit {
  game!: Game;
  trailerDisplayed: boolean = true;
  pics: string[] = [];
  chosen: string = '';
  isLoading: boolean = false;
  user: AppUser | null = null;
  isAdmin: boolean = false;

  @ViewChild('displayed') mediaDisplayed!: ElementRef;

  constructor(
    private gameService: GameService,
    private route: ActivatedRoute,
    private render: Renderer2,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.isLoading = true;
    this.route.params.subscribe((params) => {
      const title: string = params['title'];
      this.gameService.Get(title.replaceAll('_', ' ')).subscribe({
        next: (response) => {
          this.game = response;
          this.game.picturesPaths = response.picturesPaths.filter(
            (i) => i !== response.picturesPaths[0]
          );
          this.isLoading = false;
          console.log(this.authService.isAdmin);
        },
        error: (error) => {
          console.log(error);
        },
      });
    });

    this.authService.user.subscribe((user) => {
      this.user = user;
    });
  }

  IsAdmin() {
    this.authService.IsAdmin(this.user?.id!).subscribe({
      next: (response) => {
        this.isAdmin = response;
      },
    });
  }

  DisplayItem(item: Event) {
    const element = item.target as HTMLElement;
    const display = this.mediaDisplayed.nativeElement as HTMLElement;

    const clonedElement = element.cloneNode(true) as HTMLElement;

    if (clonedElement.tagName === 'VIDEO') {
      display.removeChild(display.children[0]);
      this.trailerDisplayed = true;
      this.chosen = this.game.trailerPath;
      return;
    } else {
      this.trailerDisplayed = false;
    }

    if (display.children.length !== 0) {
      display.removeChild(display.children[0]);
    }

    display.append(clonedElement);
    this.chosen = element.id;
  }

  IsChosen(index: string) {
    return this.chosen === index;
  }
}
