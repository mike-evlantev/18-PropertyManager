angular.module('app').controller('PropertyDetailController', function($scope, $stateParams, PropertyResource){
    console.log($stateParams)
    // grab the property from /api/properties/{propertyId}
    $scope.property = PropertyResource.get({ propertyId: $stateParams.id });

    $scope.saveProperty = function () {
        $scope.property.$update(function () {
            alert("Saved Successfully");
        });
    };
});