import { Component, OnInit } from '@angular/core';
import { Title } from './title';
import { TitleService } from './title.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-title-details',
  templateUrl: './title-details.component.html',
  styleUrls: ['./title-details.component.css']
})
export class TitleDetailsComponent implements OnInit {

  // the title object id, as fetched from the active route
  id?: string;

  // the title object to view the details of
  title: Title;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private titleService: TitleService) { }

  ngOnInit(): void {
    this.loadTitleData();
  }

  loadTitleData() {
    // retrieve the ID from the 'id'
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      // fetch the artist from the server
      this.titleService.get<Title>(+this.id).subscribe(result => {
        this.title = result;
      }, error => console.error(error));
    }
  }

}
