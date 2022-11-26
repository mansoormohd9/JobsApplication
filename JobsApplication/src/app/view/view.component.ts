import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent {
  public jobApplications?: JobApplication[];

  constructor(http: HttpClient) {
    http.get<JobApplication[]>('/jobApplications').subscribe(result => {
      this.jobApplications = result;
    }, error => console.error(error));
  }

  title = 'JobsApplication';
}

interface JobApplication {
  name: string;
  email: number;
  dateOfBirth: number;
  cvBlob: string;
}
