/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .factory('mapService', function () {
        return {
            init: () => {
                var script = document.createElement('script');
                script.src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyBPmQNyqp608U0rAZIk2vsbONq9suPmOxE&callback=initialize";
                script.type = "text/javascript";
                document.getElementsByTagName("body")[0].appendChild(script);
            }
        }
    });