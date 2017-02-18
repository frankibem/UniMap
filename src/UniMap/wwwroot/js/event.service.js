angular.module('appModule', [])
    .factory('eventService', function ($http) {
        return {
            getEvents: () => {
                return $http.get('/api/event');
            },

            createEvent: (event) => {
                return $http.post('/api/event', event);
            },

            updateEvent: (event) => {
                return $http.put('/api/event', event);
            },

            deleteEvent: (id) => {
                return $http.delete('/api/event/' + id);
            }
        }
    });