angular.module('app').controller('DashboardController', function ($scope, $state, $stateParams, TenantResource, PropertyResource, LeaseResource, WorkOrderResource) {
    $scope.tenants = TenantResource.query();
    $scope.properties = PropertyResource.query();
    $scope.leases = LeaseResource.query();
    $scope.workorders = WorkOrderResource.query();
});