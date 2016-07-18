(function () {
    var app = angular.module('app');
    var controllerId = "app.views.books.createDialogBook";

    app.controller(controllerId, [
         '$uibModalInstance', 'params', '$scope', 'abp.services.app.book',
          function ($uibModalInstance, params, $scope, bookService) {
              var vm = this;
              
              vm.save = function () {
                  if (params.edit === true) {
                      vm.updateBook();
                  } else {

                      vm.createBook();
                  }
              };

              vm.book = {
                  id: undefined,
                  nome: undefined,
                  sobrenome: undefined,
                  idade: undefined,
                  tenantId: undefined
              };

              vm.getBookDatail = function (item) {
                  bookService.getDetail(item)
                      .success(function (data) {

                          vm.book.id = data.id;
                          vm.book.titulo = data.titulo;
                          vm.book.subtitulo = data.subtitulo;
                          vm.book.sinopse = data.sinopse;
                          vm.book.ano = data.ano;
                          vm.book.volume = data.volume;
                          vm.book.autor = data.autorId;
                          vm.book.editora = data.publisherId;
                          vm.book.tenantId = data.tenantId;

                      }).error(function (data) {

                          abp.notify.error("Erro ao carregar os dados ;(");
                      });
              };

              vm.updateBook = function () {
                  bookService.updateBookDto(vm.book)
                      .success(function (data) {
                          abp.notify.success("Livro Alterado com sucesso");
                          $uibModalInstance.close(true);
                      })
                      .error(function (data) {
                          abp.notify.error("Não foi possível alterar o Livro");
                      });
              }

              vm.createBook = function () {
                  vm.book = {
                      id: undefined,
                      titulo: $scope.createDialogBook.book.titulo,
                      subtitulo: $scope.createDialogBook.book.subtitulo,
                      sinopse: $scope.createDialogBook.book.sinopse,
                      ano: $scope.createDialogBook.book.ano,
                      volume: $scope.createDialogBook.book.volume,
                      autorId: $scope.createDialogBook.book.autorId,
                      publisherId: $scope.createDialogBook.book.publisherId,
                      tenantId: undefined
                  };

                  bookService.insertNewBook(vm.book)
                      .success(function (data) {
                          abp.notify.success("Livro Criado com sucesso");
                          $uibModalInstance.close(true);
                      }).error(function (data) {

                          abp.notify.error("Não foi possível criar o Livro");
                      });
              }
              vm.cancel = function () {
                  $uibModalInstance.dismiss('cancel');
              }

              function init() {

                  if (params.edit === true) {
                      vm.getBookDatail(params.bookId);
                  }
              };

              init();
          }
    ]);

})();










