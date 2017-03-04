"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var game_1 = require("../../shared/models/game");
var GameComponent = (function () {
    function GameComponent() {
        this.columnClickedEmitter = new core_1.EventEmitter();
    }
    GameComponent.prototype.setActivePlayer = function () {
        var _this = this;
        this.listOfUsers.forEach(function (element) {
            if (element.isActive === true) {
                _this.activePlayer = element;
            }
        });
    };
    GameComponent.prototype.ngOnInit = function () {
        console.log("gameboard initializing...");
        this.board = this.game.board;
        this.listOfUsers = this.game.listOfPlayers;
        this.state = this.game.state;
        this.output = this.game.output;
        this.setActivePlayer();
    };
    GameComponent.prototype.onSpaceClick = function (spaceClicked) {
        if (spaceClicked !== null) {
            console.log("active player is " + this.activePlayer);
            //send space object up to app level for the API call
            var objectForAPI = {
                column: spaceClicked,
                playerId: this.activePlayer.id,
                gameId: this.game.id
            };
            this.columnClickedEmitter.emit({ columnId: spaceClicked.id, playerId: this.activePlayer.id, gameId: this.game.id });
        }
    };
    return GameComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", game_1.Game)
], GameComponent.prototype, "game", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], GameComponent.prototype, "columnClickedEmitter", void 0);
GameComponent = __decorate([
    core_1.Component({
        selector: "game",
        template: "\n\t\t<div class=\"game\">\n\t\t\t<h1>GAME CONTAINER</h1>\n\t\t\t<board (spaceClickedEmitter)=\"onSpaceClick($event)\"></board>\n\t\t</div>\n\t",
        styles: ["\n\t\t.game {\n\t\t\tborder: 3px solid blue;\n\t\t}\n\t\th1 {\n\t\t\tcolor: blue;\n\t\t}\n\t"]
    })
], GameComponent);
exports.GameComponent = GameComponent;
//# sourceMappingURL=game.component.js.map