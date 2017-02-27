import { Component, Input } from '@angular/core';
import { ListOfGames } from '../../shared/models/listOfGames';

@Component({
    selector: 'listOfGames',
    template: `
        <div class="listOfGames">
            LIST OF GAMES GOES HERE
        </div>
    `,
    styles: []
})
export class ListOfGamesComponent {
    @Input() listOfGames: ListOfGames;
}