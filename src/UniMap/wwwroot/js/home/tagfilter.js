/// <reference path="../lib/angular/angular.js" />

angular.module('appModule')
    .filter('byTag', function () {
        return function (data, filterTextArray) {
            if (!filterTextArray || filterTextArray.length == 0)
                return data;

            console.log(filterTextArray);
            var results = [];

            for (var i = 0; i < data.length; i++) {
                var tags = data[i].tags.map(tag => tag.name);
                for (var j = 0; j < filterTextArray.length; j++) {
                    if (tags.indexOf(filterTextArray[i]) > -1) {
                        results.push(data[i]);
                        break;
                    }
                }
                return results;
            }
        }
    });