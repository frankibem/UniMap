/// <reference path="../lib/angular/angular.js" />

// Remark: Controller scope should provide initMap()
function initMap() {
    angular.element($('#map')).scope().initMap();
}