import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Idea } from '../models/idea';
import { BaseService } from './common/base.service';
import { HelperService } from './common/helper.service'
import { ErrorHandlingService } from './common/error-handling.service';
import { UserProfile } from '../models/account';

@Injectable()
export class IdeaService extends BaseService {
	private baseUrl: string = 'api/Ideas/';
	private pageSize: number = 50;

	constructor(
		public http: HttpClient,
		public errorHandlingService: ErrorHandlingService,
		public helperService: HelperService,
		public authProfile: UserProfile) {
			super(http, errorHandlingService, helperService, authProfile);
	}

	getAllIdeas(pageNumber: number): Observable<Idea[]> {
		let params = new HttpParams()
			.set('pageNumber', pageNumber.toString())
			.set('pageSize', this.pageSize.toString());

		return super.get(this.baseUrl, { params });
	}

	getIdea(id: number): Observable<Idea> {
		return super.get(this.baseUrl + id);
	}

	createIdea(idea: Idea): Observable<Idea> {
		return super.post(this.baseUrl, idea);
	}

	updateIdea(idea: Idea): Observable<{}> {
		return super.put(this.baseUrl + idea.id, idea);
	}

	deleteIdea(id: number) {
		return super.delete(this.baseUrl + id);
	}
}
