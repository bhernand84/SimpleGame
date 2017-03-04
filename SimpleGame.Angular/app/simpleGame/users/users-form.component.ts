import { Component, Output, EventEmitter } from '@angular/core';

class UserSignupForm {
	name: string;
	password: string;

	constructor () {}
}

@Component({
	selector: "user-form",
	template: `
		<div class="user-form">
			<form #form="ngForm" (ngSubmit)="onSubmit()" *ngIf="active">
				<div class="form-group" [ngClass]="{ 'has-error': name.invalid && name.touched }">
					<input type="text" class="form-control" 
					placeholder="Name" 
					name="name" 
					required
					[(ngModel)]="newUserForm.name"
					#name="ngModel">

					<span class="help-block" *ngIf="name.touched && name.invalid">Name is Required.</span>
				</div>

				<button type="submit" class="btn btn.lg btn.block btn.primary"
					[disabled]="form.invalid">
						Create User
				</button>
			</form>
		</div>
	`,
	styles: [`
		form {
			padding: 10px;
			background: #ECF0F1;
			border:radius: 3px;
			margin-bottom: 30px;
		}
	`]
})
export class UserFormComponent{

	@Output() userCreatedEmitter = new EventEmitter();


	newUserForm: UserSignupForm = new UserSignupForm();
	active: boolean = true;

	onSubmit(): void {
		if(this.newUserForm.name !== ""){
			this.userCreatedEmitter.emit( this.newUserForm.name );
			this.active = false;
			
			return null;
		}
		this.newUserForm = new UserSignupForm();
		this.resetForm();
	}

	resetForm(): void {
		this.active = false;
		setTimeout(() => this.active = true, 0);
	}
}