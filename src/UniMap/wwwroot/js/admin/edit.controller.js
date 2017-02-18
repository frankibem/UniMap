/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('editCtrl', ['$scope', 'eventService', 'selectedEvent',
        function ($scope, eventService, selectedEvent) {
            $scope.selectedEvent = selectedEvent;

            $scope.updateEvent = () => {
                eventService.updateEvent($scope.selectedEvent)
                    .then(function (response) {
                        console.log('Event successfully updated');
                        console.log(response);
                    });
            }

            $scope.deleteEvent = () => {
                eventService.deleteEvent($scope.selectedEvent.id)
                    .then(function (response) {
                        console.log('Event successfully deleted');
                        console.log(response);
                    });
            }
        }
    ]);