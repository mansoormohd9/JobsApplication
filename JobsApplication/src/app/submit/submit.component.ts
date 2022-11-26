import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { JobApplicationSave } from '../models';

@Component({
  selector: 'app-submit',
  templateUrl: './submit.component.html',
  styleUrls: ['./submit.component.css']
})
export class SubmitComponent {
  public fileData: any;

  constructor(private httpClient: HttpClient) { }

  uploadFile = (data: any) => {
    console.log(data);
    this.fileData = <File>data.target.files[0];
  }
  
  submitApplicant = (e: any) => {
    const formData = new FormData();
    formData.append('Name', e.name);
    formData.append('Email', e.email);
    formData.append('DateOfBirth', e.dateOfBirth);
    formData.append('CvBlob', this.fileData);
    console.log(e)
    e.cvBlob = this.fileData;
    this.httpClient.post('api/jobApplications', formData).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
}
