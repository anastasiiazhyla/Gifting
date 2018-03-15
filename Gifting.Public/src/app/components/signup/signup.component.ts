import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { httpStatuses } from '../../app.constants';
import { ErrorHandlingService } from '../../services/common/error-handling.service';

@Component({
	selector: 'app-signup',
	templateUrl: './signup.component.html',
	styleUrls: ['./signup.component.css']
})
export class SignupComponent {
	errorMessages: string[] = [];

	constructor(
		private accountService: AccountService,
		private errorHandlingService: ErrorHandlingService,
		private router: Router) {}

	onSubmit(signupForm: NgForm) {
		if (signupForm && signupForm.valid) {
			const result = this.accountService.register(
					signupForm.form.value.FirstName,
					signupForm.form.value.LastName,
					signupForm.form.value.Email,
					signupForm.form.value.Username,
					signupForm.form.value.Password)
				.subscribe(
					response => {
						const tree = this.router.parseUrl(this.router.url);
						const redirectUrl = tree.queryParamMap.get('redirectUrl');
						if (redirectUrl) {
							this.router.navigateByUrl(redirectUrl);
						} else {
							this.router.navigate(['../']);
						}
					},
					error => {
						this.errorHandlingService.processErrorResponse(error, signupForm.form, this.errorMessages);
					});
		}
	}

}
