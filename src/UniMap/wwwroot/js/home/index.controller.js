/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('indexCtrl', ['$scope', '$mdSidenav', 'mapService',
        function ($scope, $mdSidenav, mapService) {
            $scope.initMap = () => {
                $scope.$apply(() => {
                    var myLocation = new google.maps.LatLng(33.607601, -101.936684);
                    $scope.map = new google.maps.Map(document.getElementById('map'), {
                        center: myLocation,
                        zoom: 17
                    });
                });
            }

            mapService.init();
        }
    ]);