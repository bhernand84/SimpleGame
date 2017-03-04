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
var UserSignupForm = (function () {
    function UserSignupForm() {
    }
    return UserSignupForm;
}());
var UserFormComponent = (function () {
    function UserFormComponent() {
        this.userCreatedEmitter = new core_1.EventEmitter();
        this.newUserForm = new UserSignupForm();
        this.active = true;
    }
    UserFormComponent.prototype.onSubmit = function () {
        if (this.newUserForm.name !== "") {
            this.userCreatedEmitter.emit(this.newUserForm.name);
            this.active = false;
            return null;
        }
        this.newUserForm = new UserSignupForm();
        this.resetForm();
    };
    UserFormComponent.prototype.resetForm = function () {
        var _this = this;
        this.active = false;
        setTimeout(function () { return _this.active = true; }, 0);
    };
    return UserFormComponent;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], UserFormComponent.prototype, "userCreatedEmitter", void 0);
UserFormComponent = __decorate([
    core_1.Component({
        selector: "user-form",
        template: "\n\t\t<div class=\"user-form\">\n\t\t\t<form #form=\"ngForm\" (ngSubmit)=\"onSubmit()\" *ngIf=\"active\">\n\t\t\t\t<div class=\"form-group\" [ngClass]=\"{ 'has-error': name.invalid && name.touched }\">\n\t\t\t\t\t<input type=\"text\" class=\"form-control\" \n\t\t\t\t\tplaceholder=\"Name\" \n\t\t\t\t\tname=\"name\" \n\t\t\t\t\trequired\n\t\t\t\t\t[(ngModel)]=\"newUserForm.name\"\n\t\t\t\t\t#name=\"ngModel\">\n\n\t\t\t\t\t<span class=\"help-block\" *ngIf=\"name.touched && name.invalid\">Name is Required.</span>\n\t\t\t\t</div>\n\n\t\t\t\t<button type=\"submit\" class=\"btn btn.lg btn.block btn.primary\"\n\t\t\t\t\t[disabled]=\"form.invalid\">\n\t\t\t\t\t\tCreate User\n\t\t\t\t</button>\n\t\t\t</form>\n\t\t</div>\n\t",
        styles: ["\n\t\tform {\n\t\t\tpadding: 10px;\n\t\t\tbackground: #ECF0F1;\n\t\t\tborder:radius: 3px;\n\t\t\tmargin-bottom: 30px;\n\t\t}\n\t"]
    })
], UserFormComponent);
exports.UserFormComponent = UserFormComponent;
//# sourceMappingURL=users-form.component.js.map