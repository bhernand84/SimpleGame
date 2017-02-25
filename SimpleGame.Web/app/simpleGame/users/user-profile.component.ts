import { Component } from '@angular/core';

@Component({
	selector: 'user-profile',
	template: `
		<div class="jumbotron" *ngIf="user">
			<h2>{{ user.name }}</h2>
			<input class="form-control" [(ngModel)]="user.name">
		</div>
	`,
	styles: []
})
export class UserProfileComponent {}