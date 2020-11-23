(function () {

    'use strict';

    angular.module('vendr')
        .factory('vendrOrderLabelResource',
            ['$http', 'umbRequestHelper',
                function ($http, umbRequestHelper) {
                    return {
                        getGenerators: function () {
                            return umbRequestHelper.resourcePromise(
                                $http({
                                    url: '/umbraco/backoffice/vendr/label/GetGenerators',
                                    method: 'GET'
                                })
                            );
                        },
                        getLabel: function (alias, orderId) {
                            return umbRequestHelper.downloadFile('/umbraco/backoffice/vendr/label/GetLabel?alias=' + alias + '&orderId=' + orderId)
                                .then(function () {
                                    return {};
                                });
                        },
                        getLabels: function (alias, orderIds) {
                            return umbRequestHelper.downloadFile('/umbraco/backoffice/vendr/label/GetLabels?alias=' + alias + '&orderIds=' + orderIds)
                                .then(function () {
                                    return {};
                                });
                        }
                    }
                }
            ]);

}());