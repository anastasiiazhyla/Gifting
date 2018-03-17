import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IdeasListComponent } from './components/ideas-list/ideas-list.component';
import { AddIdeaComponent } from './components/add-idea/add-idea.component';
import { UpdateIdeaComponent } from './components/update-idea/update-idea.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
	// idea routes
	{ path: '', component: IdeasListComponent },
	{ path: 'addIdea', component: AddIdeaComponent, canActivate: [AuthGuard] },
	{ path: 'updateIdea/:id', component: UpdateIdeaComponent, canActivate: [AuthGuard] },
	// account routes
	{ path: 'login', component: LoginComponent },
	{ path: 'signup', component: SignupComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {
}
