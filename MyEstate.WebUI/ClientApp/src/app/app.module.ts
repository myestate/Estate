import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ElementRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {BsDropdownModule, TabsModule} from 'ngx-bootstrap';
import { AgmCoreModule, GoogleMapsAPIWrapper, AgmMap } from '@agm/core';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify/Alertify.service';
import { appRoutes } from './routes';
import { EstatesComponent } from './estates/estates-list/estates.component';
import { Estate_agentsComponent } from './estate_agent/estate_agentsList/estate_agents.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user/user.service';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolve } from './_resolvers/member-detail.resolver';
import { MemberListResolve } from './_resolvers/member-list.resolver';
import { Estate_agentsCardComponent } from './estate_agent/estate_agentsCard/estate_agentsCard.component';
import { SellingComponent } from './selling/selling.component';
import { RentComponent } from './rent/rent.component';
import { Daily_rentComponent } from './daily_rent/daily_rent.component';
import { AddEstateComponent } from './add_estate/add_estate.component';
import { environment } from 'src/environments/environment';
import { MapComponent } from './map/map.component';
import { EstateService } from './_services/estate.service';
import { EstatesDetailComponent } from './estates/estates-detail/estates-detail.component';
import { MapService } from './_services/map/map.service';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { UserCabinetComponent } from './user-cabinet/user-cabinet.component';
import { EstateAgentService } from './_services/estateAgent/estateAgent.service';
import { EstateCardComponent } from './estates/estate-card/estate-card.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
     EstatesComponent,
      Estate_agentsComponent,
      Estate_agentsCardComponent,
      MessagesComponent,
      MemberListComponent,
      MemberCardComponent,
      MemberDetailComponent,
      SellingComponent,
      RentComponent,
      Daily_rentComponent,
      AddEstateComponent,
      MapComponent,
      EstateCardComponent,
      EstatesDetailComponent,
      EditProfileComponent,
      UserCabinetComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      }),
      AgmCoreModule.forRoot({
         apiKey: environment.googleMapAPIKey
      })
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      EstateService,
      UserService,
      EstateAgentService,
      MapService,
      MemberDetailResolve,
      MemberListResolve
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {

}
