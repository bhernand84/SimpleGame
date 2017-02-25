import { NgModule } from '@angular/core';
import { RouterModule, Routes }  from '@angular/router';
import { GameComponent } from './simpleGame/game/game.component';
import { ListOfGamesComponent } from './simpleGame/listOfGames/listOfGames.component';
import { UserFormComponent } from './simpleGame/users/users-form.component';

const appRoutes: Routes = [
    { path: 'simpleGame', component: GameComponent },
    { path: 'login', component: UserFormComponent },
    { path: 'listOfGames', component: ListOfGamesComponent },
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: '*', component: GameComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {

}