export interface Horse { horseId: number; name: string; }
export interface Jockey { jockeyId: number; name: string; }
export interface Race {
  raceId: number;
  raceDate: string;     // ISO date
  raceTime: string;     // HH:mm:ss
  racecourse: string;
  raceDistance: number;
}

export interface RaceNote {
  noteId: number;
  raceResultId: number;
  noteText: string;
  createdAt: string;
}

export interface RaceResult {
  raceResultId: number;
  raceId: number;
  horseId: number;
  jockeyId: number;
  trainerId: number;
  finishingPosition: number;
  distanceBeaten?: number | null;
  timeBeaten?: number | null;
  horse?: Horse;
  jockey?: Jockey;
  race?: Race;
  notes?: RaceNote[];
}
