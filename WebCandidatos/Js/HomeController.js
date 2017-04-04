angular.module("myApp").controller("HomeController", ["$scope", "$http", "$uibModal", function ($scope, $http, $uibModal) {

    $scope.processando = false;
    $scope.retorno = {};

    $scope.clean = function () {
        $scope.candidato = { Nome: "", Email: "", Html: "", Css: "", Django: "", Javascript: "", Python: "", Ios: "", Android: "" };
        $("#input-html").rating("clear");
        $("#input-css").rating("clear");
        $("#input-javascript").rating("clear");
        $("#input-python").rating("clear");
        $("#input-django").rating("clear");
        $("#input-ios").rating("clear");
        $("#input-android").rating("clear");
    }

    var $modal = this;
    $modal.open = function () {
        var modalInstance = $uibModal.open({ templateUrl: "Modal.html", controller: "HomeController", controllerAs: "$modal" });
    };

    $scope.enviar = function () {
        $scope.processando = true;
        $http.post("/Home/Enviar", JSON.stringify($scope.candidato), {
            headers: {
                'Content-Type': "application/json"
            }
        })
            .then(function (data) {
                $scope.retorno = data;
                $scope.processando = false;
                $scope.clean();
                $modal.open();
            }, function (data) {
                $scope.retorno = data;
                $scope.processando = false;
                $modal.open();
            });
    }
}]);
