/// <reference path="../ts/rx.all.d.ts" />
/// <reference path="../ts/angular-rx-ui.d.ts" />

import { HomeContainerComponent } from "./app/home/home-container.component";

var app = angular.module("digitalArchitectureApp", ["components"]) as any;

app.component(HomeContainerComponent);
