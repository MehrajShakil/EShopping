import { Component, EventEmitter, OnDestroy, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit, OnDestroy {

  @Output() LoginComponentDestroyEvent = new EventEmitter();

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.LoginComponentDestroyEvent.emit();
  }

  destroyComponent(): any{
    this.ngOnDestroy();
  }

}
