import { CanActivate, ChangeDetectionStrategy, Component } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./articles-page-container.component.html"),
    styles: [require("./articles-page-container.component.scss")],
    selector: "articles-page-container",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ArticlesPageContainerComponent { }
