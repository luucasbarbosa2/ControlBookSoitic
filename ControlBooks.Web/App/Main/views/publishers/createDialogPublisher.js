(function () {
    var app = angular.module('app');
    var controllerId = "app.views.publishers.createDialogPublisher";

    app.controller(controllerId,
    [
        '$uibModalInstance', 'params', '$scope', 'abp.services.app.publisher',
          function ($uibModalInstance, params, $scope, publisherService) {
              var vm = this;

             

              vm.save = function () {
                  if (params.edit === true) {
                      vm.updatePublisher();
                  } else {
                      vm.createPublisher();
                  }

              };

              vm.publisher = {
                  id: undefined,
                  nome: undefined,
                  descricao: undefined,
                  tenantId: undefined
              };

              vm.getPublisherDatail = function (item) {
                  publisherService.getDetail(item)
                      .success(function (data) {

                          vm.publisher.id = data.id;
                          vm.publisher.nome = data.nome;
                          $("#nome").val(data.nome);
                          vm.publisher.descricao = data.descricao;
                          $("#descricao").val(data.descricao);

                          vm.publisher.tenantId = data.tenantId;

                      }).error(function (data) {

                          abp.notify.error("Erro ao carregar os dados ;(");
                      });
              };

              vm.updatePublisher = function () {

                  vm.publisher = {
                      id: undefined,
                      nome: $scope.createDialogPublisher.publisher.nome,
                      descricao: $scope.createDialogPublisher.publisher.sobrenome,
                      tenantId: undefined
                  };
                  publisherService.updatePublisherDto(vm.publisher)
                      .success(function (data) {
                          abp.notify.success("Editora Alterada com sucesso");
                          $uibModalInstance.close(true);

                      })
                      .error(function (data) {
                          abp.notify.error("Não foi possível alterar a editora");
                      });
              }

              vm.createPublisher = function () {
                  vm.publisher = {
                      id: undefined,
                      nome: $scope.createDialogPublisher.publisher.nome,
                      descricao: $scope.createDialogPublisher.publisher.descricao,
                      tenantId: undefined
                  };


                  publisherService.insertNewPublisher(vm.publisher)
                      .success(function (data) {
                          abp.notify.success("Editora Criada com sucesso");
                          $uibModalInstance.close(true);
                      }).error(function (data) {

                          abp.notify.error("Não foi possível criar a editora");
                      });
              }
              vm.cancel = function () {
                  $uibModalInstance.dismiss('cancel');
              }

              function init() {

                  if (params.edit === true) {
                      vm.getPublisherDatail(params.publisherId);
                  }
              };

              init();
          }
          
    ]);

})();








