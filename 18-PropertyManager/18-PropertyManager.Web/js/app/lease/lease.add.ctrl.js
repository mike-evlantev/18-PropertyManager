angular.module('app').controller('LeaseAddController', function ($scope, LeaseResource) {
    $scope.saveLease = function () {
        LeaseResource.save($scope.lease, function () {
            $scope.lease = {};
            alert("Saved Successfully");
            location.replace('/#/app/lease/grid')
        });
    };
});