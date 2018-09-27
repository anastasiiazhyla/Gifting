import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { IError } from '../../models/common/error';
import { IServerResponse } from '../../models/common/server-response';
import { UserProfile } from '../../models/account';
import { ErrorHandlingService } from './error-handling.service';
import { HelperService } from './helper.service';
import { appVariables } from '../../app.constants';

@Injectable()
export class BaseService {
	constructor(
		public http: HttpClient,
		public errorHandlingService: ErrorHandlingService,
		public helperService: HelperService,
		public authProfile: UserProfile) {
	}

	get<T>(url, options?: {
		headers?: HttpHeaders | {
			[header: string]: string | string[];
		};
		params?: HttpParams | {
			[param: string]: string | string[];
		};
		}): Observable<T> {
		return this.http.get<IServerResponse<T>>(url, options)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	post<T>(url, postBody?): Observable<T> {
		return this.http.post<IServerResponse<T>>(url, postBody)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	delete<T>(url, postBody?): Observable<T> {
		return this.http.delete<IServerResponse<T>>(url)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	put<T>(url, putData?): Observable<T>{
		return this.http.put<IServerResponse<T>>(url, putData)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	upload<T>(url, file: File): Observable<T> {
		const formData: FormData = new FormData();
		if (file) {
			formData.append('files', file, file.name);
		}

		return this.http.post<IServerResponse<T>>(url, formData)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	formUrlParam(url, data) {
		let queryString: string = '';
		for (const key in data) {
			if (data.hasOwnProperty(key)) {
				if (!queryString) {
					queryString = `?${key}=${data[key]}`;
				} else {
					queryString += `&${key}=${data[key]}`;
				}
			}
		}
		return url + queryString;
	}

	handleResponse<T>(response: IServerResponse<T>): T {
		// My API sends a new jwt access token with each request,
		// so store it in the local storage, replacing the old one.
		// todo: this.refreshToken(response);
		if (response.errors) {
			const error: IError = { errors: response.errors, message: response.message };
			throw new Error(this.errorHandlingService.parseCustomServerErrorToString(error));
		} else {
			return response.data;
		}
	}

	refreshToken(res: Response) {
		const token = res.headers.get(appVariables.accessTokenServer);
		if (token) {
			localStorage.setItem(appVariables.accessTokenLocalStorage, `${token}`);
		}
	}
}
