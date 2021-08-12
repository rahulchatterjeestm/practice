import { Component, OnInit } from '@angular/core';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.movieService.getMovie("tt0295297").subscribe(console.log);
  }

}
