var webApp = angular.module('webApp', ['ngRoute', 'ngResource', 'ui.grid', 'ui.bootstrap', 'ui.grid.edit', 'ui.grid.cellNav']);

webApp.config(function ($routeProvider) {
    
    $routeProvider

        .when('/', {
            templateUrl: 'Content/AngularApp/grid.html',
            controller: 'mainController as vm'
        })
});

webApp.controller('mainController', function ($scope, $uibModal, $resource, uiGridConstants) {
    var vm = this;
    vm.message = 'Everyone come and see how good I look!';


    var ContactsResource = $resource('/api/contacts/:id', null,
            {
                'update': { method:'PUT' }
            }
        );
        
        
    
    
    
    vm.Contacts = ContactsResource.query(function () {
        console.log(vm.Contacts);
    });

    vm.gridOptions = {
        appScopeProvider: vm,
        enableFiltering: true,
        enableGridMenu: true,
        onRegisterApi: function (gridApi) {
            vm.gridApi = gridApi;
        },
        paginationPageSizes: [25, 50, 100],
        data: vm.Contacts,
        columnDefs: [
            {
                field: "FirstName",
                name: "FirstName"
            },
            {
                field: "LastName",
                name: "LastName",
            },
            {
                field: "Knickname",
                name: "Knickname",
            },
            {
                field: "DisplayAs",
                name: "DisplayAs",
            },
            {
                field: "PhoneNumber",
                name: "PhoneNumber",
            },
            {
                field: "DateOfBirth",
                name: "DateOfBirth",
            },
            {
                field: "State",
                visible: false,
                filter: {
                    condition: uiGridConstants.filter.NOT_EQUAL,
                    term: 'deleted'
                }
            },
            {
                name: "Actions",
                field: "Id",
                enableFiltering: false,
                enableSorting: false,
                cellEditableCondition: false,
                width: 300,
                cellTemplate: '<div class="ui-grid-cell-contents">' +
                    '<a class="btn btn-info btn-sm" style="border: 0px; padding: 0px" data-ng-click="grid.appScope.editContact(COL_FIELD)">' +
                    '<span class="">Edit</span>' +
                    '</a> &nbsp;' +
                    '<a class="btn btn-danger btn-sm" style="border: 0px; padding: 0px" data-ng-click="grid.appScope.deleteContact(COL_FIELD)">' +
                    '<span class="">Delete</span>' +
                    '</div>'
            }
        ]
    };


    var modalInstance;
    function openModal(template) {
        modalInstance = $uibModal.open({
            templateUrl: template,
            scope: $scope,
            windowClass: 'full-modal-window',
            backdrop: 'static',
        });

    }
    vm.closeModal = function () {
        modalInstance.close();
    }

    vm.newContact = function () {
        vm.TempContact = {
            Id: 0,
        };
        vm.Update = false;
        openModal('/Content/AngularApp/ContactModal.html')
    }

    vm.editContact = function (id) {
        vm.Update = true;
        angular.forEach(vm.Contacts, function (contact) {
            if (contact.Id == id) {
                vm.TempContact = contact;
            }
        })
        openModal('/Content/AngularApp/ContactModal.html')
    }

    vm.deleteContact = function (id) {
        angular.forEach(vm.Contacts, function (contact) {
            if (contact.Id == id) {
                vm.TempContact = contact;
                vm.TempContact.State = 'deleted';
            }
        })
        vm.save('Delete')
    }

    vm.save = function (state) {
        if (state === 'Update') {
            var promise = ContactsResource.update( { id: vm.TempContact.Id }, vm.TempContact).$promise;
        }
        else if (state === 'Save') {
            var promise = ContactsResource.save(vm.TempContact).$promise;
        }
        else if (state === 'Delete') {
            var promise = ContactsResource.delete({ id: vm.TempContact.Id }).$promise;
        }
        promise.then(success, failure);

        function success(data) {
            if (state === 'Save')
                vm.gridOptions.data.push(data)

            if (modalInstance != undefined) {
                vm.closeModal();
            }
        }
        function failure(err) {
            var detailMessage = err.data ? err.data.toString() : err.toString();
            console.log(detailMessage);
            vm.closeModal();
        }
    };

});