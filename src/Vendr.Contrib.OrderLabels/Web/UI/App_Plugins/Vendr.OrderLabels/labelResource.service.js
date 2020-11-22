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
                        },
                        getLabel: function (alias, orderId) {
                            return umbRequestHelper.downloadFile('/umbraco/backoffice/vendr/label/GetLabel?alias=' + alias + '&orderId=' + orderId);
                        },
                        getLabels: function (alias, orderIds) {
                            return umbRequestHelper.downloadFile('/umbraco/backoffice/vendr/label/GetLabels?alias=' + alias + '&orderIds=' + orderIds);
                        }
                    }
                }
            ]);

}());