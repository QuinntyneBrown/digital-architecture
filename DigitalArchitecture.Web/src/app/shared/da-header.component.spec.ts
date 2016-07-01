describe("daHeader", () => {

    var daHeaderComponent;
    var $compile;
    var $rootScope;

    class MockActionCreator { }

    beforeEach(() => {
        angular.mock.module("digitalArchitectureApp");
    });

    beforeEach(inject(($controller, _$compile_, _$rootScope_) => {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        daHeaderComponent = $controller("daHeaderComponent", { daHeaderActionCreator: new MockActionCreator() });
    }));

    it("should compile", () => {
        var element = $compile("<da-header></da-header>")($rootScope);
        expect(element).toBeDefined();
    });

    it("should be defined", () => {
        expect(daHeaderComponent).toBeDefined();
    });
})
