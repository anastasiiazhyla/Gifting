import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IdeasListComponent } from './ideas-list/ideas-list.component';
import { AddIdeaComponent } from './add-idea/add-idea.component';

const routes: Routes = [
	{ path: '', component: IdeasListComponent },
	{ path: 'addIdea', component: AddIdeaComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
