import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { httpStatuses } from '../../app.constants';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
	errorMessages: string[];

	customErrorMessages = {
		'incorrect': () => 'Either your username or password were incorrect'
	};

	constructor(private accountService: AccountService, private router: Router) {
	}

	ngOnInit() { }

	onSubmit(loginForm: NgForm) {
		if (loginForm && loginForm.valid) {
			const result = this.accountService.login(
					loginForm.form.value.username,
					loginForm.form.value.password)
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
						if (error.status === httpStatuses.unauthorized) {
							loginForm.form.controls['username'].setErrors({ 'incorrect': true }); //formData.form.controls['email'].setErrors(null);
						} else {
							this.errorMessages = ['Something went wrong. Please, try again in few minutes.'];
						}
					});
		}
	}
}
