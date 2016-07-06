import { Component, CanActivate } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./home-container.component.html"),
    styles: [require("./home-container.component.scss")],
    selector: "home-container"
})
@CanActivate(["$q", ($q: angular.IQService) => $q.resolve(true)])
export class HomeContainerComponent { }