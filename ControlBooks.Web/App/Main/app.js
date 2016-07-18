(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in ControlBooksNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in ControlBooksNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in ControlBooksNavigationProvider
                })
                .state('authors', {
                    url: '/authors',
                    templateUrl: '/App/Main/views/authors/index.cshtml',
                    menu: 'Authors' //Matches to name of 'Authors' menu in ControlBooksNavigationProvider
                })
                .state('publishers', {
                    url: '/publishers',
                    templateUrl: '/App/Main/views/publishers/index.cshtml',
                    menu: 'Publishers' //Matches to name of 'Publishers' menu in ControlBooksNavigationProvider
                })
                .state('books', {
                    url: '/books',
                    templateUrl: '/App/Main/views/books/index.cshtml',
                    menu: 'Books' //Matches to name of 'Books' menu in ControlBooksNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in ControlBooksNavigationProvider
                });
        }
    ]);
})();