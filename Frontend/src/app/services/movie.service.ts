import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IMovieDetail } from '../models/dto';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  readonly apiBase = environment.apiBase;
  constructor(private http: HttpClient) {}

  getMovie(id: string): Observable<IMovieDetail> {
    return this.http.get<IMovieDetail>(`${this.apiBase}/${id}`);
  }

  getMovieList(query: {
    language?: string;
    location?: string;
  }): Observable<IMovieDetail[]> {
    const { language, location } = query;

    let params = new HttpParams();

    if (language) {
      params = params.append('language', language);
    }
    if (location) {
      params = params.append('location', location);
    }

    return this.http.get<IMovieDetail[]>(`${this.apiBase}`, { params });
  }
}
