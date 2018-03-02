import { Injectable } from '@angular/core';
import { UserProfile, IProfile } from '../models/account';
import { BaseService } from './common/base.service';
import { HelperService } from './common/helper.service'

@Injectable()
export class AccountService {
	private baseUrl: string = 'api/Account/';

	redirectUrl: string;
	errorMessage: string;

	constructor(
		private base: BaseService,
		//private helperService: HelperService,
		private authProfile: UserProfile) { }

	login(username, password) {
		const credentials = {
			username: username,
			password: password
		};

		return this.base.post<IProfile>(this.baseUrl + 'Login', credentials)
			.map((userProfile) => {
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

		return this.base.post<IProfile>(this.baseUrl + '/Register', credentials)
			.map((userProfile) => {
				this.authProfile.setProfile(userProfile);
				return userProfile;
			});
	}

	logout(): void {
		this.authProfile.resetProfile();
	}
}
