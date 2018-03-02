import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IdeasListComponent } from './ideas-list/ideas-list.component';
import { AddIdeaComponent } from './add-idea/add-idea.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
	{ path: '', component: IdeasListComponent },
	{ path: 'addIdea', component: AddIdeaComponent, canActivate: [AuthGuard] },
	{ path: 'login', component: LoginComponent },
	{ path: 'signup', component: SignupComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {
}
