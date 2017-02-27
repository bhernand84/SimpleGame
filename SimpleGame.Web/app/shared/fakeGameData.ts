import { Game } from './models/game';

export class FakeGameData {
    public static testGame: Game = {
        id: "GAME1",
        board: {
            id: "BOARD1",
            spaces: [
                {
                    id: "SPACE1",
                    state: "played",
                    isAvailable: false,
                    owner: {
                        id: "TESTPLAYER1",
                        name: "testJustin",
                        isActive: false
                    }
                },
                {
                    id: "SPACE2",
                    state: "unplayed",
                    isAvailable: true,
                    owner: null
                }
            ]
        },
        listOfPlayers: [
            {
                id: "TESTPLAYER1",
                name: "testJustin",
                isActive: false
            },
            {
                id: "TESTPLAYER2",
                name: "testBenaldo",
                isActive: true
            }
        ],
        state: "active",
        output: ""
    }

};