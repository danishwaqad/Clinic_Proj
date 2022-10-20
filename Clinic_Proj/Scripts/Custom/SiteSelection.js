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
    //==================Get Active Site List=======================
    $scope.GetSiteList = function () {
        //alert('Site Selection');
        var displayReq = {
            method: "POST",
            url: "/Site/User_Site_List_Access",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.dtGetSiteList = angular.fromJson(Return.data);
            }
            else {

            }

        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };

    //==================Get Active Site List=======================
    $scope.GetSiteInfo = function () {
        //alert('12');
        var displayReq = {
            method: "POST",
            url: "/Site/Get_Login_Site_Detail",
            data: {
                SiteID: $scope.DDLSite
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.DivisionID = dt[0].DivisionID;
                $scope.DivisionName = dt[0].DivisionName;

                $scope.TxtDivisionID = dt[0].DivisionName + ' [ ' + dt[0].DivisionID + ' ]'; s
            }
            else {
                $scope.TxtDivisionID = '';
                $scope.DivisionID = '';
                $scope.DivisionName = '';
            }


        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //=============Proceed==========
    $scope.Proceed = function () {
        //alert($scope.DivisionID + ' ----   ' + $scope.DDLSite);
        var displayReq = {
            method: 'POST',
            url: '/Account/Proceed',
            data: {
                SiteID: $scope.DDLSite,
                DivisionID: $scope.DivisionID
            }
        }
        $http(displayReq).then(function (Return) {
            //alert(Return.data);
            if (Return.data == "Done") {
                //$scope.Notification('success', 'Site Accessed');
                window.location.href = '/Home/Index';
            }
            else {
                $scope.Notification('warning', 'Error' + Return.data);
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', Return.data);
        });
    };






    //===========GET SITE INFO============
    //$scope.GetSiteInfo = function (DivID, DivName) {
    //    alert(DivID + '       ' + DivName);
    //    $scope.TxtDivisionID = DivName;
    //    $scope.DivisionID = DivID;
    //};

    $scope.OnLoad = function () {
        $scope.DDLSite = '0';

        $scope.GetSiteList();
    };

    //==========The End==========
    $scope.OnLoad();

});