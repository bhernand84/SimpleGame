import { Component, Input } from '@angular/core';
import { Space } from '../../shared/models/space';

@Component({
	selector: "space",
	template: `
		<div class="space">
			[O]
		</div>
	`,
	styles: [`
		.space {
			border: 1px solid green;
			background: green;
			width: 60px;
			height: 60px;
			display: block;
			text-align: center;
			vertical-align: middle;
		}
	`]
})
export class SpaceComponent{

}