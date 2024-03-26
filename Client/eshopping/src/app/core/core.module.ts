import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import { ProductCategoriesComponent } from './components/product-categories/product-categories.component';
import { IdentityManagementModule } from '../identity-management/identity-management.module';
import { OAuthModule } from 'angular-oauth2-oidc';
import { AuthModule, LogLevel } from 'angular-auth-oidc-client';




@NgModule({
  declarations: [
    NavBarComponent,
    ProductCategoriesComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    IdentityManagementModule,
    OAuthModule.forRoot(),
    AuthModule.forRoot({
      config: {
        authority: 'http://localhost:5001',
        redirectUrl: 'http://localhost:4200',
        postLogoutRedirectUri: window.location.origin,
        clientId: 'EshoppingClient',
        scope: 'openid profile',
        responseType: 'code',
        silentRenew: true,
        useRefreshToken: true,
        logLevel: LogLevel.Debug,
        // customParamsAuthRequest: {
        //   audience: 'https://auth0-api-spa',
        // },
        // customParamsRefreshTokenRequest: {
        //   scope: 'openid profile offline_access auth0-user-api-spa',
        // },
      },
    })
  ],
  exports:[
    NavBarComponent
  ]
})
export class CoreModule { }
