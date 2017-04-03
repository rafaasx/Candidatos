(function () {
    'use strict';

    angular.module('myApp').controller('IndexController', ['$scope', '$http', function ($scope, $http, $uibModal) {
        $scope.candidato = {nome:'Rafael Xavier', email : 'rafael.asxavier@gmail.com'};
        $scope.retorno = {};

        var $ctrl = this;
        $ctrl.items = ['item1', 'item2', 'item3'];

        $ctrl.animationsEnabled = true;

        $ctrl.open = function (size, parentSelector) {
            var parentElem = parentSelector ?
              angular.element($document[0].querySelector('.modal-demo ' + parentSelector)) : undefined;
            var modalInstance = $uibModal.open({
                animation: $ctrl.animationsEnabled,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                controllerAs: '$ctrl',
                size: size,
                appendTo: parentElem,
                resolve: {
                    items: function () {
                        return $ctrl.items;
                    }
                }
            });
        };

            $scope.enviar = function () {
                $http.post('/Home/Enviar', JSON.stringify($scope.candidato))
                    .then(function (data) {
                        console.log("sucesso!");
                        //$ctrl.open()
                    }, function (data) {
                        $scope.retorno = data
                        console.log("erro!");

                    });
            }
        }]);
    }());