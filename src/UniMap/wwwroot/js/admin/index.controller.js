angular.module('appModule')
    .controller('indexController', ['$scope', 'eventService',
        function ($scope, eventService) {
            $scope.filterText = "";

            $scope.filterByName = function (item) {
                var sub = $scope.filterText.toLowerCase();
                
                // TODO: Complete
            }
        }
    ]);