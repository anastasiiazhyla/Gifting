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

	constructor(private ideaService: IdeaService) {}

	ngOnInit() {
		this.ideaService.getAllIdeas(1).subscribe(i => { this.ideas = i; console.log(this.ideas);});
		   
	}
}
