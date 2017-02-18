/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('indexCtrl', ['$scope', '$mdSidenav', 'eventService', 'mapService',
        function ($scope, $mdSidenav, eventService, mapService) {
            $scope.curdate = null;
            $scope.events = [];
            $scope.tags = [];
            $scope.activeTags = [];

            $scope.initMap = () => {
                $scope.$apply(() => {
                    var myLocation = new google.maps.LatLng(33.607601, -101.936684);
                    $scope.map = new google.maps.Map(document.getElementById('map'), {
                        center: myLocation,
                        zoom: 17
                    });
                });
            }

            $scope.openLeftMenu = () => {
                $mdSidenav('left').toggle();
            }

            mapService.init();

            eventService.getEvents()
                .then(function (response) {
                    console.log(response.data);
                });
        }
    ]);