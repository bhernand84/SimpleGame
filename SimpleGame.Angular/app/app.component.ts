import { Component } from '@angular/core';
import { Game } from './shared/models/game';

@Component({
  selector: 'my-app',
  template: `
    <div class="jumbotron">
      <h1>Welcome to Our App!</h1>
    </div>
  `,
  styles: [`
    .jumbotron { box-shadow: 0 2px 0 rgba(0, 0, 0, 0.2); }
  `]
})
export class AppComponent {

    constructor(private _signalR: SignalR) {

    }
	ngOnInit(){
        this._signalR.connect().then((c: any) => {
            //do stuff
        });
    }
}