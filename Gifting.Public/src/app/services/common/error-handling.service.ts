import { Injectable } from '@angular/core';
import { Response, ResponseOptions } from '@angular/http';
import { FormGroup } from '@angular/forms';
import { IError } from '../../models/common/error';
import { httpStatuses } from '../../app.constants';

@Injectable()
export class ErrorHandlingService {

	processErrorResponse<T>(error, form: FormGroup, errorMessages: string[]) {
		if (error.status === httpStatuses.badRequest) {
			for (let key in error.error) {
				let messages = error.error[key];
				messages.forEach((message) => {
					if (form.contains(key)) {
						form.controls[key].setErrors({
							'remote': message
						});
					} else {
						errorMessages.push(message);
					}
				});
			}
		} else if (error.message) {
			errorMessages.push(error.message);
		} else {
			errorMessages.push('Something went wrong. Please, try again in few minutes.');
		}
	}

	tryParseError(error: Response): any {
		try {
			return error.json().error;
		} catch (ex) {
			try {
				return error;
			} catch (ex) {
				return error.toString();
			}
		}
	}

	parseCustomServerError(error: IError): any {
		const title = error.message;
		let body = '';
		for (const errorMsg of error.errors) {
			body += `${errorMsg}. `;
		}

		return { title, body };
	}

	createCustomError(error: IError): Response {
		try {
			const parsedError = this.parseCustomServerError(error);
			const responseOptions = new ResponseOptions({
				body: { error: { title: parsedError.title, message: parsedError.body } },
				status: 400,
				headers: null,
				url: null,
			});
			return new Response(responseOptions);
		} catch (ex) {
			const responseOptions = new ResponseOptions({
				body: { title: 'Unknown Error!', message: 'Unknown Error Occurred.' },
				status: 400,
				headers: null,
				url: null,
			});
			return new Response(responseOptions);
		}
	}

	showErrorMessage(error: IError): void {
		const parsedError = this.parseCustomServerError(error);
		//this.snotify.toastConfig.title = parsedError.title;
		//this.snotify.toastConfig.body = parsedError.body;
		//this.snotify.toastConfig.bodyMaxLength = 100;
		//this.snotify.onError();
	}

	parseCustomServerErrorToString(error: IError): string {
		this.showErrorMessage(error);
		const parsedError = this.createCustomError(error);
		try {
			return JSON.stringify(this.tryParseError(parsedError));
		} catch (ex) {
			try {
				return error.errors.toString();
			} catch (error) {
				return error.toString();
			}
		}
	}
}
