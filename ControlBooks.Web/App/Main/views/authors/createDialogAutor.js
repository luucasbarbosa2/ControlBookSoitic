(function() {
    var app = angular.module('app');
    var controllerId = "app.views.authors.createDialogAutor";

    app.controller(controllerId, [
         '$uibModalInstance', 'params', '$scope', 'abp.services.app.autor',
          function ($uibModalInstance, params, $scope, autorService) {
            var vm = this;

            

            vm.save = function () {
                if (params.edit === true) {
                    vm.updateAutor();
                } else {
                    vm.createAutor();
                }

            };
            
            vm.autor = {
                id: undefined,
                nome: undefined,
                sobrenome: undefined,
                idade: undefined,
                tenantId: undefined
            };

            vm.getAutorDatail = function (item) {
                autorService.getDetail(item)
                    .success(function (data) {
                   
                    vm.autor.id = data.id; 
                    vm.autor.nome = data.nome;
                    $("#nome").val(data.nome);
                    vm.autor.sobrenome = data.sobrenome;
                    $("#sobrenome").val(data.sobrenome);
                    vm.autor.idade = data.idade;
                    $("#idade").val(data.idade);
                    vm.autor.tenantId = data.tenantId;

                }).error(function (data) {

                    abp.notify.error("Erro ao carregar os dados ;(");
                });
            };

            vm.updateAutor = function () {

                vm.autor = {
                    id: undefined,
                    nome: $scope.createDialogAutor.autor.nome,
                    sobrenome: $scope.createDialogAutor.autor.sobrenome,
                    idade: $scope.createDialogAutor.autor.idade,
                    tenantId: undefined
                };
                autorService.updateAutorDto(vm.autor)
                    .success(function(data) {
                        abp.notify.success("Autor Alterado com sucesso");
                        $uibModalInstance.close(true);
                        
                    })
                    .error(function(data) {
                        abp.notify.error("Não foi possível alterar o autor");
                    });
            }

            vm.createAutor = function () {
                vm.autor = {
                    id: undefined,
                    nome: $scope.createDialogAutor.autor.nome,
                    sobrenome: $scope.createDialogAutor.autor.sobrenome,
                    idade: $scope.createDialogAutor.autor.idade,
                    tenantId: undefined
                };

              
                autorService.insertNewAutor(vm.autor)
                    .success(function (data) {
                        abp.notify.success("Autor Criado com sucesso");
                        $uibModalInstance.close(true);
                    }).error(function (data) {
                       
                        abp.notify.error("Não foi possível criar o autor");
                    });
            }
            vm.cancel = function() {
                $uibModalInstance.dismiss('cancel');
            }

            function init() {
               
                if (params.edit === true) {
                    vm.getAutorDatail(params.autorId);
                }
            };

            init();
        }
    ]);

})();










/*(function() {
    var app = angular.module('app')
        .controller('app.views.authors.createDialogAutor',
        [
            '$uiModalInstance', 'params', '$scope',
            function($uibModalInstance, params, $scope) {
                var vm = this;
            }
        ]);


})();*/