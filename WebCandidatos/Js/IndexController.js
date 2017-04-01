(function () {
    'use strict';

    angular.module('myApp').controller('IndexController', ['$scope', '$http', function ($scope, $http) {
        $scope.candidato = {};
        $scope.enviar = function () {
            $http.post('/HomeController', JSON.stringify($scope.candidato))
                .then(function (data) {
                    console.log("sucesso!");
                }, function (data) {
                    console.log("erro!" + JSON.stringify(data));

                });
            alert("Enviado");
        }
    }]);
}());