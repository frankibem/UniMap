/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('indexController', ['$scope', 'eventService',
        function ($scope, eventService) {
            $scope.filterText = "";

            $scope.filterByName = function (item) {
                var sub = $scope.filterText.toLowerCase();   
                return item.title.toLowerCase().indexOf(sub) > -1;
            }
        }
    ]);