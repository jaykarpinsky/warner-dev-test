import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiResult } from '../base.service';
import { Award } from './Award';
import { AwardService } from './awards-service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-awards',
  templateUrl: './awards.component.html',
  styleUrls: ['./awards.component.css']
})
export class AwardsComponent implements OnInit {

  public displayedColumns: string[] = ['awardCompany', 'awardCategory', 'awardWon', 'awardYear'];
  public awards: MatTableDataSource<Award>;

  // the title id, as fetched from the active route:
  id?: string;

  // the genres observable for the select (using async pipe)
  //awards: Observable<ApiResult<Award>>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private awardService: AwardService) { }

  ngOnInit(): void {

    this.loadAwards();

  }

  loadAwards() {
    // retrieve the ID from the 'id'
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      // fetch all the awards from for this title
      this.awardService
        .getGenresByTitle<ApiResult<Award>>(+this.id)
        .subscribe(result => {
          this.awards = new MatTableDataSource<Award>(result.data);
        }, error => console.error(error));
    }
  }

}
