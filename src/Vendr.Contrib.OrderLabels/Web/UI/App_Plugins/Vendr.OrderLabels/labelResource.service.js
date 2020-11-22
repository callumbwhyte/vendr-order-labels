(function () {

    'use strict';

    angular.module('vendr')
        .factory('vendrOrderLabelResource',
            ['$http', 'umbRequestHelper',
                function ($http, umbRequestHelper) {
                    return {
                        getGenerators: function () {
                            return umbRequestHelper.resourcePromise(
                                $http.get('/umbraco/backoffice/vendr/label/GetGenerators')
                            );
                        }
                    }
                }
            ]);

}());