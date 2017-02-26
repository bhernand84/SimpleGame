import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { BoardComponent } from './simpleGame/board/board.component';
import { SpaceComponent } from './simpleGame/space/space.component';
import { GameComponent } from './simpleGame/game/game.component';
import { UserFormComponent } from './simpleGame/users/users-form.component';
import { ListOfGamesComponent } from './simpleGame/listOfGames/listOfGames.component';
import { SignalRModule } from 'ng2-signalr';
import { SignalRConfiguration } from 'ng2-signalr';

const config = new SignalRConfiguration();
config.hubName = 'Ng2SignalRHub';
config.qs = { user: 'donald' };
config.url = 'http://ng2-signalr-backend.azurewebsites.net/';

@NgModule({
  imports: [ 
    BrowserModule,
    FormsModule
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