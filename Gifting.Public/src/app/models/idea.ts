import { Injectable } from '@angular/core';

@Injectable()
export class Idea {
	constructor(
		public name: string,
		public description?: string,
		public image?: string,
		public whereToBuy?: string,
		public occasion?: number,
		public grantee?: number,
		public id?: number,
		public dateCreated?: Date
	) {
	}
}
