import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { EstatesComponent } from './estates/estates.component';
import { Estate_agentsComponent } from './estate_agents/estate_agents.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolve } from './_resolvers/member-detail.resolver';
import { MemberListResolve } from './_resolvers/member-list.resolver';

export const appRoutes: Routes = [
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
        ]
    },
    {path: 'register', component: RegisterComponent},
    {path: 'estates', component: EstatesComponent},
    {path: 'estate_agents', component: Estate_agentsComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'},
];
