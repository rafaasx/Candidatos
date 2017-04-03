(function () {
    'use strict';

    angular.module('myApp').controller('HomeController', ['$scope', '$http', function ($scope, $http, $uibModal) {
        
        $scope.processando = false;

        $scope.retorno = {};
        $scope.clean = function () {
            $scope.candidato = {};
            $("#input-html").rating("clear");
            $("#input-css").rating("clear");
            $("#input-javascript").rating("clear");
            $("#input-python").rating("clear");
            $("#input-django").rating("clear");
            $("#input-ios").rating("clear");
            $("#input-android").rating("clear");
        }
        $scope.clean();
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
            $scope.processando = true;
            $http.post('/Home/Enviar', JSON.stringify($scope.candidato), {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(function (data) {
                    console.log("sucesso!");
                    $scope.retorno = data;
                    $scope.processando = false;
                    $scope.clean();
                //$ctrl.open()
            }, function (data) {
                    $scope.retorno = data;
                    console.log("erro!");
                    $scope.processando = false;

                });
        }
    }]);
}());