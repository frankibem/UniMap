/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('createCtrl', ['$scope', 'eventService',
        function ($scope, eventService) {
            $scope.newEvent = {};

            $scope.createEvent = () => {
                eventService.createEvent($scope.newEvent)
                    .then(function (response) {
                        console.log('Event created');
                        console.log($scope.newEvent);
                    });
            }
        }
    ]);