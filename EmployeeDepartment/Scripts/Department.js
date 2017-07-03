// Defining angularjs module
var app = angular.module('departmentModule', []);

//app.config(['$routeProvider', '$locationProvider',
//    function ($routeProvider, $locationProvider) {
//        $routeProvider.
//            when('/', {
//                templateUrl: 'Home/Department.cshtml',
//                controller: 'departmentCtrl'
//            });

//        $locationProvider.html5Mode(true).hasPrefix('!')
//    }]);
// Defining angularjs Controller and injecting ProductsService
app.controller('departmentCtrl', function ($scope, $http, DepartmentsService) {

    $scope.departmentsData = null;
    // Fetching records from the factory created at the bottom of the script file
    DepartmentsService.GetAllRecords().then(function (d) {
        $scope.departmentsData = d.data; // Success
    }, function () {
        alert('Error Occured !!!'); // Failed
    });

   

    $scope.Department = {
        Id: '',
        Name: ''
           };

    // Reset department details
    $scope.clear = function () {
        $scope.Department.Id = '';
        $scope.Department.Name = '';
       
    }

    //Add New Item
    $scope.save = function () {
        if ($scope.Department.Name != "" ) {
            // Call Http request using $.ajax

            //$.ajax({
            //    type: 'POST',
            //    contentType: 'application/json; charset=utf-8',
            //    data: JSON.stringify($scope.Product),
            //    url: 'api/Product/PostProduct',
            //    success: function (data, status) {
            //        $scope.$apply(function () {
            //            $scope.productsData.push(data);
            //            alert("Product Added Successfully !!!");
            //            $scope.clear();
            //        });
            //    },
            //    error: function (status) { }
            //});

            // or you can call Http request using $http
            $http({
                method: 'POST',
                url: '/api/Department/PostDepartment/',
                data: $scope.Department
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.departmentsData.push(response.data);
                $scope.clear();
                alert("Department Added Successfully !!!");
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Edit department details
    $scope.edit = function (data) {
        $scope.Department = { Id: data.Id, Name: data.Name };
    }

    // Cancel department details
    $scope.cancel = function () {
        $scope.clear();
    }

    // Update department details
    $scope.update = function () {
        if ($scope.Department.Name != "") {
            $http({
                method: 'PUT',
                url: '/api/Department/' + $scope.Department.Id,
                data: $scope.Department
            }).then(function successCallback(response) {
                $scope.departmentsData = response.data;
                $scope.clear();
                alert("Department Updated Successfully !!!");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Delete department details
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: '/api/Department/' + $scope.departmentsData[index].Id
        }).then(function successCallback(response) {
            $scope.departmentsData.splice(index,1);
            alert("Department Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

// Here I have created a factory which is a popular way to create and configure services.
// You may also create the factories in another script file which is best practice.

app.factory('DepartmentsService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('/api/Department');
    }
    return fac;
});