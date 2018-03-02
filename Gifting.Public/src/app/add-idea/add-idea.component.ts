import { Component, OnInit } from '@angular/core';
import { IdeaService } from '../services/idea.service';
import { OccasionService } from '../services/occasion.service';
import { GranteeService } from '../services/grantee.service';
import { Idea } from '../models/idea';

@Component({
	selector: 'app-add-idea',
	templateUrl: './add-idea.component.html',
	styleUrls: ['./add-idea.component.css']
})
export class AddIdeaComponent implements OnInit {

	model = new Idea('');
	occasions: any[] = [];
	grantees: any[] = [];

	constructor(private _ideaService: IdeaService,
		private _granteeService: GranteeService,
		private _occasionService: OccasionService) {
	}

	ngOnInit() {
		this._granteeService.getAllGrantees().subscribe(values => {
			this.grantees = values;
		});
		this._occasionService.getAllOccasions().subscribe(values => {
			this.occasions = values;
		});
	}

	onSubmit() {
		this._ideaService.createIdea(this.model).subscribe();
	}
}
