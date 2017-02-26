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

	ngOnInit(){
    let connection = $.hubConnection('http://www.simplegameweb.azurewebsites.net');
    let simpleGameHubProxy = connection.createHubProxy('gameHub');
    simpleGameHubProxy.on('update', function(game: Game) {
      console.log('game updated ' + game);
    });
    console.log(connection);
    connection.start()
      .done(function(){ console.log('Now connected, connection ID=' + this.connection.id); })
      .fail(function(){ console.log('Could not connect'); });
  }
}