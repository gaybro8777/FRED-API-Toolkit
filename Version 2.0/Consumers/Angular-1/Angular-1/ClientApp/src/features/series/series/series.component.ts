import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ISeries, ISeriesContainer } from '../../../fredapi/series/series.interfaces';
import { IContainerExtensions } from '../../../fredapi/shared/shared.interfaces';

@Component({
  selector: 'series',
  templateUrl: './series.component.html'
})
export class SeriesComponent implements OnInit {

  heading: string = "Series";

  // request arguments
  seriesId: string;

  // response
  response: IContainerExtensions;
  container: ISeriesContainer;
  seriess: ISeries[];

  constructor(
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.paramMap.subscribe(data => {
      this.seriesId = data.get("id");
    });
    this.route.data.subscribe(
      data => {
        this.parseData(data['series']);
      }
    );
  }

  parseData(data) {
    console.log(data);
    this.response = data;
    this.container = data.container;
    this.seriess = data.container && data.container.seriess;
  }

  onSubmit() {
    this.router.navigate(["/series/" + this.seriesId]);
  }

}
