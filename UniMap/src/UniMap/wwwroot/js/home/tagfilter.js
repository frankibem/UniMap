/// <reference path="../lib/angular/angular.js" />

// Returns all events that have one or more of the given tags
angular.module('appModule')
    .filter('byTag', function () {
        return function (data, filterTextArray) {
            if (!filterTextArray || filterTextArray.length == 0)
                return data;

            var results = [];
            for (var i = 0; i < data.length; i++) {
                var tags = data[i].tags.map(tag => tag.name);
                for (var j = 0; j < filterTextArray.length; j++) {
                    if (tags.indexOf(filterTextArray[j]) > -1) {
                        results.push(data[i]);
                        break;
                    }
                }
            }
            return results;
        }
    });