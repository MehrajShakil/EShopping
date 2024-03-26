import { Component, EventEmitter, OnInit, Output, ViewChild, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { LoginComponent } from '../../../identity-management/components/login/login.component';
import { HttpClient } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { authCodeFlowConfig } from '../../constants.ts/oauthConfig';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
  //encapsulation: ViewEncapsulation.ShadowDom,
  encapsulation: ViewEncapsulation.None
})
export class NavBarComponent implements OnInit {
  
  @ViewChild('logInComponentContainer', { read: ViewContainerRef }) logInComponentContainer!: ViewContainerRef;
  @Output() myEvent = new EventEmitter();


  constructor(private httpClient: HttpClient,
              private oAuthService: OAuthService,
              private authService: AuthService){
                this.oAuthService.configure(authCodeFlowConfig);
                this.oAuthService.loadDiscoveryDocumentAndTryLogin();
              }

  ngOnInit(): void {
    
  }


  signIn(): any{
    // this.logInComponentContainer.clear();
    // const componentRef = this.logInComponentContainer.createComponent(LoginComponent);
    // componentRef.instance.LoginComponentDestroyEvent.subscribe(() => {
    //   componentRef.destroy();
    // });
    //this.oAuthService.initLoginFlow();
    this.authService.login();
  }

}
