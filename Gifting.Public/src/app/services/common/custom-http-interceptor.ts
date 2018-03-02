import { Injectable } from '@angular/core';
import {
	HttpInterceptor,
	HttpRequest,
	HttpResponse,
	HttpHandler,
	HttpEvent,
	HttpHeaders,
	HttpErrorResponse
	} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { UserProfile } from '../../models/account';
import { appVariables } from '../../app.constants';
import { HelperService } from './helper.service';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
	constructor(
		private authProfile: UserProfile,
		private helperService: HelperService,
		private router: Router) {
	}

	intercept(
		request: HttpRequest<any>,
		next: HttpHandler
	): Observable<HttpEvent<any>> {

		const customReq = request.clone({
			headers: this.buildRequestOptions(request.headers)
		});

		this.helperService.startLoader();
	
		return next.handle(customReq).pipe(
			tap(event => {
					console.log('response received');
					if (event instanceof HttpResponse) {
						console.log('processing response', event);
					}
				},
				error => {
					console.log('error caught');
					if (error instanceof HttpErrorResponse) {
						if (error.status === 401 && this.router.url !== '/login') {
							this.router
								.navigate(['/login'], { queryParams: { redirectUrl: this.router.url } })
								.then(() => { });
						}

						this.helperService.showErrorMessage(error.message);
						console.log('Processing http error', error);
					}

					return Observable.throw(error);
				},
				() => {
					this.helperService.stopLoader();
				}));
	}

	private buildRequestOptions(headers: HttpHeaders, isBodyJson: boolean = true) {
		if (isBodyJson) {
			headers = headers.append('Content-Type', appVariables.jsonContentTypeHeader);
		}

		if (this.authProfile.isAuthenticated()) {
			let profile = this.authProfile.getProfile(true);
			if (profile) {
				headers = headers.append('Authorization', 'Bearer ' + profile.token);
			}
		}

		return headers;
	}
}
