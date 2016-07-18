

(function () {

    var app = angular.module('app');
    var controllerId = 'app.views.publishers.index';

    app.controller(controllerId,
    [
        '$scope', '$uibModal', 'abp.services.app.publisher',
        function ($scope, $uibModal, publisherService) {
            var vm = this;

            vm.openDialog = function (item, isEdit) {
                
                var modalInstance = $uibModal.open({
                    templateUrl: abp.appPath + "App/Main/views/publishers/createDialogPublisher.cshtml",
                    controller: "app.views.publishers.createDialogPublisher as ctrDialogPublisher",
                    size: "md",
                    resolve: {
                        params: function () {
                            var params = {
                                publisherId: item.id,
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




            vm.listPublisher = [];
            vm.getListPublisher = function () {
                publisherService.getAllPublisher()
                    .success(function (result) {
                        vm.listPublisher = result.items;

                    }).error(function (result) {
                        abp.notify.error("Não foi possível carregar a lista de Editoras ;(");
                    });
            }





            vm.deletePublisher = function (item) {
                var input = { item: item.id }

                publisherService.deletePublisher(item.id)
                    .success(function () {
                        abp.notify.success("A editora foi deletado com sucesso");
                        refreshTable();
                    }).error(function () {
                        abp.notify.error("Erro ao deletar");
                    });

            };

            function init() {
                vm.getListPublisher();
            };
            function refreshTable() {
               
                vm.listPublisher = [];
                vm.getListPublisher();
            }

            init();
        }
    ]);
})();