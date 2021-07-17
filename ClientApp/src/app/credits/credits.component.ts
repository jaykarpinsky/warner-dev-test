import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiResult } from '../base.service';
import { Credit } from './Credit';
import { CreditService } from './credits-service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-credits',
  templateUrl: './credits.component.html',
  styleUrls: ['./credits.component.css']
})
export class CreditsComponent implements OnInit {

  public displayedColumns: string[] = ['roleType', 'name'];
  public credits: MatTableDataSource<Credit>;

  // the title id, as fetched from the active route:
  id?: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private creditService: CreditService) { }

  ngOnInit(): void {

    this.loadCredits();

  }

  loadCredits() {
    // retrieve the ID from the 'id'
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      // fetch all the credits from for this title
      this.creditService
        .getGenresByTitle<ApiResult<Credit>>(+this.id)
        .subscribe(result => {
          this.credits = new MatTableDataSource<Credit>(result.data);
        }, error => console.error(error));
    }
  }

}
