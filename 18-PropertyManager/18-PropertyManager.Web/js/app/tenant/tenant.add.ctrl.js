angular.module('app').controller('TenantAddController', function ($scope, TenantResource) {
    $scope.saveTenant = function () {
        TenantResource.save($scope.tenant, function () {
            $scope.tenant = {};
            alert("Saved Successfully");
            location.replace('/#/app/tenant/grid')
        });
    };
});