import { Injectable } from '@angular/core';
import { UserProfile, IProfile } from '../models/account';
import { BaseService } from './common/base.service';
import { HelperService } from './common/helper.service'
import { HttpClient } from '@angular/common/http';
import { ErrorHandlingService } from './common/error-handling.service';

@Injectable()
export class AccountService extends BaseService {
	private baseUrl: string = 'api/Account/';

	redirectUrl: string;
	errorMessage: string;

	constructor(
		public http: HttpClient,
		public errorHandlingService: ErrorHandlingService,
		public helperService: HelperService,
		public authProfile: UserProfile) {
			super(http, errorHandlingService, helperService, authProfile);
		}

	login(username, password) {
		const credentials = {
			username: username,
			password: password
		};

		return super.post(this.baseUrl + 'Login', credentials)
			.map((userProfile: IProfile) => {
				this.authProfile.setProfile(userProfile);
				return userProfile;
			});
	}

	register(firstName: string, lastName: string, email: string, username: string, password: string) {
		const credentials = {
			firstName,
			lastName,
			email,
			username,
			password
		};

		return super.post(this.baseUrl + '/Register', credentials)
			.map((userProfile: IProfile) => {
				this.authProfile.setProfile(userProfile);
				return userProfile;
			});
	}

	logout(): void {
		this.authProfile.resetProfile();
	}
}
