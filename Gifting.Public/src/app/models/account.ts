import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

export interface IProfile {
	token: string;
	expiration: string;
	claims: IClaim[];
	currentUser: IUser;
}

interface IClaim {
	type: string;
	value: string;
}

interface IUser {
	id: string;
	name: string;
	email: string;
}

@Injectable()
export class UserProfile {
	private userProfile: IProfile = {
		token: '',
		expiration: '',
		currentUser: { id: '', name: '', email: '' },
		claims: null
	};

	constructor(private router: Router) {
	}

	setProfile(profile: IProfile): void {
		var id = profile.claims.filter(p => p.type === 'id')[0].value;
		var name = profile.claims.filter(p => p.type === 'name')[0].value;
		var email = profile.claims.filter(p => p.type === 'email')[0].value;
		sessionStorage.setItem('access_token', profile.token);
		sessionStorage.setItem('expires_in', profile.expiration);
		sessionStorage.setItem('id', id);
		sessionStorage.setItem('name', name);
		sessionStorage.setItem('email', email);
	}

	getProfile(authorizationOnly: boolean = false): IProfile {
		var expiration = sessionStorage.getItem('expires_in');
		var accessToken = sessionStorage.getItem('access_token');

		if (!authorizationOnly || accessToken && !this.isTokenExpired(expiration)) {
			this.userProfile.token = accessToken;
			this.userProfile.expiration = expiration;
		} else {
			this.userProfile.token = '';
			this.userProfile.expiration = '';
		}

		this.userProfile.currentUser = {
			id: sessionStorage.getItem('id'),
			name: sessionStorage.getItem('name'),
			email: sessionStorage.getItem('email')
		}

		return this.userProfile;
	}

	resetProfile(): IProfile {
		sessionStorage.removeItem('access_token');
		sessionStorage.removeItem('expires_in');
		this.userProfile = {
			token: '',
			expiration: '',
			currentUser: null,
			claims: null
		};
		return this.userProfile;
	}

	isAuthenticated() {
		let profile = this.getProfile();
		var validToken = profile.token !== '' && profile.token != null;
		var isTokenExpired = this.isTokenExpired(profile.expiration);
		return validToken && !isTokenExpired;
	}

	isTokenExpired(expiration: string) {
		return new Date(expiration) < new Date();
	}
}
