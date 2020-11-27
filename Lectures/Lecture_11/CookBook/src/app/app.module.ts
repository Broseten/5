import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IngredientComponent } from './ingredient/ingredient.component';
import {ApiModule} from './api/api.module';

@NgModule({
  declarations: [
    AppComponent,
    IngredientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ApiModule.forRoot({ rootUrl: 'https://localhost:44378//api' })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
