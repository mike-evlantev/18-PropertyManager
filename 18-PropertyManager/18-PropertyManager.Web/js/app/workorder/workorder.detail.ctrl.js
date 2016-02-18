angular.module('app').controller('WorkOrderDetailController', function ($scope, $stateParams, WorkOrderResource) {
    console.log($stateParams)
    // grab the property from /api/properties/{propertyId}
    $scope.workorder = WorkOrderResource.get({ workorderId: $stateParams.id });

    $scope.saveWorkOrder = function () {
        $scope.workorder.$update(function () {
            alert("Saved Successfully");
        });
    };
});