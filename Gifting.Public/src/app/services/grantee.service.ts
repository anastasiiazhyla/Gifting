import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

export interface Grantee {
	id: number;
	name: string;
}

@Injectable()
export class GranteeService {
	private getAllGranteesUrl: string = 'api/Grantees/';

	constructor(private http: HttpClient) { }

	getAllGrantees(): Observable<Grantee[]> {
		return this.http.get<Grantee[]>(this.getAllGranteesUrl);
	}
}
