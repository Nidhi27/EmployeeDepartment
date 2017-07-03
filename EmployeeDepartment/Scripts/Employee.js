// Defining angularjs module
var app = angular.module('EmpModule', ['departmentModule']);

// Defining angularjs Controller and injecting ProductsService
app.controller('EmpCtrl', function ($scope, $http, EmployeesService, DepartmentsService) {
   
    $scope.employeesData = null;
    // Fetching records from the factory created at the bottom of the script file
    EmployeesService.GetAllRecords().then(function (d) {
        $scope.employeesData = d.data;
        // Success
    }, function () {
        alert('Error Occured in emp!!!'); // Failed

       
    });

    DepartmentsService.GetAllRecords().then(function (d) {
        $scope.departmentsData = d.data;
     
    }, function () {
        alert('Error Occurres in dept !!!');
    });

  

    $scope.Employee = {
        Id: '',
        Name: '',
        City: '',
       DepartmentId:''
    };
    $scope.Department = {
        Name: '',
        Id: 3
    };

    // Reset department details
    $scope.clear = function () {
        $scope.Employee.Id = '';
        $scope.Employee.Name = '';
        $scope.Employee.City = '';
        
    }

    //Add New Item
    $scope.save = function () {
        if ($scope.Employee.Name != "") {
            $scope.Employee.DepartmentId = $scope.Department.Id;
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
                url: 'api/Employee/PostEmployee/',
                data: $scope.Employee
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.employeesData.push(response.data);
                $scope.clear();
                alert("Employee Added Successfully !!!");
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
        $scope.Employee = { Id: data.Id, Name: data.Name, City: data.City };
    };

    // Cancel department details
    $scope.cancel = function () {
        $scope.clear();
    };

    // Update department details
    $scope.update = function () {
        if ($scope.Employee.Name != "" && $scope.Employee.City != "") {
            $scope.Employee.DepartmentId = $scope.Department.Id;
            $http({
                method: 'PUT',
                url: 'api/Employee/' + $scope.Employee.Id,
                data: $scope.Employee
            }).then(function successCallback(response) {
                $scope.employeesData = response.data;
                $scope.clear();
                alert("Employee Updated Successfully !!!");
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
            url: 'api/Employee/' + $scope.employeesData[index].Id
        }).then(function successCallback(response) {
            $scope.employeesData.splice(index, 1);
            alert("Employee Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

// Here I have created a factory which is a popular way to create and configure services.
// You may also create the factories in another script file which is best practice.

app.factory('EmployeesService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('api/Employee/');
    }
    return fac;
});

