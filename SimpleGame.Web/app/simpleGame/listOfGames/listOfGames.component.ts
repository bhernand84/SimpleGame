import { Component, Input } from '@angular/core';
import { ListOfGames } from '../../shared/models/listOfGames';

@Component({
    selector: 'list-of-games',
    template: `
        <div class="list-of-games">
            LIST OF GAMES GOES HERE
        </div>
    `,
    styles: []
})
export class ListOfGamesComponent {
    @Input() listOfGames: ListOfGames;
}