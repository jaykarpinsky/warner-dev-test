import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StorylineService } from './storyline-service';
import { Storyline } from './Storyline';
import { ApiResult } from '../base.service';

@Component({
  selector: 'app-storyline',
  templateUrl: './storyline.component.html',
  styleUrls: ['./storyline.component.css']
})
export class StorylineComponent implements OnInit {

  defaultFilterColumn: string = "titleName";
  filterQuery: string = null;

  // the title id, as fetched from the active route:
  id?: string;

  // the storyline object
  storyline: Storyline;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private storylineService: StorylineService) { }

  ngOnInit(): void {

    this.loadStoryline();
  }

  loadStoryline() {
    // retrieve the ID from the 'id'
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      // fetch all the awards from for this title
      this.storylineService
        .getStorylineByTitle(+this.id)
        .subscribe(result => {
          this.storyline = result;
        }, error => console.error(error));
    }
  }

}
