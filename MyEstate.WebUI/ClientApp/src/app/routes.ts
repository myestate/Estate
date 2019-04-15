import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { EstatesComponent } from './estates/estates-list/estates.component';
import { EstatesDetailComponent } from './estates/estates-detail/estates-detail.component';
import { Estate_agentsComponent } from './estate_agent/estate_agentsList/estate_agents.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolve } from './_resolvers/member-detail.resolver';
import { MemberListResolve } from './_resolvers/member-list.resolver';
import { SellingComponent } from './selling/selling.component';
import { RentComponent } from './rent/rent.component';
import { Daily_rentComponent } from './daily_rent/daily_rent.component';
import { Add_estateComponent } from './add_estate/add_estate.component';
import { MapComponent } from './map/map.component';
import { RegisterAsAgentComponent } from './registerAsAgent/registerAsAgent.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'home', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'messages', component: MessagesComponent},
            {path: 'members', component: MemberListComponent,
                resolve: {users: MemberListResolve}},
            {path: 'members/:id', component: MemberDetailComponent,
                resolve: {user: MemberDetailResolve}},
            {path: 'add_estate', component: Add_estateComponent},
            {path: 'registerAsAgent', component: RegisterAsAgentComponent}
            
        ]
    },
    {path: 'register', component: RegisterComponent},
    {path: 'estates', component: EstatesComponent },
    {path: 'estates-detail/:id', component: EstatesDetailComponent},
    {path: 'estate_agent/estate_agentsList', component: Estate_agentsComponent},
    {path: 'selling', component: SellingComponent},
    {path: 'rent', component: RentComponent},
    {path: 'daily-rent', component: Daily_rentComponent},
    {path: 'estate_agents', component: Estate_agentsComponent},
    {path: 'map', component: MapComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'},
];
