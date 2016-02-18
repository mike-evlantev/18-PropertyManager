angular.module('app').controller('PropertyGridController', function ($scope, PropertyResource) {
    function activate() {
        $scope.properties = PropertyResource.query();
    }

    $scope.deleteProperty = function (property) {
        PropertyResource.delete({ propertyId: property.PropertyId }, function () {
            alert("Deleted Successfully");
            activate();
        });        
    };
    activate();
});