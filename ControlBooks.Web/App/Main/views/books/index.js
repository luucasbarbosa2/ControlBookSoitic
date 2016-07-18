

(function () {

    var app = angular.module('app');
    var controllerId = 'app.views.books.index';

    app.controller(controllerId,
    [
        '$scope', '$uibModal', 'abp.services.app.book',
        function ($scope, $uibModal, bookService) {
            var vm = this;
            vm.openDialog = function (item, isEdit) {
                var modalInstance = $uibModal.open({
                    templateUrl: abp.appPath + "App/Main/views/books/createDialogBook.cshtml",
                    controller: "app.views.books.createDialogBook as ctrDialogBook",
                    size: "md",
                    resolve: {
                        params: function () {
                            var params = {
                                bookId: item.id,
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

            vm.listBook = [];
            vm.getListBook = function () {
                bookService.getAllBook()
                    .success(function (result) {
                        vm.listBook = result.items;
                    }).error(function (result) {
                        abp.notify.error("Não foi possível carregar a lista de livros ;(");
                    });
            }


            vm.deleteBook = function (item) {
                var input = { item: item.id }

                bookService.deleteBook(item.id)
                    .success(function () {
                        abp.notify.success("Livro foi deletado com sucesso");
                        refreshTable();
                    }).error(function () {
                        abp.notify.error("Erro ao deletar");
                    });

            };

            function init() {
                vm.getListBook();
            };
            function refreshTable() {

                vm.listBook = [];
                vm.getListBook();
            }

            init();
        }
    ]);
})();