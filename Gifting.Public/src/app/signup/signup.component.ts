import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
	selector: 'app-signup',
	templateUrl: './signup.component.html',
	styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
	errorMessage: string;

	constructor(private accountService: AccountService, private router: Router) {
	}

	ngOnInit() { }

	onSubmit(loginForm: NgForm) {
		if (loginForm && loginForm.valid) {
			const result = this.accountService.register(
					loginForm.form.value.firstName,
					loginForm.form.value.lastName,
					loginForm.form.value.email,
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
						this.errorMessage = 'Please fill the form.';
					});
		} else {
			this.errorMessage = 'Please fill the form.';
		};
	}

}
