/// <reference path="../ts/rx.all.d.ts" />
/// <reference path="../ts/angular-rx-ui.d.ts" />

import { HomeContainerComponent } from "./app/home/home-container.component";
import { ArticleDetailContainerComponent } from "./app/articles/article-detail-container.component";
import { AppHeaderComponent } from "./app/shared/app-header.component";
import { AppFooterComponent } from "./app/shared/app-footer.component";
import { AdminHeaderComponent } from "./app/shared/admin-header.component";

var app = angular.module("digitalArchitectureApp", ["components"]) as any;

app.component(HomeContainerComponent);
app.component(ArticleDetailContainerComponent);
app.component(AppHeaderComponent);
app.component(AppFooterComponent);
app.component(AdminHeaderComponent);

app.config(["$locationProvider","$routeProvider", ($locationProvider: angular.ILocationProvider,
    $routeProvider: angular.route.IRouteProvider) => {

    $locationProvider.html5Mode(true);

    $routeProvider
        .when("/", { template: "<home-container></home-container>" })
        .when("/article/:slug", { template: "<article-detail-container></article-detail-container>" });

    ($routeProvider as any)
        .when("/login", { template: "<login-container></login-container>" })
        .when("/admin", {
            authorizationRequired: true,
            template: "<article-editor-container></article-editor-container>"
        });
}]);