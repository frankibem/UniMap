/// <reference path="../lib/angular/angular.js" />

// Remark: Controller scope should provide initMap()
function initialize() {
    angular.element($('#map')).scope().initMap();
}