import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

import { BaseService } from './common/base.service';
import { HelperService } from './common/helper.service'
import { ErrorHandlingService } from './common/error-handling.service';
import { UserProfile } from '../models/account';

export interface Grantee {
	id: number;
	name: string;
}

@Injectable()
export class GranteeService extends BaseService {
	private getAllGranteesUrl: string = 'api/Grantees/';

	constructor(
		public http: HttpClient,
		public errorHandlingService: ErrorHandlingService,
		public helperService: HelperService,
		public authProfile: UserProfile) {
		super(http, errorHandlingService, helperService, authProfile);
	}

	getAllGrantees(): Observable<Grantee[]> {
		return super.get(this.getAllGranteesUrl);
	}
}
