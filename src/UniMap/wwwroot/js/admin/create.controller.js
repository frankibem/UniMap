/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('createCtrl', ['$scope', '$mdDialog', 'eventService', 'mapService',
        function ($scope, $mdDialog, eventService, mapService) {
            $scope.newEvent = {};

            $scope.createEvent = () => {
                eventService.createEvent($scope.newEvent)
                    .then(function (response) {
                        console.log('Event created');
                        console.log($scope.newEvent);
                    });
            }

            $scope.initMap = () => {
                $scope.$apply(() => {
                    var myLocation = new google.maps.LatLng(33.607601, -101.936684);
                    $scope.map = new google.maps.Map(document.getElementById('small_map'), {
                        center: myLocation,
                        zoom: 17
                    });
                });
            }

            mapService.init();
        }
    ]);