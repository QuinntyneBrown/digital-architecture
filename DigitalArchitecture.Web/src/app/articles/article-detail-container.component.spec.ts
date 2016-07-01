describe("articleDetailContainer", () => {

    var articleDetailContainerComponent;
    var $compile;
    var $rootScope;

    class MockActionCreator { }

    beforeEach(() => {
        angular.mock.module("digitalArchitectureApp");
    });

    beforeEach(inject(($controller, _$compile_, _$rootScope_) => {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        articleDetailContainerComponent = $controller("articleDetailContainerComponent", { articleDetailContainerActionCreator: new MockActionCreator() });
    }));

    it("should compile", () => {
        var element = $compile("<article-detail-container></article-detail-container>")($rootScope);
        expect(element).toBeDefined();
    });

    it("should be defined", () => {
        expect(articleDetailContainerComponent).toBeDefined();
    });
})
