import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { JobApplication } from 'src/app/models';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent {
  public jobApplications?: JobApplication[];
  private client: HttpClient;

  constructor(http: HttpClient) {
    this.client = http;
    http.get<JobApplication[]>('api/jobApplications').subscribe(result => {
      this.jobApplications = result;
    }, error => console.error(error));
  }

  downloadFile = (e: Event, fileName: string) => {
    e.preventDefault();
    window.open(`/UploadedFiles/${fileName}`, "_blank");
  }

  deleteApplication = (e:Event, id: number) => {
    e.preventDefault();
    this.client.delete(`api/jobApplications/${id}`).subscribe(() => {
      this.jobApplications = this.jobApplications?.filter(x => x.id != id);
    }, error => console.error(error));
  }

  title = 'JobsApplication';
}
