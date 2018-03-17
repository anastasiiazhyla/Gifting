import { Component, OnInit } from '@angular/core';
import { IdeaService } from '../../services/idea.service';
import { Observable } from 'rxjs/Observable';
import { Idea } from '../../models/idea';

@Component({
	selector: 'ideas-list',
	templateUrl: './ideas-list.component.html',
	styleUrls: ['./ideas-list.component.css']
})
export class IdeasListComponent implements OnInit {
	//ideas: Observable<Idea[]>;
	ideas: Idea[];
	errorMessages: string[] = [];

	constructor(private ideaService: IdeaService) {}

	ngOnInit() {
		this.ideaService.getAllIdeas(1).subscribe(i => { this.ideas = i; });
	}

	delete(id) {
		if (confirm("Do you want to delete this idea?")) {
			this.ideaService.deleteIdea(id)
				.subscribe(data => {
						const index = this.ideas.findIndex(x => x.id === id);
						this.ideas.splice(index, 1);
					},
				error => this.errorMessages = [error]);
		}
	}

	edit(id) {
		
	}

	view(id) {

	}
}
