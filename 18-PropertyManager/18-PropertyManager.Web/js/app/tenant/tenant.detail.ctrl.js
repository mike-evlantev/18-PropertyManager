angular.module('app').controller('TenantDetailController', function ($scope, $stateParams, TenantResource) {
    console.log($stateParams)
    // grab the property from /api/properties/{propertyId}
    $scope.tenant = TenantResource.get({ tenantId: $stateParams.id });

    $scope.saveTenant = function () {
        $scope.tenant.$update(function () {
            alert("Saved Successfully");
        });
    };
});