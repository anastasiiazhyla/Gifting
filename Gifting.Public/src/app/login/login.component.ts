import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
	errorMessage: string;

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
					this.errorMessage = 'Please enter a user name and password.';
				});
		} else {
			this.errorMessage = 'Please enter a user name and password.';
		};
	}
}
