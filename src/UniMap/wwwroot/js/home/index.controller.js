/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .controller('indexCtrl', ['$scope', '$mdSidenav', '$mdDialog', 'eventService', 'mapService',
        function ($scope, $mdSidenav, $mdDialog, eventService, mapService) {
            $scope.today = new Date();
            $scope.curdate = new Date();
            $scope.events = [];
            $scope.tags = [];
            $scope.filterText = '';
            $scope.selectedEvent = null;

            var dialog;
            var infowindow;

            $scope.initMap = () => {
                $scope.$apply(() => {
                    var myLocation = new google.maps.LatLng(33.607601, -101.936684);
                    $scope.map = new google.maps.Map(document.getElementById('map'), {
                        center: myLocation,
                        zoom: 17
                    });

                    loadEvents();

                    dialog = $('#dialog')[0];
                    infowindow = new google.maps.InfoWindow({ content: dialog });
                });
            }

            $scope.toggleSidenav = () => {
                $mdSidenav('left').toggle();
            }

            mapService.init();

            function loadEvents() {
                eventService.getEvents()
                    .then(function (response) {
                        var events = response.data;
                        $scope.events = events.map(function (item) {
                            item.endOn = new Date(item.endOn);
                            item.startOn = new Date(item.startOn);
                            return item;
                        });

                        $scope.tags = getTags($scope.events);
                        drawMarkers();
                    });
            }

            function drawMarkers() {
                for (var i = 0; i < $scope.events.length; i++) {
                    var event = $scope.events[i];
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(event.latitude, event.longitude),
                        map: $scope.map,
                        title: event.title
                    });
                    event.marker = marker;
                }
            }

            function getTags(events) {
                var tags = []
                for (var i = 0; i < events.length; i++) {
                    tags = tags.concat(events[i].tags);
                }
                tags = tags.map(tag => tag.name);
                return tags.filter((v, i, a) => a.indexOf(v) == i);
            }

            // Pan to marker when its nav entry is clicked
            $scope.centerOnMap = (event) => {
                $scope.selectedEvent = event;
                $scope.toggleSidenav();
                $scope.map.panTo(event.marker.getPosition());

                infowindow.open($scope.map, event.marker);
            }

            $scope.closeInfoWindow = () => {
                infowindow.close();
            }

            $scope.mapUrl = (event) => {
                if (event) {
                    return `https://www.google.com/maps/place/${event.address}/@${event.latitude},${event.longitude},17z`;
                }
                return null;
            }
        }
    ]);