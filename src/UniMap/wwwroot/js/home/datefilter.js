/// <reference path="../lib/angular/angular.js" />

// Returns all events that occured on the given day
angular.module('appModule')
    .filter('byDate', function () {
        function within(x, left, right){
            return left <= x && x <= right;
        }

        return function (data, filterDate) {
            if (!filterDate)
                return data;

            var results = [];
            var next = new Date(filterDate);
            next.setDate(next.getDate() + 1);

            var left = filterDate.getTime();
            var right = next.getTime();

            for (var i = 0; i < data.length; i++) {
                var start = data[i].startOn.getTime();
                var end = data[i].endOn.getTime();

                if (within(start, left, right) || within(end, left, right)) {
                    results.push(data[i]);
                }
            }
            console.log(results);
            return results;
        }
    });