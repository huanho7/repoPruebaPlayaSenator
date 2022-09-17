import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { InicioComponent } from './inicio/inicio.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  {path: '', component: InicioComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'inicio', component: InicioComponent}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
