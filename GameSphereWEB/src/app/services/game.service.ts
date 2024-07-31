import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Game } from '../models/site-models/game-related/game.model';

@Injectable({ providedIn: 'root' })
export class GameService {
  baseUrl = environment.url;
  constructor(private http: HttpClient) {}

  public GetAll() {
    return this.http.get<Game[]>(this.baseUrl + '/Game/GetAll');
  }

  public Get(ID: string) {
    return this.http.get<Game>(this.baseUrl + '/Game/Get/' + ID);
  }
}
