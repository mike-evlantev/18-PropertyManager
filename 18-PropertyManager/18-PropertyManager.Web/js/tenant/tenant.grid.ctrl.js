angular.module('app').controller('TenantGridController', function ($scope, TenantResource) {
    function activate() {
        $scope.tenants = TenantResource.query();
    }

    $scope.deleteTenant = function (tenant) {
        TenantResource.delete({ tenantId: tenant.TenantId }, function () {
            alert("Deleted Successfully");
            activate();
        });
    };
    activate();
});