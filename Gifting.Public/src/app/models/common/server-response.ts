export interface IServerResponse<T> {
	data: T;
	errors: string[];
	message: string;
}
