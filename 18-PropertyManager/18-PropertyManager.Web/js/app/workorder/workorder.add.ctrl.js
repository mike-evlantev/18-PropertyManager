angular.module('app').controller('WorkOrderAddController', function ($scope, WorkOrderResource) {

    $scope.saveWorkOrder = function () {
        WorkOrderResource.save($scope.workorder, function () {
            $scope.workorder = {};
            alert("Saved Successfully");
            location.replace('/#/app/workorder/grid')
        });
    };
});