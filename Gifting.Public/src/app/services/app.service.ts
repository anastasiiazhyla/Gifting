import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

@Injectable()
export class AppService {
	private _serviceUrl = 'api/values';

	constructor(private http: HttpClient) {}

	getValues(): Observable<string[]> {
		return this.http.get<string[]>(this._serviceUrl);
	}
}
