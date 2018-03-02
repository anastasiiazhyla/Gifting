import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';
import { IError } from '../../models/common/error';
import { IServerResponse } from '../../models/common/server-response';
import { CustomErrorHandlerService } from './error-handling.service';
import { HelperService } from './helper.service';
import { appVariables } from '../../app.constants';
import { UserProfile } from '../../models/account';

@Injectable()
export class BaseService {
	constructor(
		public http: HttpClient,
		public errorHandler: CustomErrorHandlerService,
		public helperService: HelperService,
		private authProfile: UserProfile) {
	}

	get<T>(url): Observable<T> {
		return this.http.get<IServerResponse<T>>(url)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	post<T>(url, postBody: any): Observable<T> {
		console.log('post to ' + url);
		return this.http.post<IServerResponse<T>>(url, postBody)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	delete<T>(url, postBody: any): Observable<T> {
		return this.http.delete<IServerResponse<T>>(url)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	put<T>(url, putData): Observable<T>{
		return this.http.put<IServerResponse<T>>(url, putData)
			.map((res: IServerResponse<T>) => {
				return this.handleResponse(res);
			});
	}

	upload<T>(url: string, file: File): Observable<T> {
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
			throw new Error(this.errorHandler.parseCustomServerErrorToString(error));
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
