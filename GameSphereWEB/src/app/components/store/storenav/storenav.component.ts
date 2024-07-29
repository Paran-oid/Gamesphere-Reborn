import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-storenav',
  standalone: true,
  imports: [MatIconModule, FormsModule, CommonModule, RouterLink],
  templateUrl: './storenav.component.html',
  styleUrl: './storenav.component.scss',
})
export class StorenavComponent {
  query: string = '';
  @Output() searchEvent: EventEmitter<string> = new EventEmitter();

  OnSearch(optional?: string) {
    if (optional) {
      this.searchEvent.emit(optional);
      return;
    }
    this.searchEvent.emit(this.query);
  }
}
