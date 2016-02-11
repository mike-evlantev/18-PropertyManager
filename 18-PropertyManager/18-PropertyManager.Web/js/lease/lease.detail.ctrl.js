angular.module('app').controller('LeaseDetailController', function ($scope, $stateParams, LeaseResource) {
    console.log($stateParams)
    // grab the property from /api/properties/{propertyId}
    $scope.lease = LeaseResource.get({ leaseId: $stateParams.id });

    $scope.saveLease = function () {
        $scope.lease.$update(function () {
            alert("Saved Successfully");
        });
    };
});