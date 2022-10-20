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
$scope.GetLoginInfo = function (user, Status, Type) {
    $scope.TxtUsername = user;
    $scope.TxtStatus = Status;
    $scope.TxtUserType = Type;
    $scope.GetMenuRights();
    $scope.GetSiteRights();
};

//==================Get Login List=======================
$scope.GetMenuRights = function () {
    //alert('TEST');
    var displayReq = {
        method: "POST",
        url: "/Account/Get_Login_RightsAll",
        data: {
            Username: $scope.TxtUsername
        }
    }
    $http(displayReq).then(function (Return) {

        $scope.dtMenuRights = angular.fromJson(Return.data);


    }, function myError(Return) {
        $scope.Notification('error', Return.data);
    });
};
//==================Get Login List=======================
$scope.GetSiteRights = function () {
    //alert('TEST');
    var displayReq = {
        method: "POST",
        url: "/Account/Get_Site_RightsAll",
        data: {
            Username: $scope.TxtUsername
        }
    }
    $http(displayReq).then(function (Return) {

        $scope.dtSiteRights = angular.fromJson(Return.data);


    }, function myError(Return) {
        $scope.Notification('error', Return.data);
    });
};
//============Allow Site====================
$scope.AllowSite = function (id, val) {
    //alert(id + '    ' + val);
    var displayReq = {
        method: 'POST',
        url: '/Account/Add_Site_Rights',
        data: {
            Username: $scope.TxtUsername,
            SiteID: id,
            IsAllow: val
        }
    }
    $http(displayReq).then(function (Return) {
        if (Return.data == "Done") {
            $scope.Notification('success', 'Rights Allocated');
        }
        else {
            $scope.Notification('warning', 'Something went wrong');
        }
    }, function myError(Return) {
        $scope.On_Clear();
        $scope.Notification('error', Return.data);
    });
};
//============Allow Menu====================
$scope.AllowMenu = function (id, val) {
    //alert(id + '    ' + val);
    var displayReq = {
        method: 'POST',
        url: '/Account/Add_Menu_Allow_Rights',
        data: {
            Username: $scope.TxtUsername,
            MenuID: id,
            IsAllow: val
        }
    }
    $http(displayReq).then(function (Return) {
        if (Return.data == "Done") {
            $scope.Notification('success', 'Rights Allocated');
        }
        else {
            $scope.Notification('warning', 'Something went wrong');
        }
    }, function myError(Return) {
        $scope.On_Clear();
        $scope.Notification('error', Return.data);
    });
};
//============Allow Print Menu====================
$scope.AllowPrintMenu = function (id, val) {
    //alert(id + '    ' + val);
    var displayReq = {
        method: 'POST',
        url: '/Account/Add_Menu_Print_Rights',
        data: {
            Username: $scope.TxtUsername,
            MenuID: id,
            IsPrint: val
        }
    }
    $http(displayReq).then(function (Return) {
        if (Return.data == "Done") {
            $scope.Notification('success', 'Rights Allocated');
        }
        else {
            $scope.Notification('warning', 'Something went wrong');
        }
    }, function myError(Return) {
        $scope.On_Clear();
        $scope.Notification('error', Return.data);
    });
};
    //==========The End==========
});