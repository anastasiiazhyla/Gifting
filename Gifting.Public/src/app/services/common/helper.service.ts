import { Injectable } from '@angular/core';

@Injectable()
export class HelperService {
	startLoader(delay?: number): void {
		delay = delay || typeof delay === 'number' ? delay : 0;
		setTimeout(() => {
			// this.slimLoadingBarService.start(() => {
			//// Loading Completed;
			// });
		}, delay);
	}

	stopLoader(delay?: number): void {
		delay = delay || typeof delay === 'number' ? delay : 0;
		setTimeout(() => {
			//this.slimLoadingBarService.complete();
		}, delay);
	}

	showErrorMessage(title: string, errors?: string[]): void {
		alert(title);
	}
}

