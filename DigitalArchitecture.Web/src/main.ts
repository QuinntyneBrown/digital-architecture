import "angular-rx-ui/src/main.ts";

import { HomeContainerComponent } from "./app/home/home-container.component";
import { ArticleDetailContainerComponent } from "./app/articles/article-detail-container.component";
import { AppHeaderComponent } from "./app/shared/app-header";
import { AppFooterComponent } from "./app/shared/app-footer";
import { AdminHeaderComponent } from "./app/shared/admin-header";
import { provide, provideRoutePromise } from "angular-rx-ui/src/components/core";
import { authorizationRequiredGuard } from "./app/routing/authorization-required-guard";
import { routeChangeSuccessIsAdminReducer } from "./app/routing/route-change-success-is-admin.reducer";
import { bootstrap} from "angular-rx-ui/src/components/core";

const appModule = angular.module("digitalArchitectureApp", ["components"]) as any;

appModule.component(HomeContainerComponent);
appModule.component(ArticleDetailContainerComponent);
appModule.component(AppHeaderComponent);
appModule.component(AppFooterComponent);
appModule.component(AdminHeaderComponent);

appModule.config(["$routeProvider", ($routeProvider: angular.route.IRouteProvider) => {
    
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

provideRoutePromise(appModule, authorizationRequiredGuard);
appModule.run(routeChangeSuccessIsAdminReducer);

bootstrap(appModule, {
    api: "api",
    loginRedirectUrl: "/",
    html5Mode:true,
    routes: [
        {
            path: "/",
            component: HomeContainerComponent
        },
        { 
            path: "/article/:slug",
            component: ArticleDetailContainerComponent
        }]
});
