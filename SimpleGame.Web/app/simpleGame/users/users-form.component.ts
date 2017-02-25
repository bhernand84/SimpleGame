import { Component, Output, EventEmitter } from '@angular/core';
import { User } from '../../shared/models/user';

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
					[(ngModel)]="newUser.name"
					#name="ngModel">

					<span class="help-block" *ngIf="name.touched && name.invalid">Name is Required.</span>
				</div>

				<div class="form-group" [ngClass]="{ 'has-error': username.invalid && username.touched }">
					<input type="text" class="form-control" 
					placeholder="Username"
					name="username" 
					required
					[(ngModel)]="newUser.username"
					#username="ngModel">

					<span class="help-block" *ngIf="username.touched && username.invalid">Username is Required.</span>
				</div>

				<div class="form-group" [ngClass]="{ 'has-error': password.invalid && password.touched }">
					<input type="password" class="form-control" 
					placeholder="password"
					name="password" 
					required
					[(ngModel)]="newUser.password"
					#password="ngModel">

					<span class="help-block" *ngIf="password.touched && password.invalid">Password is Required.</span>
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
	@Output() userCreated = new EventEmitter();


	newUser: User = new User();
	active: boolean = true;

	onSubmit() {
		this.userCreated.emit({ user: this.newUser });
		console.log(this.newUser);
		this.newUser = new User();
		this.resetForm();
	}

	resetForm() {
		this.active = false;
		setTimeout(() => this.active = true, 0);
	}
}