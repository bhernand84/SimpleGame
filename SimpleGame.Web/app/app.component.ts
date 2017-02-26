import { Component } from '@angular/core';
import { Game } from './shared/models/game';
import { SimpleGameAPI } from './services/simpleGameAPI';
import { User } from './shared/models/user';


interface ISimpleGameClient {
	userChanged(user: User);
	userRemoved(user: User);
}
 
interface ISimpleGameServer {
	join(user: User): JQueryPromise<User>;
	joinGame(game: Game): JQueryPromise<Game>;
	leaveGame(game: Game, user: User): JQueryPromise<Game>;
}

interface HubProxy {
	client: ISimpleGameClient;
	server: ISimpleGameServer;
}
 
interface SignalR {
	simpleGame: HubProxy;
}



@Component({
  selector: 'my-app',
  template: `
    <div class="jumbotron">
      <h1 style="text-align: center">Welcome to Our Simple Game!</h1>
        <h2 style="text-align: center">Let's Play!</h2>
        <user-form (userCreatedEmitter)="userCreated($event)"></user-form>
        <div class="gameWindow" *ngIf="loggedIn">
          <listOfGames></listOfGames>
          <button class="btn btn.lg btn.block btn.primary" (click)="createGame()">
						Create Game
				</button>
        </div>
    </div>

  `,
  styles: [`
    .jumbotron { box-shadow: 0 2px 0 rgba(0, 0, 0, 0.2); }
  `]
})
export class AppComponent {
  game: Game;
  activeUser: User = new User();
  loggedIn: boolean = false;

  constructor (){

  }
  

  userCreated(userName: string){
    console.log("app: userCreated Called");
    if(userName !== ""){
      this.activeUser = SimpleGameAPI.createPlayer(userName);
      this.loggedIn = true;
      console.log(this.activeUser);
    }
  }

  createGame(){
    console.log("app: createGame called");
    
  }
}