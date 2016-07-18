import { IRouteConfig } from "angular-rx-ui/src/components/core";
import { LoginContainerComponent } from "./login-container.component";
import { ArticlePageContainerComponent } from "./article-page-container.component";
import { ArticlesPageContainerComponent } from "./articles-page-container.component";

export const PagesRoutes: Array<IRouteConfig> = [
    {
        path: "/",
        component: ArticlesPageContainerComponent
    },
    {
        path: "/article/:slug",
        component: ArticlePageContainerComponent
    },
    {
        path: "/login",
        component: LoginContainerComponent
    }
];