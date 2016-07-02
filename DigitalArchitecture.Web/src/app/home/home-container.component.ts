import { Component } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./home-container.component.html"),
    styles: [require("./home-container.component.scss")],
    selector: "home-container"
})
@ngRxUI.core.CanActivate(["$q", ($q: angular.IQService) => {
        return $q.resolve(true);
}])
export class HomeContainerComponent { }