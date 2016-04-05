﻿angular.module('app').controller('AppController', function ($scope, localStorageService, AuthenticationService) {
    var usr = localStorageService.get('user');
    $scope.user = usr.user;

    // function activate() {
    //     $http.get(apiUrl + '/pawzeuser/user')
    //       .then(function (response) {
    //           $scope.user = response.data;
    //       })
    //       .catch(function (err) {
    //           // bootbox.alert('Please re-enter your ');
    //       });
    // };
    // 
    // activate();

    $scope.logout = function () {
        AuthenticationService.logout();
        location.replace('#/home');
    }
});