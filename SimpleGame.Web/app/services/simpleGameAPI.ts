import { Injectable } from '@angular/core';
import { Game } from '../shared/models/game';
import { User } from '../shared/models/user';
import { Board } from '../shared/models/board';
import { Space } from '../shared/models/space';
import { FakeGameData } from '../shared/fakeGameData';

@Injectable()
export class SimpleGameAPI {

	constructor(){}

	public static getGame(gameId): Game {
		console.log('API getGame called');
		//hit getGame API passing in the gameId.  A json game should be returned.
		let jsonGame = FakeGameData.testGame;

		return jsonGame;
	}

	public static getGames(): Game[] {
		console.log('API getGames called');
		return null;
	}

	public static resetGame(): Game {
		console.log('API resetGame called');
		return null;
	}

	public static createPlayer(playerName: string): User {
		console.log('API createPlayer called');
        let user: User = new User();
        //send user to game server
        

        user.name = playerName;
		return user;
	}

	/*public static createGame(createGameData: CreateGameData){
		console.log('API createGame called by ' + createGameData.user.name);
		//get gameId returned from API to give back to the app and use to call getGame
		
		return FakeGameData.testGame.id;
	}*/

	public static joinGame(user: User, game: Game){
		console.log('API joinGame called by ' + user.name + ' for game ' + game.id);
		return null;
	}

	/*public static play(playData: PlayData){
		console.log('API play called on column ' + playData.columnId + ' by player id ' + playData.playerId + ' for game ' + playData.gameId);
		return null;
	}*/

	public static leave(gameId: string, playerId: string){
		console.log('API leave called by player id ' + playerId + ' for game ' + gameId);
		return null;
	}
}