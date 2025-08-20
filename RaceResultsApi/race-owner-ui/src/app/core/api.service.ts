import { Injectable } from '@angular/core';
import axios from 'axios';
import { Horse, RaceResult, RaceNote } from '../models/types';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private base = '/api';

  async getHorses(): Promise<Horse[]> {
    const { data } = await axios.get(`${this.base}/horses`);
    return data;
  }

  async getResultsForHorse(horseId: number): Promise<RaceResult[]> {
    const { data } = await axios.get(`${this.base}/horses/${horseId}/results`);
    return data;
  }

  async getNotes(resultId: number): Promise<RaceNote[]> {
    const { data } = await axios.get(`${this.base}/results/${resultId}/notes`);
    return data;
  }

  async addNote(resultId: number, noteText: string): Promise<RaceNote> {
    const payload = { noteText };
    const { data } = await axios.post(`${this.base}/results/${resultId}/notes`, payload);
    return data;
  }
}
