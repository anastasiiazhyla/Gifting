import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { UserProfile } from '../models/account';

@Injectable()
export class AuthGuard implements CanActivate {
	constructor(
		private authProfile: UserProfile,
		private router: Router
	) { }

  canActivate(
	next: ActivatedRouteSnapshot,
	state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
		if (!this.authProfile.isAuthenticated()) {
			this.router.navigate(['/login'], { queryParams: { redirectUrl: state.url } });
			return false;
		}

		return true;
  }
}
