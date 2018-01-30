import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { FooterComponent } from './footer/footer.component';
import { IdeasListComponent } from './ideas-list/ideas-list.component';

import { AppService } from './services/app.service';
import { IdeaService } from './services/idea.service';
import { OccasionService } from './services/occasion.service';
import { GranteeService } from './services/grantee.service';

import { AddIdeaComponent } from './add-idea/add-idea.component';
import { HeaderComponent } from './header/header.component';
import { ShowErrorsComponent } from './show-errors/show-errors.component';

@NgModule({
	declarations: [
		AppComponent,
		FooterComponent,
		IdeasListComponent,
		AddIdeaComponent,
		HeaderComponent,
		ShowErrorsComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		HttpClientModule,
		AppRoutingModule,
		AngularFontAwesomeModule
	],
	providers: [
		AppService,
		IdeaService,
		OccasionService,
		GranteeService
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
