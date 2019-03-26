import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { EstatesComponent } from './estates/estates.component';

export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'estates', component: EstatesComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'},
];
