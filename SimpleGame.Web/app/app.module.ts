import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { BoardComponent } from './simpleGame/board/board.component';
import { SpaceComponent } from './simpleGame/space/space.component';
import { GameComponent } from './simpleGame/game/game.component';
import { UserFormComponent } from './simpleGame/users/users-form.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { ListOfGamesComponent } from './simpleGame/listOfGames/listOfGames.component';

@NgModule({
  imports: [ 
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  declarations: [ 
    AppComponent,
    BoardComponent,
    SpaceComponent,
    GameComponent,
    UserFormComponent,
    ListOfGamesComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule {}