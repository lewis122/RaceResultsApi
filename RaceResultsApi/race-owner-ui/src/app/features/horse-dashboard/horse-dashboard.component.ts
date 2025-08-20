import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../core/api.service';
import { Horse, RaceResult } from '../../models/types';
import {SlicePipe} from '@angular/common';
import {RaceResultsComponent} from '../race-results/race-results.component';

type JockeyStat = {
  jockeyId: number;
  jockeyName: string;
  runs: number;
  wins: number;
  places: number;           // Top 3
  avgPos: number;
  avgBeaten?: number;
  score: number;            // simple composite
};

@Component({
  selector: 'app-horse-dashboard',
  standalone: true,
  templateUrl: './horse-dashboard.component.html',
  styleUrls: ['./horse-dashboard.component.scss'],
  imports: [
    SlicePipe,
    RaceResultsComponent
  ]
})
export class HorseDashboardComponent implements OnInit {
  horses: Horse[] = [];
  selectedHorseId: number | null = null;
  loading = false;

  results: RaceResult[] = [];
  jockeyTable: JockeyStat[] = [];

  constructor(private api: ApiService) {}

  async ngOnInit() {
    this.horses = await this.api.getHorses();
  }

  async onSelectHorse(horseIdStr: string) {
    this.selectedHorseId = +horseIdStr || null;
    if (!this.selectedHorseId) return;
    this.loading = true;
    try {
      this.results = await this.api.getResultsForHorse(this.selectedHorseId);
      this.jockeyTable = this.computeJockeyStats(this.results).sort((a,b) => b.score - a.score);
    } finally {
      this.loading = false;
    }
  }

  private computeJockeyStats(results: RaceResult[]): JockeyStat[] {
    const map = new Map<number, JockeyStat>();
    for (const r of results) {
      const id = r.jockeyId;
      const name = r.jockey?.name ?? `Jockey ${id}`;
      if (!map.has(id)) {
        map.set(id, { jockeyId: id, jockeyName: name, runs: 0, wins: 0, places: 0, avgPos: 0, avgBeaten: 0, score: 0 });
      }
      const s = map.get(id)!;
      s.runs += 1;
      if (r.finishingPosition === 1) s.wins += 1;
      if (r.finishingPosition <= 3) s.places += 1;
      s.avgPos += r.finishingPosition;
      if (typeof r.distanceBeaten === 'number') s.avgBeaten = (s.avgBeaten ?? 0) + r.distanceBeaten;
    }

    // finalize
    const arr: JockeyStat[] = [];
    for (const s of map.values()) {
      s.avgPos = +(s.avgPos / s.runs).toFixed(2);
      if (typeof s.avgBeaten === 'number') s.avgBeaten = +(s.avgBeaten / s.runs).toFixed(2);
      // Simple score: prioritize wins & places, then lower avg pos / beaten
      const winPct = s.wins / s.runs;
      const placePct = s.places / s.runs;
      const posTerm = 1 / (s.avgPos || 1);
      const beatenTerm = 1 / ((s.avgBeaten ?? 0.01) + 0.01);
      s.score = +( (winPct*5) + (placePct*2) + (posTerm*1.5) + (beatenTerm*0.5) ).toFixed(4);
      arr.push(s);
    }
    return arr;
  }
}
