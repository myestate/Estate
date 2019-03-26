import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { EstatesComponent } from './estates/estates.component';
import { Estate_agentsComponent } from './estate_agents/estate_agents.component';

export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'estates', component: EstatesComponent},
    {path: 'estate_agents', component: Estate_agentsComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'},
];
