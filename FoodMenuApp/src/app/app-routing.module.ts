import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ContactComponent } from './components/contact/contact.component';
import { WeeklyMenuComponent } from './components/weekly-menu/weekly-menu.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'Contact', component: ContactComponent},
  {path: 'Menu', component: WeeklyMenuComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
