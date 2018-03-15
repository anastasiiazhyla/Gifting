import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'general-error-message',
  templateUrl: './general-error-message.component.html',
  styleUrls: ['./general-error-message.component.css']
})
export class GeneralErrorMessageComponent {
	@Input()
	private errorMessages: string[];

	shouldShowErrors(): boolean {
		return this.errorMessages && this.errorMessages.length > 0;
	}

	listOfErrors(): string[] {
		return this.errorMessages;
	}
}
