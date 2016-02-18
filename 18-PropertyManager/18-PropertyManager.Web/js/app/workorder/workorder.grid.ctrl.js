angular.module('app').controller('WorkOrderGridController', function ($scope, WorkOrderResource) {
    function activate() {
        $scope.workorders = WorkOrderResource.query();
    }

    $scope.deleteWorkOrder = function (workorder) {
        WorkOrderResource.delete({ workorderId: workorder.WorkOrderId }, function () {
            alert("Deleted Successfully");
            activate();
        });
    };
    activate();
});