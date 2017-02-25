import { User } from "./user";

export class Space {
	id: string;
	state: string;
	isAvailable: boolean;
	owner: User;

	constructor () {}
}