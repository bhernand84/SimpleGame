"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FakeGameData = (function () {
    function FakeGameData() {
    }
    return FakeGameData;
}());
FakeGameData.testGame = {
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
};
exports.FakeGameData = FakeGameData;
;
//# sourceMappingURL=fakeGameData.js.map