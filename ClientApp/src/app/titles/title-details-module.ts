import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMaterialModule } from '../angular-material.module';
import { RouterModule } from '@angular/router';

import { AwardsComponent } from '../awards/awards.component';
import { CreditsComponent } from '../credits/credits.component';
import { StorylineComponent } from '../storyline/storyline.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AngularMaterialModule,
    RouterModule
  ],
  declarations: [
    AwardsComponent,
    CreditsComponent,
    StorylineComponent
  ],
  exports: [
    AwardsComponent,
    CreditsComponent,
    StorylineComponent
  ]
})
export class TitleDetailsModule { }
