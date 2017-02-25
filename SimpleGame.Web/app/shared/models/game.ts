import { Board } from './board';
import { User } from './user';

export class Game {
	id: string;
	board: Board;
	listOfPlayers: User[];
	state: string;
	output: string;
}

