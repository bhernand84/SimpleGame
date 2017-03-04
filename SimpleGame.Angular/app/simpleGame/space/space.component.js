"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var SpaceComponent = (function () {
    function SpaceComponent() {
    }
    return SpaceComponent;
}());
SpaceComponent = __decorate([
    core_1.Component({
        selector: "space",
        template: "\n\t\t<div class=\"space\">\n\t\t\t[O]\n\t\t</div>\n\t",
        styles: ["\n\t\t.space {\n\t\t\tborder: 1px solid green;\n\t\t\tbackground: green;\n\t\t\twidth: 60px;\n\t\t\theight: 60px;\n\t\t\tdisplay: block;\n\t\t\ttext-align: center;\n\t\t\tvertical-align: middle;\n\t\t}\n\t"]
    })
], SpaceComponent);
exports.SpaceComponent = SpaceComponent;
//# sourceMappingURL=space.component.js.map