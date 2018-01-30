import { Component, OnInit } from '@angular/core';
import { IdeaService } from '../services/idea.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'ideas-list',
  templateUrl: './ideas-list.component.html',
  styleUrls: ['./ideas-list.component.css']
})
export class IdeasListComponent implements OnInit {
	ideasObservable: Observable<any[]>;

	constructor(private _ideaService: IdeaService) { }

	ngOnInit() {
		this.ideasObservable = this._ideaService.getAllIdeas();
  }

}
