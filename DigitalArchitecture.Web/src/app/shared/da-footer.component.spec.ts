describe("daFooter", () => {

    var daFooterComponent;
    var $compile;
    var $rootScope;

    class MockActionCreator { }

    beforeEach(() => {
        angular.mock.module("digitalArchitectureApp");
    });

    beforeEach(inject(($controller, _$compile_, _$rootScope_) => {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        daFooterComponent = $controller("daFooterComponent", { daFooterActionCreator: new MockActionCreator() });
    }));

    it("should compile", () => {
        var element = $compile("<da-footer></da-footer>")($rootScope);
        expect(element).toBeDefined();
    });

    it("should be defined", () => {
        expect(daFooterComponent).toBeDefined();
    });
})
