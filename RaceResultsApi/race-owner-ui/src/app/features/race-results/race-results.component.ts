import { Component, Input } from '@angular/core';
import { ApiService } from '../../core/api.service';
import { RaceResult, RaceNote } from '../../models/types';
import {DatePipe} from '@angular/common';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-race-results',
  standalone: true,
  templateUrl: './race-results.component.html',
  styleUrls: ['./race-results.component.scss'],
  imports: [
    DatePipe,
    FormsModule
  ]
})
export class RaceResultsComponent {
  @Input() results: RaceResult[] = [];

  expandedRowId: number | null = null;
  notesCache = new Map<number, RaceNote[]>();
  newNoteText = '';

  constructor(private api: ApiService) {}

  async toggleNotes(r: RaceResult) {
    this.expandedRowId = this.expandedRowId === r.raceResultId ? null : r.raceResultId;
    if (this.expandedRowId && !this.notesCache.has(r.raceResultId)) {
      const notes = await this.api.getNotes(r.raceResultId).catch(() => [] as RaceNote[]);
      this.notesCache.set(r.raceResultId, notes);
    }
  }

  async addNote(r: RaceResult) {
    const text = this.newNoteText?.trim();
    if (!text) return;
    const saved = await this.api.addNote(r.raceResultId, text);
    const list = this.notesCache.get(r.raceResultId) ?? [];
    list.unshift(saved);
    this.notesCache.set(r.raceResultId, list);
    this.newNoteText = '';
  }

  trackById = (_: number, r: RaceResult) => r.raceResultId;
}
