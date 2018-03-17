import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

import { IdeaService } from '../../services/idea.service';
import { OccasionService } from '../../services/occasion.service';
import { GranteeService } from '../../services/grantee.service';
import { Idea } from '../../models/idea';
import { ErrorHandlingService } from '../../services/common/error-handling.service';

@Component({
	selector: 'app-update-idea',
	templateUrl: './update-idea.component.html',
	styleUrls: ['./update-idea.component.css']
})
export class UpdateIdeaComponent implements OnInit {
	errorMessages: string[] = [];
	occasions: any[] = [];
	grantees: any[] = [];
	idea: Idea;

	constructor(private ideaService: IdeaService,
		private granteeService: GranteeService,
		private occasionService: OccasionService,
		private errorHandlingService: ErrorHandlingService,
		private router: Router,
		private route: ActivatedRoute) {
	}

	ngOnInit() {
		const id = +this.route.snapshot.paramMap.get('id');
		this.ideaService.getIdea(id).subscribe(idea => this.idea = idea);
		this.granteeService.getAllGrantees().subscribe(values => {
			this.grantees = values;
		});
		this.occasionService.getAllOccasions().subscribe(values => {
			this.occasions = values;
		});
	}

	onSubmit(addIdeaForm: NgForm) {
		this.ideaService.updateIdea(addIdeaForm.form.value).subscribe(
			response => {
				this.router.navigate(['../']);
			},
			error => {
				this.errorHandlingService.processErrorResponse(error, addIdeaForm.form, this.errorMessages);
			});
	}
}
