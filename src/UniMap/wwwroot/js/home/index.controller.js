/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('indexCtrl', ['$scope', '$mdSidenav',
        function ($scope, $mdSidenav) {
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

            var script = document.createElement('script');
            script.src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyBPmQNyqp608U0rAZIk2vsbONq9suPmOxE&callback=initialize&libraries=drawing";
            script.type = "text/javascript";
            document.getElementsByTagName("body")[0].appendChild(script);
        }
    ]);