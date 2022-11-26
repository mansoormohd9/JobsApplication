import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SubmitComponent } from './submit/submit.component';
import { ViewComponent } from './view/view.component';

const routes: Routes = [
  {path: "", pathMatch:  "full",redirectTo:  "/home"},
  { path: 'home', component: HomeComponent },
  { path: 'submit', component: SubmitComponent },
  { path: 'view', component: ViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }