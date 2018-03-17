import { Injectable } from '@angular/core';

@Injectable()
export class Idea {
	constructor(
		public name: string,
		public description?: string,
		public imageUrl?: string,
		public whereToBuy?: string,
		public occasionId?: number,
		public granteeId?: number,
		public id?: number,
		public dateCreated?: Date
	) {
	}
}
