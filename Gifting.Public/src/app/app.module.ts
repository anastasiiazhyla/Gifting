import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { FooterComponent } from './footer/footer.component';
import { IdeasListComponent } from './ideas-list/ideas-list.component';
import { AddIdeaComponent } from './add-idea/add-idea.component';
import { HeaderComponent } from './header/header.component';
import { ShowErrorsComponent } from './show-errors/show-errors.component';
import { LoginComponent } from './login/login.component';

import { AppService } from './services/app.service';
import { IdeaService } from './services/idea.service';
import { OccasionService } from './services/occasion.service';
import { GranteeService } from './services/grantee.service';
import { AccountService } from './services/account.service';
import { BaseService } from './services/common/base.service';
import { HelperService } from './services/common/helper.service'
import { CustomErrorHandlerService } from './services/common/error-handling.service'

import { UserProfile } from './models/account';
import { CustomHttpInterceptor } from './services/common/custom-http-interceptor';
import { AuthGuard } from './guards/auth.guard';
import { SignupComponent } from './signup/signup.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { NearestEventsComponent } from './nearest-events/nearest-events.component';

@NgModule({
	declarations: [
		AppComponent,
		FooterComponent,
		IdeasListComponent,
		AddIdeaComponent,
		HeaderComponent,
		ShowErrorsComponent,
		LoginComponent,
		SignupComponent,
		ForgotPasswordComponent,
		NearestEventsComponent
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
		CustomErrorHandlerService,

		AuthGuard
	],
	bootstrap: [AppComponent]
})
export class AppModule {}
