angular.module('app').controller('PropertyAddController', function ($scope, PropertyResource) {
    $scope.saveProperty = function () {
        PropertyResource.save($scope.property, function () {
            $scope.property = {};
            alert("Saved Successfully");
            location.replace('/#/app/property/grid')
        });
    };
});