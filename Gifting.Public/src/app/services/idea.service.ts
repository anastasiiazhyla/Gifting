import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Idea } from '../models/idea';

@Injectable()
export class IdeaService {
	private baseUrl: string = 'api/Ideas/';

	constructor(private http: HttpClient) { }

	getAllIdeas(): Observable<Idea[]> {
		return this.http.get<Idea[]>(this.baseUrl);
	}

	getIdea(id: number): Observable<Idea> {
		return this.http.get<Idea>(this.baseUrl + id);
	}

	createIdea(idea: Idea): Observable<Idea> {
		console.log('you submitted value:', idea); 
		return this.http.post<Idea>(this.baseUrl, idea);
	}

	updateIdea(idea: Idea): Observable<void> {
		return this.http.put<void>(this.baseUrl + idea.id, idea);
	}

	deleteIdea(id: number) {
		return this.http.delete(this.baseUrl + id);
	}
}
