import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { FooterComponent } from './components/footer/footer.component';
import { IdeasListComponent } from './components/ideas-list/ideas-list.component';
import { AddIdeaComponent } from './components/add-idea/add-idea.component';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { NearestEventsComponent } from './components/nearest-events/nearest-events.component';
import { FieldErrorMessageComponent } from './components/field-error-message/field-error-message.component';
import { GeneralErrorMessageComponent } from './components/general-error-message/general-error-message.component';

import { AppService } from './services/app.service';
import { IdeaService } from './services/idea.service';
import { OccasionService } from './services/occasion.service';
import { GranteeService } from './services/grantee.service';
import { AccountService } from './services/account.service';
import { BaseService } from './services/common/base.service';
import { HelperService } from './services/common/helper.service'
import { ErrorHandlingService } from './services/common/error-handling.service'

import { UserProfile } from './models/account';
import { CustomHttpInterceptor } from './services/common/custom-http-interceptor';
import { AuthGuard } from './guards/auth.guard';
import { UpdateIdeaComponent } from './components/update-idea/update-idea.component';

@NgModule({
	declarations: [
		AppComponent,
		FooterComponent,
		IdeasListComponent,
		AddIdeaComponent,
		HeaderComponent,
		LoginComponent,
		SignupComponent,
		ForgotPasswordComponent,
		NearestEventsComponent,
		FieldErrorMessageComponent,
		GeneralErrorMessageComponent,
		UpdateIdeaComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		HttpClientModule,
		AppRoutingModule,
		AngularFontAwesomeModule
	],
	providers: [
		{ provide: HTTP_INTERCEPTORS, useClass: CustomHttpInterceptor, multi: true },

		AppService,
		IdeaService,
		OccasionService,
		GranteeService,
		AccountService,
		UserProfile,
		BaseService,
		HelperService,
		ErrorHandlingService,

		AuthGuard
	],
	bootstrap: [AppComponent]
})
export class AppModule {}
