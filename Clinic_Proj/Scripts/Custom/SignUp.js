var RegistrationForm = angular.module("RegistrationForm", []);
RegistrationForm.controller("Home", function ($scope, $http) {
    $scope.Notification = function (Type, Heading, Test) {
        //info, warning, success, error
        $.toast({
            heading: Heading,
            text: Test,
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: Type,
            hideAfter: 3500,
            stack: 6
        });
    };
    //===========User Already Exist===========
    $scope.SelectionCreate = function () {
        var displayReq = {
            method: "POST",
            url: "/Account/AllReadyExist",
            data: {
                Username: $scope.TxtUsername
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt[0].Username > 0) {
                $scope.Notification('error', 'Error', 'User Name Already Exist');
            }
            else {
            if ($scope.TxtUsername != '')
                $scope.Create();
            }
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //==================Delete Login ID===============
    $scope.OnDelete = function () {
        var displayReq = {
            method: "POST",
            url: "/Account/OnDelete",
            data: {
                Username: $scope.TxtUsername
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Login ID');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==================Get Login List=======================
    $scope.GetLoginList = function () {
        //alert('TEST');
        var displayReq = {
            method: "POST",
            url: "/Account/GetLoginList",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetLoginList = angular.fromJson(Return.data);


        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //GetLoginInfo
    $scope.GetLoginInfo = function (user) {
        var displayReq = {
            method: "POST",
            url: "/Account/Get_LoginByID",
            data: {
                Username: user
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.CUSavBtn = true;
                $scope.CUpdateBtn = false;
                $scope.CUDeleteBtn = false;
                $scope.CUHSaveBtn = true;
                $scope.CUHpdateBtn = false;
                $scope.TxtName = dt[0].Name;
                $scope.TxtDesignation = dt[0].Designation;
                $scope.TxtUsername = dt[0].Username;
                $scope.TxtPassword = dt[0].Pass;
                $scope.TxtEmailID = dt[0].EmailID;
                if (dt[0].InActive == false) {
                    $scope.DDL_InActive = 'false';
                }
                else {
                    $scope.DDL_InActive = 'true';
                }
                if (dt[0].IsFixIP == false) {
                    $scope.DDL_IPAccess = 'false';
                }
                else {
                    $scope.DDL_IPAccess = 'true';
                }
                //$scope.DDL_InActive = dt[0].InActive;
                $scope.DDL_UserType = dt[0].UserType;
                $scope.TxtDepartment = dt[0].Department;
                $scope.TxtSection = dt[0].Section;
                $scope.TxtContactNo = dt[0].ContactNo;
                //$scope.DDL_IPAccess = dt[0].IsFixIP;
            }
            else {
                $scope.TxtName = '';
                $scope.TxtDesignation ='';
                $scope.TxtUsername = '';
                $scope.TxtPassword = '';
                $scope.TxtEmailID = '';
                $scope.DDL_InActive = 'false';
                $scope.DDL_UserType = '0';
                $scope.TxtDepartment = '';
                $scope.TxtSection = '';
                $scope.TxtContactNo = '';
                $scope.DDL_IPAccess = 'false';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==================Get Login Type=======================
    $scope.GetLoginTypeList = function () {
        //alert('TEST');
        var displayReq = {
            method: "POST",
            url: "/Account/Active_LoginType_List",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetLoginTypeList = angular.fromJson(Return.data);


        }, function myError(Return) {
                $scope.Notification('error', Return.data);
        });
    };
    //==================Check Ex User=======================
    $scope.CheckUser = function () {
        //alert('TEST');
        var displayReq = {
            method: "POST",
            url: "/Account/Check_Ex_Username",
            data: {
                Username: $scope.TxtUsername
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.Notification('error', 'Username Already Exist..');
            }
            else {

            }

        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //=============Update Login===============
    $scope.UpdateLogin = function (Doc) {
        //alert(Doc);
        var displayReq = {
            method: "POST",
            url: "/Account/UpdateLoginNew",
            data: {
                Name: $scope.TxtName,
                Designation: $scope.TxtDesignation,
                Username: $scope.TxtUsername,
                Password: $scope.TxtPassword,
                EmailID: $scope.TxtEmailID,
                InActive: $scope.DDL_InActive,
                UserType: $scope.DDL_UserType,
                Department: $scope.TxtDepartment,
                Section: $scope.TxtSection,
                ContactNo: $scope.TxtContactNo,
                IsFixIP: $scope.DDL_IPAccess
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Updated") {
                $scope.Notification('success', 'Operation Completed', 'Update Login ID');
                $scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            });
    };
    //=============Create new Login===============
    $scope.Create = function (Doc) {
        //alert(Doc);
        var displayReq = {
            method: "POST",
            url: "/Account/CreateNew",
            data: {
                Name: $scope.TxtName,
                Designation: $scope.TxtDesignation,
                Username: $scope.TxtUsername,
                Password: $scope.TxtPassword,
                EmailID: $scope.TxtEmailID,
                InActive: $scope.DDL_InActive,
                UserType: $scope.DDL_UserType,
                Department: $scope.TxtDepartment,
                Section: $scope.TxtSection,
                ContactNo: $scope.TxtContactNo,
                IsFixIP: $scope.DDL_IPAccess
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'New Login ID Create');
                $scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    $scope.On_Clear = function()
    {
        $scope.TxtName = '';
        $scope.TxtDesignation = '';
        $scope.TxtUsername = '';
        $scope.TxtPassword = '';
        $scope.TxtEmailID = '';
        $scope.DDL_InActive = 'false';
        $scope.TxtDepartment = '';
        $scope.TxtSection = '';
        $scope.DDL_UserType = '0';
        $scope.TxtContactNo = '';
        $scope.DDL_IPAccess = 'false';
        $scope.CUSavBtn = false;
        $scope.CUpdateBtn = true;
        $scope.CUDeleteBtn = true;
        $scope.CUHSaveBtn = false;
        $scope.CUHpdateBtn = true;
    }

    //================On Load Function=============
    $scope.OnLoad = function () {
        $scope.CUSavBtn = false;
        $scope.CUpdateBtn = true;
        $scope.CUDeleteBtn = true;
        $scope.CUHSaveBtn = false;
        $scope.CUHpdateBtn = true;
        $scope.GetLoginTypeList();
        //$scope.On_Clear();
    };
    $scope.OnLoad();
    $scope.On_Clear();
    //==========The End==========

});