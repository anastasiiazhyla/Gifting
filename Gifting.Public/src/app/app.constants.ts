export const appVariables = {
	userLocalStorage: 'user',
	resourceAccessLocalStorage: 'resourceAccessRaw',
	accessTokenServer: 'X-Auth-Token',
	jsonContentTypeHeader: 'application/json',
	accessTokenLocalStorage: 'accessToken',

	loginPageUrl: '/login',
	registrationPageUrl: '/register',
};

export const httpStatuses = {
	ok: 200,
	created: 201,
	noContent: 204,

	badRequest: 400,
	forbidden: 403,
	unauthorized: 401,
	notFound: 404,

	internalServerError: 500
}
