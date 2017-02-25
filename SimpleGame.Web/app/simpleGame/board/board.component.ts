import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Board } from '../../shared/models/board';
import { Column } from '../../shared/models/column';

@Component({
	selector: 'connect4',
	template: `
		<div class="board">
			<h2>BOARD CONTAINER</h2>
			<column (columnClickedEmitter)="onColumnClick($event)"></column>

		</div>
	`,
	styles: [`
		.board {
			border: 2px solid red;
		}
		h2 {
			color: red;
		}
	`]
})
export class BoardComponent {
	@Input() board: Board;
	@Output() columnClickedEmitter = new EventEmitter();

	onColumnClick(column) {
		//push the clicked space up to parent component
		this.columnClickedEmitter.emit(column)
	}
} 