describe("articleDetailContainer", function () {
    var articleDetailContainerComponent;
    var $compile;
    var $rootScope;
    var MockActionCreator = (function () {
        function MockActionCreator() {
        }
        return MockActionCreator;
    }());
    beforeEach(function () {
        angular.mock.module("digitalArchitectureApp");
    });
    beforeEach(inject(function ($controller, _$compile_, _$rootScope_) {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        articleDetailContainerComponent = $controller("articleDetailContainerComponent", { articleDetailContainerActionCreator: new MockActionCreator() });
    }));
    it("should compile", function () {
        var element = $compile("<article-detail-container></article-detail-container>")($rootScope);
        expect(element).toBeDefined();
    });
    it("should be defined", function () {
        expect(articleDetailContainerComponent).toBeDefined();
    });
});

describe("daFooter", function () {
    var daFooterComponent;
    var $compile;
    var $rootScope;
    var MockActionCreator = (function () {
        function MockActionCreator() {
        }
        return MockActionCreator;
    }());
    beforeEach(function () {
        angular.mock.module("digitalArchitectureApp");
    });
    beforeEach(inject(function ($controller, _$compile_, _$rootScope_) {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        daFooterComponent = $controller("daFooterComponent", { daFooterActionCreator: new MockActionCreator() });
    }));
    it("should compile", function () {
        var element = $compile("<da-footer></da-footer>")($rootScope);
        expect(element).toBeDefined();
    });
    it("should be defined", function () {
        expect(daFooterComponent).toBeDefined();
    });
});

describe("daHeader", function () {
    var daHeaderComponent;
    var $compile;
    var $rootScope;
    var MockActionCreator = (function () {
        function MockActionCreator() {
        }
        return MockActionCreator;
    }());
    beforeEach(function () {
        angular.mock.module("digitalArchitectureApp");
    });
    beforeEach(inject(function ($controller, _$compile_, _$rootScope_) {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        daHeaderComponent = $controller("daHeaderComponent", { daHeaderActionCreator: new MockActionCreator() });
    }));
    it("should compile", function () {
        var element = $compile("<da-header></da-header>")($rootScope);
        expect(element).toBeDefined();
    });
    it("should be defined", function () {
        expect(daHeaderComponent).toBeDefined();
    });
});
