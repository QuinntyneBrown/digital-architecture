/// <reference path="../ts/rx.all.d.ts" />

import { HomeContainerComponent } from "./app/home/home-container.component";
import { ArticleDetailContainerComponent } from "./app/articles/article-detail-container.component";
import { AppHeaderComponent } from "./app/shared/app-header.component";
import { AppFooterComponent } from "./app/shared/app-footer.component";
import { AdminHeaderComponent } from "./app/shared/admin-header.component";
import { provide, provideRoutePromise } from "angular-rx-ui/src/components/core";

var app = angular.module("digitalArchitectureApp", ["components"]) as any;

app.component(HomeContainerComponent);
app.component(ArticleDetailContainerComponent);
app.component(AppHeaderComponent);
app.component(AppFooterComponent);
app.component(AdminHeaderComponent);

app.config(["$routeProvider", ($routeProvider: angular.route.IRouteProvider) => {
    
    $routeProvider
        .when("/", { template: "<home-container></home-container>" })
        .when("/article/:slug", { template: "<article-detail-container></article-detail-container>" });

    ($routeProvider as any)
        .when("/login", { template: "<login-container></login-container>" })
        .when("/admin", {
            authorizationRequired: true,
            template: "<article-editor-container></article-editor-container>"
        })
        .when("/admin/articles", {
            authorizationRequired: true,
            template: "<article-editor-container></author-editor-container>"
        })
        .when("/admin/authors", {
            authorizationRequired: true,
            template: "<author-editor-container></author-editor-container>"
        })
        .when("/admin/categories", {
            authorizationRequired: true,
            template: "<category-editor-container></category-editor-container>"
        })
        .when("/admin/tags", {
            authorizationRequired: true,
            template: "<tag-editor-container></tag-editor-container>"
        })
}]);

provideRoutePromise(app, {
    route: "*",
    promise: ["loginRedirect", "$q", "$route", "invokeAsync", "store", "userActionCreator", (loginRedirect, $q: angular.IQService, $route, invokeAsync, store: any, userActionCreator: any) => {
        var deferred = $q.defer();
        invokeAsync(userActionCreator.current).then(results => {
            if ($route.current.$$route.authorizationRequired && !(store.getValue() as any).currentUser) {
                loginRedirect.redirectToLogin();
                deferred.reject()
            } else {
                deferred.resolve();
            }
        });
        return deferred.promise;
    }],
    priority: -999
});

app.config(["apiEndpointProvider", (apiEndpointProvider) => {
    apiEndpointProvider.configure("api");
}]);

app.config(["loginRedirectProvider", (loginRedirectProvider) => {
    loginRedirectProvider.setDefaultUrl("/");
}]);

app.config(["$locationProvider", ($locationProvider: angular.ILocationProvider) => {
    $locationProvider.html5Mode(true);
}]);

app.run(["$location", "$rootScope", ($location: angular.ILocationService, $rootScope: angular.IRootScopeService) => {
    $rootScope.$on("$routeChangeSuccess", () => {
        var path = $location.path();
        if (path.length >= 6 && (path.substring(0, 6) == "/admin" || path.substring(0, 6) == "/login")) {
            (<any>$rootScope).isAdmin = true;
        } else {
            (<any>$rootScope).isAdmin = false;
        }
    });
}]);
