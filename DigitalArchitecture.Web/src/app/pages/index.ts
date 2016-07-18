import { bootstrap, provide, provideAction } from "angular-rx-ui/src/components/core";
import { LoginContainerComponent } from "./login-container.component";
import { ArticlePageContainerComponent } from "./article-page-container.component";
import { ArticlesPageContainerComponent } from "./articles-page-container.component";

const pagesModule = (<any>angular.module("app.pages", []));

bootstrap(pagesModule, {
    components: [LoginContainerComponent, ArticlePageContainerComponent, ArticlesPageContainerComponent]
});

export * from "./pages.routes";