﻿window.chatApp = {};
window.chatApp.controllers = {};
window.chatApp.services = {};
window.chatApp.filters = {};

window.chatApp.config = {
	baseUrl: '/cuadernito/UI',
	urlArgs: 'v=1.0'
};

require.config(window.chatApp.config);

require
(
	[
		'Scripts/app',
		'services/routeResolver',
		'services/authService',
		'services/modalService',
		'services/httpInterceptors',
		'services/realtimeService',
		'filters/ConversationNameFilter',
		'filters/DateFormattingFilter',
		'filters/ConversationContentFormatter',
		'controllers/NavbarController',
],
	function ()
	{
		angular.bootstrap(document, ['chatApp']);
	}
);