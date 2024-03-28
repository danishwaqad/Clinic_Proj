var RegistrationForm = angular.module("RegistrationForm", []);
RegistrationForm.controller("Home", function ($scope, $http, $window) {
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
    //==========Get Today Token All Data================
    $scope.Get_ToknAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/TokenGenrate/GetToken_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            $scope.dtToday_ToknGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Today Token Data Get By id=================
    $scope.Get_TodayTknByID = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/TokenGenrate/Get_TknTodaybyid",
            data: {
                TokenNo: ID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtTokenNo_Pat = dt[0].TokenNo;
                $scope.txtCNICNo = dt[0].CNIC;
                $scope.txtTokenDate = new Date(dt[0].TokenDate);
                $scope.DDLTitle_Pat = dt[0].Title;
                $scope.txtFPatientName_Pat = dt[0].FirstName;
                $scope.txtMPatientName_Pat = dt[0].MidName;
                $scope.txtLPatientName_Pat = dt[0].LastName;
                $scope.txtRelation_Pat = dt[0].Relation;
            }
            else {
                $scope.txtCNICNo = '';
                $scope.txtTokenDate = new Date();
                $scope.DDLTitle_Pat = 'Mr';
                $scope.txtFPatientName_Pat = '';
                $scope.txtMPatientName_Pat = '';
                $scope.txtLPatientName_Pat = '';
                $scope.txtRelation_Pat = '';
                $scope.txtTokenNo_Pat = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============Delete Today Token==================
    $scope.DeleteTodayTkn_Data = function () {
        var displayReq = {
            method: 'POST',
            url: '/TokenGenrate/OnDelete_TodayTkn',
            data: {
                TokenNo: $scope.txtTokenNo_Pat,
                TokenDel_Remarks: $scope.txtDel_Remarks
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Token Delete Successfully');
                $scope.On_ClearTodayTkn();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
                $scope.On_ClearTodayTkn();
        });
    };
    //=============Delete Today Token Get Back To Previous Position==================
    $scope.DeleteTodayTkn_GetBackData = function () {
        var displayReq = {
            method: 'POST',
            url: '/TokenGenrate/OnDeleteBack_TodayTkn',
            data: {
                TokenNo: $scope.txtTokenNo_Pat,
                TokenDel_Remarks: $scope.txtDel_Remarks
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Token Get Back Successfully');
                $scope.On_ClearTodayTkn();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_ClearTodayTkn();
        });
    };
    //===================On Load Function======================
    $scope.OnToken_Load = function () {
        $scope.txtTokenDate = new Date();
        $scope.DDLTitle_Pat = 'Mr';
    };
    $scope.On_ClearTodayTkn = function () {
        $scope.txtCNICNo = '';
        $scope.txtTokenDate = new Date();
        $scope.DDLTitle_Pat = 'Mr';
        $scope.txtFPatientName_Pat = '';
        $scope.txtMPatientName_Pat = '';
        $scope.txtLPatientName_Pat = '';
        $scope.txtRelation_Pat = '';
        $scope.txtTokenNo_Pat = '';
        $scope.txtDel_Remarks = '';
    };
    $scope.OnToken_Load();
});