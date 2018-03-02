import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

export class Occasion {
	id: number;
	name: string;
}

@Injectable()
export class OccasionService {
	private getAllOccasionsUrl: string = 'api/Occasions/';

	constructor(private http: HttpClient) {}

	getAllOccasions(): Observable<Occasion[]> {
		return this.http.get<Occasion[]>(this.getAllOccasionsUrl);
	}
}
