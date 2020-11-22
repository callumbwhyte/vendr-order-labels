(function () {

    'use strict';

    angular.module('vendr')
        .config(['vendrOrderLabelResourceProvider', 'vendrActionsProvider',
            function (vendrOrderLabelResourceProvider, vendrActionsProvider) {
                vendrOrderLabelResourceProvider.$get()
                    .getGenerators()
                        .then(function (response) {
                            response.forEach(function (generator) {
                                vendrActionsProvider.bulkActions.push(createAction(generator));
                            });
                        });

                function createAction(generator) {
                    return ['vendrOrderLabelResource',
                        function (vendrOrderLabelResource) {
                            return {
                                name: 'Generate ' + generator.name,
                                icon: 'icon-box',
                                doAction: function (bulkItem) {
                                    return vendrOrderLabelResource.getLabel(generator.alias, bulkItem.id);
                                },
                                condition: function (ctx) {
                                    return ctx.entityType.includes('Order');
                                }
                            }
                        }
                    ];
                }
            }
        ]);

}());