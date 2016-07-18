require("./app/articles");
require("./app/content-aggregation");
require("./app/pages");
require("./app/photos");
require("./app/shared");

import { ArticlesRoutes } from "./app/articles";
import { PagesRoutes } from "./app/pages";
import { PhotosRoutes } from "./app/photos";

import { provide, provideRoutePromise, bootstrap } from "angular-rx-ui/src/components/core";
import { authorizationGuard } from "angular-rx-ui/src/components/routing/authorization-guard";
import { routeChangeSuccessIsAdminReducer } from "angular-rx-ui/src/components/routing/route-change-success-is-admin.reducer";

import { AppComponent } from "./app/app.component";
import { AdminAppComponent } from "./app/admin-app.component";

const appModule = angular.module("digitalArchitectureApp", [
    "components",
    "app.articles",
    "app.contentAggregation",    
    "app.pages",
    "app.photos",
    "app.shared"
]);

bootstrap(appModule, {
    api: "api",
    components: [AppComponent, AdminAppComponent],
    loginRedirectUrl: "/",
    html5Mode: true,
    guards: [authorizationGuard],
    run: [routeChangeSuccessIsAdminReducer],
    routes: [
        ...ArticlesRoutes,
        ...PagesRoutes,
        ...PhotosRoutes
    ]
});
