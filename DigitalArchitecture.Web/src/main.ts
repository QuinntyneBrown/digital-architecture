/// <reference path="../ts/rx.all.d.ts" />
/// <reference path="../ts/angular-rx-ui.d.ts" />

import { HomeContainerComponent } from "./app/home/home-container.component";
import { ArticleDetailContainerComponent } from "./app/articles/article-detail-container.component";
import { DaHeaderComponent } from "./app/shared/da-header.component";
import { DaFooterComponent } from "./app/shared/da-footer.component";

var app = angular.module("digitalArchitectureApp", ["components"]) as any;

app.component(HomeContainerComponent);
app.component(ArticleDetailContainerComponent);
app.component(DaHeaderComponent);
app.component(DaFooterComponent);

app.config(["$routeProvider", ($routeProvider: angular.route.IRouteProvider) => {
    $routeProvider
        .when("/", { template: "<home-container></home-container>" })
        .when("/article/:slug", { template: "<article-detail-container></article-detail-container>" });
}]);