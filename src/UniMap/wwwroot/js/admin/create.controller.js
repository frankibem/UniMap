/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('createCtrl', ['$scope', '$mdDialog', 'eventService', 'mapService',
        function ($scope, $mdDialog, eventService, mapService) {
            $scope.newEvent = {};
            var geocoder = null;

            $scope.createEvent = () => {
                $scope.newEvent.startOn.setHours($scope.newEvent.startHour);
                $scope.newEvent.startOn.setMinutes($scope.newEvent.startMinute);
                $scope.newEvent.endOn.setHours($scope.newEvent.endHour);
                $scope.newEvent.endOn.setMinutes($scope.newEvent.endMinute);

                eventService.createEvent($scope.newEvent)
                    .then(function (response) {
                        console.log('Event created');
                        console.log($scope.newEvent);
                        location.href = "/admin";
                    });
            }

            $scope.initMap = () => {
                $scope.$apply(() => {
                    var myLocation = new google.maps.LatLng(33.607601, -101.936684);
                    $scope.map = new google.maps.Map(document.getElementById('small_map'), {
                        center: myLocation,
                        zoom: 17
                    });

                    geocoder = new google.maps.Geocoder();
                });
            }

            mapService.init();

            $scope.hours = new Array(24)
            for (var i = 0; i < 24; i++) {
                $scope.hours[i] = i;
            }

            $scope.minutes = new Array(60)
            for (var i = 0; i < 60; i++) {
                $scope.minutes[i] = i;
            }

            $scope.transcode = (address) => {
                geocoder.geocode({ 'address': address }, function (results, status) {
                    if (status == 'OK') {
                        $scope.map.setCenter(results[0].geometry.location);
                        var marker = new google.maps.Marker({
                            map: $scope.map,
                            position: results[0].geometry.location
                        });
                        $scope.newEvent.latitude = results[0].geometry.location.lat();
                        $scope.newEvent.longitude = results[0].geometry.location.lng();
                    } else {
                        alert('Geocode was not successful for the following reason: ' + status);
                    }
                });
            }
        }
    ]);