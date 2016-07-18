

(function() {

    var app = angular.module('app');
    var controllerId = 'app.views.authors.index';

    app.controller(controllerId,
    [
        '$scope', '$uibModal', 'abp.services.app.autor',
        function($scope, $uibModal, autorService) {
            var vm = this;
            vm.listAutor = [];
            vm.getListAutor = function() {
                autorService.getAllAutor()
                    .success(function (result) {
                        vm.listAutor = result.items;
                        
                    }).error(function(result) {
                    abp.notify.error("Não foi possível carregar a lista de autores ;(");
                });
            }

            vm.openDialog = function (item, isEdit) {
               
               var modalInstance = $uibModal.open({
                    templateUrl: abp.appPath + "App/Main/views/authors/createDialogAutor.cshtml",
                    controller: "app.views.authors.createDialogAutor as ctrDialogAutor",
                    size: "md",
                    resolve: {
                        params: function() {
                            var params = {
                                autorId: item.id,
                                edit: isEdit
                            }
                            return params;
                        }
                    }
                });
               modalInstance.result.then(function (result) {
                   if (result === true) {
                       refreshTable();
                   }

                    
                });


            };



            vm.deleteAutor = function (item) {
                var input = {item: item.id}
               
                autorService.deleteAutor(item.id)
                    .success(function() {
                        abp.notify.success("O autor foi deletado com sucesso");
                        refreshTable();
                    }).error(function() {
                        abp.notify.error("Erro ao deletar")
                    });
                
            };

            function init() {
                vm.getListAutor();
            };
            function refreshTable() {
              
                vm.listAutor = [];
                vm.getListAutor();
            }

            init();
        }
    ]);
})();