import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

import { BaseService } from './common/base.service';
import { HelperService } from './common/helper.service'
import { ErrorHandlingService } from './common/error-handling.service';
import { UserProfile } from '../models/account';

export class Occasion {
	id: number;
	name: string;
}

@Injectable()
export class OccasionService extends BaseService {
	private getAllOccasionsUrl: string = 'api/Occasions/';

	constructor(
		public http: HttpClient,
		public errorHandlingService: ErrorHandlingService,
		public helperService: HelperService,
		public authProfile: UserProfile) {
		super(http, errorHandlingService, helperService, authProfile);
	}

	getAllOccasions(): Observable<Occasion[]> {
		return super.get(this.getAllOccasionsUrl);
	}
}
