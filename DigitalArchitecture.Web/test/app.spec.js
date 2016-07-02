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
