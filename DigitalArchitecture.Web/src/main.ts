import "angular-rx-ui/src/main.ts";

import { ArticlesRoutes, ArticleEditorContainerComponent, ArticlesContainerComponent, ArticleContainerComponent } from "./app/articles";
import { LoginRoutes, LoginContainerComponent } from "./app/login";

import { AppHeaderComponent } from "./app/shared/app-header";
import { AppFooterComponent } from "./app/shared/app-footer";
import { AdminHeaderComponent } from "./app/shared/admin-header";
import { provide, provideRoutePromise } from "angular-rx-ui/src/components/core";
import { authorizationRequiredGuard } from "./app/routing/authorization-required-guard";
import { routeChangeSuccessIsAdminReducer } from "./app/routing/route-change-success-is-admin.reducer";
import { bootstrap } from "angular-rx-ui/src/components/core";

const appModule = angular.module("digitalArchitectureApp", ["components"]) as any;

appModule.component(ArticleEditorContainerComponent);
appModule.component(ArticleContainerComponent);
appModule.component(ArticlesContainerComponent);
appModule.component(LoginContainerComponent);
appModule.component(AppHeaderComponent);
appModule.component(AppFooterComponent);
appModule.component(AdminHeaderComponent);

provideRoutePromise(appModule, authorizationRequiredGuard);
appModule.run(routeChangeSuccessIsAdminReducer);

bootstrap(appModule, {
    api: "api",
    loginRedirectUrl: "/",
    html5Mode:true,
    routes: [
        ...ArticlesRoutes,
        ...LoginRoutes
    ]
});
