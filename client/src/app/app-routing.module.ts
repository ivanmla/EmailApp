import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ArhivaComponent } from './arhiva/arhiva.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'arhiva', component: ArhivaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
