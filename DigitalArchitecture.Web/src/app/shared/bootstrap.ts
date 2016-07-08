export const bootstrap = (app:angular.IModule, options) => {

    app.config(["apiEndpointProvider", (apiEndpointProvider) => {
        apiEndpointProvider.configure(options.api);
    }]);

    app.config(["loginRedirectProvider", (loginRedirectProvider) => {
        loginRedirectProvider.setDefaultUrl(options.loginRedirectUrl);
    }]);

    app.config(["$locationProvider", ($locationProvider: angular.ILocationProvider) => {
        $locationProvider.html5Mode(options.isHtml5Mode);
    }]);

}