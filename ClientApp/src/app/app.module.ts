import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { TitleDetailsModule } from './titles/title-details-module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TitlesComponent } from './titles/titles.component';
import { TitleDetailsComponent } from './titles/title-details.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    TitlesComponent,
    TitleDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    TitleDetailsModule,
    RouterModule.forRoot([
      { path: '', component: TitlesComponent, pathMatch: 'full' },
      { path: 'title/:id', component: TitleDetailsComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
