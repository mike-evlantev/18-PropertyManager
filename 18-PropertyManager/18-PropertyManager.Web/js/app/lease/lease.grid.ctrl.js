angular.module('app').controller('LeaseGridController', function ($scope, LeaseResource) {
    function activate() {
        $scope.leases = LeaseResource.query();
    }

    $scope.deleteLease = function (lease) {
        LeaseResource.delete({ leaseId: lease.LeaseId }, function () {
            alert("Deleted Successfully");
            activate();
        });
    };
    activate();
});