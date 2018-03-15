import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { IdeaService } from '../../services/idea.service';
import { OccasionService } from '../../services/occasion.service';
import { GranteeService } from '../../services/grantee.service';
import { Idea } from '../../models/idea';
import { ErrorHandlingService } from '../../services/common/error-handling.service';

@Component({
	selector: 'app-add-idea',
	templateUrl: './add-idea.component.html',
	styleUrls: ['./add-idea.component.css']
})
export class AddIdeaComponent implements OnInit {
	errorMessages: string[] = [];
	occasions: any[] = [];
	grantees: any[] = [];

	constructor(private ideaService: IdeaService,
		private granteeService: GranteeService,
		private occasionService: OccasionService,
		private errorHandlingService: ErrorHandlingService,
		private router: Router) {
	}

	ngOnInit() {
		this.granteeService.getAllGrantees().subscribe(values => {
			this.grantees = values;
		});
		this.occasionService.getAllOccasions().subscribe(values => {
			this.occasions = values;
		});
	}

	onSubmit(addIdeaForm: NgForm) {
		this.ideaService.createIdea(addIdeaForm.form.value).subscribe(
			response => {
				this.router.navigate(['../']);
			},
			error => {
				this.errorHandlingService.processErrorResponse(error, addIdeaForm.form, this.errorMessages);
			});
	}
}
