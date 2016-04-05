﻿angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule']);

angular.module('app').value('apiUrl', 'http://localhost:50101/api');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');

    $urlRouterProvider.otherwise('home');

    $stateProvider
        .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController' })
        .state('register', { url: '/register', templateUrl: '/templates/home/register/register.html', controller: 'RegisterController' })
        .state('login', { url: '/login', templateUrl: '/templates/home/login/login.html', controller: 'LoginController' })
        

        .state('app', { url: '/app', templateUrl: '/templates/app/app.html', controller: 'AppController' })
            .state('app.dashboard', { url: '/dashboard', templateUrl: '/templates/app/dashboard/dashboard.html', controller: 'DashboardController' })

            .state('app.property', { url: '/property', abstract: true, template: '<ui-view/>' })
                .state('app.property.grid', { url: '/grid', templateUrl: '/templates/app/property/property.grid.html', controller: 'PropertyGridController' })
                .state('app.property.detail', { url: '/detail/:id', templateUrl: '/templates/app/property/property.detail.html', controller: 'PropertyDetailController' })
                .state('app.property.add', { url: '/add', templateUrl: '/templates/app/property/property.detail.html', controller: 'PropertyAddController' })
                
            .state('app.tenant', { url: '/tenant', abstract: true, template: '<ui-view/>' })
                .state('app.tenant.grid', { url: '/grid', templateUrl: '/templates/app/tenant/tenant.grid.html', controller: 'TenantGridController' })
                .state('app.tenant.detail', { url: '/detail/:id', templateUrl: '/templates/app/tenant/tenant.detail.html', controller: 'TenantDetailController' })
                .state('app.tenant.add', { url: '/add', templateUrl: '/templates/app/tenant/tenant.detail.html', controller: 'TenantAddController' })

            .state('app.lease', { url: '/lease', abstract: true, template: '<ui-view/>' })
                .state('app.lease.grid', { url: '/grid', templateUrl: '/templates/app/lease/lease.grid.html', controller: 'LeaseGridController' })
                .state('app.lease.detail', { url: '/detail/:id', templateUrl: '/templates/app/lease/lease.detail.html', controller: 'LeaseDetailController' })
                .state('app.lease.add', { url: '/add', templateUrl: '/templates/app/lease/lease.detail.html', controller: 'LeaseAddController' })

            .state('app.workorder', { url: '/workorder', abstract: true, template: '<ui-view/>' })
                .state('app.workorder.grid', { url: '/grid', templateUrl: '/templates/app/workorder/workorder.grid.html', controller: 'WorkOrderGridController' })
                .state('app.workorder.detail', { url: '/detail/:id', templateUrl: '/templates/app/workorder/workorder.detail.html', controller: 'WorkOrderDetailController' })
                .state('app.workorder.add', { url: '/add', templateUrl: '/templates/app/workorder/workorder.detail.html', controller: 'WorkOrderAddController' });

});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});