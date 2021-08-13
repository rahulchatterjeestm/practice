import { Component, OnInit } from '@angular/core';
import { IMovieDetail } from '../models/dto';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss'],
})
export class MovieListComponent implements OnInit {
  readonly locations = ['PUNE', 'DELHI', 'BANGALORE', 'CHENNAI'];
  readonly languages = ['HINDI', 'ENGLISH'];

  selectedLanguage?: string;
  selectedLocation?: string;

  movieList?: IMovieDetail[];
  constructor(private movieService: MovieService) {}

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.movieService
      .getMovieList({
        language: this.selectedLanguage,
        location: this.selectedLocation,
      })
      .subscribe((movies) => (this.movieList = movies));
  }
}
