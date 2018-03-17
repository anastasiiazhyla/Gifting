import { Component, Input } from '@angular/core';
import { AbstractControlDirective, AbstractControl } from '@angular/forms';

@Component({
  selector: 'field-error-message',
  templateUrl: './field-error-message.component.html',
  styleUrls: ['./field-error-message.component.css']
})
export class FieldErrorMessageComponent {

	private static readonly errorMessages = {
		'required': () => 'This field is required',
		'minlength': (params) => `The min number of characters is ${params.requiredLength}`,
		'maxlength': (params) => `The max allowed number of characters is ${params.requiredLength}`,
		'pattern': (params) => `The required pattern is: ${params.requiredPattern}`,
		'remote': (params) => params
	};

	private static readonly defaultErrorMessage = 'Enter the correct value';

	@Input()
	private control: AbstractControlDirective | AbstractControl;


	@Input()
	private customMessages;

	shouldShowErrors(): boolean {
		return this.control &&
			this.control.errors &&
			(this.control.dirty || this.control.touched);
	}

	listOfErrors(): string[] {
		return Object.keys(this.control.errors)
			.map(field => this.getMessage(field, this.control.errors[field]));
	}

	private getMessage(type: string, params: any) {
		if (this.customMessages && this.customMessages[type]) {
			return this.customMessages[type](params);
		} else if (FieldErrorMessageComponent.errorMessages[type]) {
			return FieldErrorMessageComponent.errorMessages[type](params);
		} else {
			return FieldErrorMessageComponent.defaultErrorMessage;
		}
	}
}
