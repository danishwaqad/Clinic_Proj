var RegistrationForm = angular.module("RegistrationForm", []);
RegistrationForm.controller("Home", function ($scope, $http, $window, $filter) {
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
    $scope.SetMaxLen = function () {
        $scope.length6 = '';
        $scope.length6 = $scope.txtCnic.length;
        if ($scope.length6 > 10) {
            $scope.txtCnic = '';
            $scope.Notification('error', 'Warning', 'Please Check Length Not Greater Then By 10');
        }
        else {
        }
    };
    $scope.getMobileLength = function () {
        $scope.length5 = '';
        if ($scope.txtCnic == undefined) {
            $scope.txtRegNo = '';
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
        else {
            //Nothing will do
        }
        var StartingString = $scope.txtCnic.startsWith("0");
        var StartingString1 = $scope.txtCnic.startsWith("92");
        if (StartingString == false) {
            $scope.length5 = $scope.txtCnic.length;
            if ($scope.length5 == '10' && StartingString1 == false) {
            var id = '92' + $scope.txtCnic;
            $scope.TESTING(id);
         }
        else {
            $scope.txtRegNo = '';
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
        }
        else {
            $scope.txtRegNo = '';
            $scope.Notification('error', 'Error', 'Please Enter Valid Input Not Start With 0 Please Check Valid Mobile # Format/3121234567');
        }
    };
    $scope.getTelLength = function () {
        $scope.length = '';
        if ($scope.txtTelephone == undefined) {
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
        else {
            //Nothing will do
        }
        var StartingString = $scope.txtTelephone.startsWith("92");
        $scope.length = $scope.txtTelephone.length;
            if ($scope.length == '10' && StartingString == false) {
                $scope.txtTelephone = '92' + $scope.txtTelephone;
            }
            else if ($scope.length == '12' && StartingString == true) {
                $scope.txtTelephone = $scope.txtTelephone;
            }
            else {
                $scope.txtTelephone = '';
                $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
            }
    };
    $scope.getTel1Length = function () {
        $scope.length = '';
        if ($scope.txtTel1 == undefined) {
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
        else {
            //Nothing will do
        }
        var StartingString = $scope.txtTel1.startsWith("92");
        $scope.length = $scope.txtTel1.length;
        if ($scope.length == '10' && StartingString == false) {
            $scope.txtTel1 = '92' + $scope.txtTel1;
        }
        else if ($scope.length == '12' && StartingString == true) {
            $scope.txtTel1 = $scope.txtTel1;
        }
        else {
            $scope.txtTel1 = '';
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
    };
    $scope.getTel2Length = function () {
        $scope.length = '';
        if ($scope.txtTel2 == undefined) {
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
        else {
            //Nothing will do
        }
        var StartingString = $scope.txtTel2.startsWith("92");
        $scope.length = $scope.txtTel2.length;
        if ($scope.length == '10' && StartingString == false) {
            $scope.txtTel2 = '92' + $scope.txtTel2;
        }
        else if ($scope.length == '12' && StartingString == true) {
            $scope.txtTel2 = $scope.txtTel2;
        }
        else {
            $scope.txtTel2 = '';
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
    };
    $scope.getTelephoneLength = function (TelPhoneWhats) {
        $scope.length = '';
        if (TelPhoneWhats == undefined) {
            $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
        }
        else {
            //Nothing will do
        }
        var StartingString = TelPhoneWhats.startsWith("92");
        $scope.length = TelPhoneWhats.length;
        if ($scope.length == '10' && StartingString == false) {
            $scope.txtTelephoneW = '92' + TelPhoneWhats;
            }
            else if ($scope.length == '12' && StartingString == true) {
                $scope.txtTelephoneW = TelPhoneWhats;
            }
            else {
                $scope.txtTelephoneW = '';
                $scope.Notification('error', 'Error', 'Please Enter Valid Length Mobile # Format/923121234567');
            }
    };
    $scope.getCnicLength = function () {
        $scope.length = '';
        $scope.length1 = '';
        $scope.length2 = '';
        $scope.length = $scope.txtCnic.length;
        if ($scope.length == '5') {
            var CnicTest = $scope.txtCnic;
            var PutFirstSlash = CnicTest + '-';
            $scope.txtCnic = PutFirstSlash;
        }
        else {
         //Nothing First IF
        }
        $scope.length1 = $scope.txtCnic.length;
        if ($scope.length1 == '13') {
            PutSecoSlash = $scope.txtCnic;
            var CnicTest2 = PutSecoSlash + '-';
            $scope.txtCnic = CnicTest2;
        }
        else {
            //Nothing Secound IF
        }
        $scope.length2 = $scope.txtCnic.length;
        if ($scope.length2 == '15') {
            id = $scope.txtCnic;
            $scope.TESTING(id);
        }
        else {
            //Nothing Third IF
        }
        if ($scope.length2 > '15' || $scope.length2 == '0') {
            $scope.txtRegNo = '';
            $scope.Notification('error', 'Error', 'Please Enter Valid Format CNIC #/12345-1234567-1');
        }
        else {
            //Nothing Fourth IF
            //$scope.Notification('warning', 'Warning', 'Please You Enter Valid Format CNIC #/12345-1234567-1');
        }
        if ($scope.length2 < '15') {
            $scope.txtRegNo = '';
        }
        else {
            //Nothing Fifth IF
        }
    };
    $scope.CheckNewCnicSelction = function () {
        var CheckTelNo = $scope.CheckNewCnic_Mobile;
        $scope.txtCnic = '';
        $scope.txtRegNo = '';
        if (CheckTelNo == "" || CheckTelNo == undefined)
        {
            $scope.NewMobileNum = true;
            $scope.NewCnic = false;
            $scope.OldCnic = true;
            $scope.OldHideCnic = true;
        }
        else if (CheckTelNo == "NewMobile") {
            $scope.NewMobileNum = false;
            $scope.NewCnic = true;
            $scope.OldHideCnic = true;
        }
        else if (CheckTelNo == "Old") {
            $scope.NewMobileNum = true;
            $scope.NewCnic = true;
            $scope.OldHideCnic = false;
            $scope.OldCnic = false;
        }
        else if (CheckTelNo == "NewCnic") {
            $scope.NewMobileNum = true;
            $scope.NewCnic = false;
            $scope.OldHideCnic = true;
        }
        else {
            //Nothing
        }
    };
    //==================Get Date Of Birth Calculate=======================
    $scope.GetMonthCalc = function () {
        var YY = $filter('date')(new Date(), 'yyyy');
        if ($scope.txtMonth == "" || $scope.txtMonth == "0" || $scope.txtDay == "" || $scope.txtDay == "0") {
            var Month = $filter('date')(new Date(), 'MM');
            var Days = $filter('date')(new Date(), 'dd');
            var CalcYear = YY - $scope.txtYear;
            var Fulldate = Month + '/' + Days + '/' + CalcYear;
            $scope.txtDOB = new Date(Fulldate);
        }
        else {
            var CalcYear = YY - $scope.txtYear;
            $scope.txtDOB = new Date($scope.txtMonth + '/' + $scope.txtDay + '/' + CalcYear);
        }
    };
    //==================Get CNIC ISSUE=======================
    $scope.GetCNICIsue = function () {
        var GivenDate = $scope.txtCnicIssue;
        var CurrentDate = new Date();
        GivenDate = new Date(GivenDate);
        if (GivenDate > CurrentDate) {
            alert('CNIC Issue Not Be Greater Then Today...');
        }
        else if (GivenDate.setHours(0, 0, 0, 0) == CurrentDate.setHours(0, 0, 0, 0)) {
            alert('Current Date Not Be Issue Date...');
        }
        else if (GivenDate < CurrentDate) {
            $scope.txtCnicIssue = GivenDate;
        }
    };
    //==================Get CNIC Expiry=======================
    $scope.GetCNICExpiry = function () {
        var GivenExpDate = $scope.txtCnicExp;
        var GivenIsueDate = $scope.txtCnicIssue;
        var CurrentExpDate = new Date();
        GivenExpDate = new Date(GivenExpDate);
        GivenIsueDate = new Date(GivenIsueDate);
        if (GivenExpDate > CurrentExpDate) {
            $scope.txtCnicExp = GivenExpDate;
        }
        else if (GivenExpDate.setHours(0, 0, 0, 0) == CurrentExpDate.setHours(0, 0, 0, 0)) {
            alert('Current Date Not Be Expiry Date...');
        }
        else if (GivenExpDate.setHours(0, 0, 0, 0) == GivenIsueDate.setHours(0, 0, 0, 0)) {
            alert('CNIC Issue and Expiry Not Equal To Same Date...');
        }
        else if (GivenExpDate < GivenIsueDate) {
            alert('CNIC Expiry Not Be Less Then Issue Date...');
        }
        else if (GivenExpDate < CurrentExpDate) {
            alert('CNIC Expiry Not Be Less Then Today...');
        }
    };
    //===========If Patient Cannot Provide CNIC=================
    $scope.GetPatCNICByID = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/get_Pat_CNIC",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtCnic = dt[0].CNIC;
                $scope.txtRegNo = dt[0].CNIC;
            }
            else {
                $scope.txtCnic = '';
            }
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //==============Proceed New Patient Data With One Click Button==================
    //=================New Token==============
    $scope.NewToken = function (CNIC, Relation) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_NewTknbyid",
            data: {
                CNIC: CNIC,
                Relation: Relation
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                //var NodeID = window.intlTelInput;
                //alert("" + NodeID);
                $scope.CUSaveBtn = true;
                $scope.txtTokenNo = dt[0].TokenNo;
                //$scope.fordisable();
            }
            else {
                $scope.txtTokenNo = '';
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=================Info Transfer to Self Button==============
    $scope.InfoTransfer = function (CNIC) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_InfoTrasfrid",
            data: {
                CNIC: CNIC
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtFathname = dt[0].GuardianName
                $scope.txtAddress = dt[0].Address;
                $scope.txtCity = dt[0].City;
                $scope.txtCountry = dt[0].Country;
                $scope.txtEmailID = dt[0].EmailID;
                $scope.txtTel1 = dt[0].Telephone;
            }
            else {
                $scope.txtAddress = '';
                $scope.txtCity = '';
                $scope.txtCountry = '';
                $scope.txtEmailID = '';
                $scope.txtTel1 = '';
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=================Get Patient Type By lookup====================
    $scope.GetPatType = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_PatdataType",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.txtBank = '0';
            $scope.txtPayMethod = 'Cash';
            $scope.txtDoctName = '0';
            $scope.txtDoctID = '';
            $scope.txtCharges = 0;
            $scope.txtDiscount = 0;
            $scope.txtPaidFee = 0;
            $scope.txtBalance = 0;
            $scope.txtDisAprov = '';
            $scope.DDLDisType = '0';
            $scope.dtGetTypeAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============Get Doctor Name======================
    $scope.GetDoctorname = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_DoctorName",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.dtGetDocName = angular.fromJson(Return.data);
            $scope.txtDiscount = 0;
            $scope.txtBalance = 0;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===================Get Dr Name By ID==================
    $scope.GetDoctorByid = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_databyid",
            data: {
                DrID: $scope.txtDoctName
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                if (dt[0].DiscountApproval != 'Free Camp') {
                    $scope.CUSaveBtn = false;
                    $scope.txtCharges = dt[0].Charges;
                    $scope.txtPaidFee = dt[0].Charges;
                    $scope.txtDoctName = dt[0].DrID;
                    $scope.txtDoctID = dt[0].DrID;
                    $scope.txtBank = '0';
                    $scope.DDLDisType = '0';
                    $scope.txtPayMethod = 'Cash';
                    $scope.txtDiscount = 0;
                    $scope.txtDisAprov = '';
                }
                else if (dt[0].DiscountApproval == 'Free Camp') {
                    $scope.CUSaveBtn = false;
                    $scope.txtDoctName = dt[0].DrID;
                    $scope.txtDoctID = dt[0].DrID;
                    $scope.txtCharges = dt[0].Charges;
                    $scope.DDLDisType = dt[0].DiscountType;
                    $scope.txtDiscount = dt[0].Discount;
                    $scope.txtDisAprov = dt[0].DiscountApproval;
                    $scope.txtPaidFee = 0;
                }
                else {
                }
            }
            else {
                $scope.txtCharges = 0;
                $scope.txtDoctName = '0';
                $scope.txtDoctID = '';
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===================Get Dr Name==================
    $scope.GetDoctorNames = function (drid) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_dataNames",
            data: {
                DrID: drid
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtDoctName = dt[0].DrName;
            }
            else {
                $scope.txtDoctName = '0';
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Calculate Doctor Fee=============
    //$scope.CalculateFee = function () {
    //    var Fee = $scope.txtCharges;
    //    var Paid = $scope.txtPaidFee;
    //    var Dis = $scope.txtDiscount;
    //    $scope.txtBalance = Fee - Paid;
    //    //(Fee - Dis) -
    //};
    ////==============Calculate Patient Discount=============
    //$scope.CalculateDiscount = function () {
    //    var DisType = $scope.DDLDisType;
    //    var Dis = $scope.txtDiscount;
    //    var Fee = $scope.txtCharges;
    //    var Paid = $scope.txtPaidFee;
    //    var P = 0;
    //    var Final = 0;
    //    if (DisType == '%') {
    //        var Final = (Fee - (Fee / 100) * Dis) - Paid;
    //        $scope.txtBalance = Final;
    //    }
    //    else if (DisType == 'Rs') {
    //        var Final = Fee - Dis - Paid;
    //        $scope.txtBalance = Final;
    //    }
    //    else if (DisType == '0') {
    //        $scope.txtDiscount = 0;
    //        var Final = Fee - Paid;
    //        $scope.txtBalance = Final;
    //    }
    //};
    //==============Calculate Doctor Fee=============
    $scope.CalculateFee = function (Final) {
        var Fee = $scope.txtCharges;
        var Paid = $scope.txtPaidFee;
        var Dis = Final;
        //$scope.txtBalance = 1*-(Dis);
        $scope.txtPaidFee = Paid + Dis;
        $scope.txtCharges = Fee;
    };
    //==============Calculate Patient Discount=============
    $scope.CalculateDiscount = function () {
        var DisType = $scope.DDLDisType;
        var Dis = $scope.txtDiscount;
        var Fee = $scope.txtCharges;
        var Paid = $scope.txtPaidFee;
        var P = 0;
        var Final = 0;
        if (DisType == '%') {
            var Final = (Fee - (Fee / 100) * Dis) - Paid;
            //$scope.txtBalance = Final;
            $scope.CalculateFee(Final);
        }
        else if (DisType == 'Rs') {
            var Final = Fee - Dis - Paid;
            //$scope.txtBalance = Final;
            $scope.CalculateFee(Final);
        }
        else if (DisType == '0') {
            $scope.txtDiscount = 0;
            var Final = Fee - Paid;
            //$scope.txtBalance = Final;
            $scope.CalculateFee(Final);
        }
    };
    //=============On Clear For Contact=============
    $scope.On_ClearForPopup = function () {
        $scope.txtDoctName = '0';
        $scope.txtDoctID = '';
        $scope.txtPatType = 'Consultancy';
        $scope.txtCharges = 0;
        $scope.txtPaidFee = 0;
        $scope.DDLDisType = '0';
        $scope.txtDisAprov = '';
        $scope.txtBalance = 0;
        $scope.txtDiscount = 0;
        $scope.txtFathname = '';
        $scope.txtTel1 = '';
        $scope.txtTel2 = '';
        $scope.txtEmailID = '';
        $scope.txtAddress = '';
        $scope.txtCity = '';
        $scope.txtCountry = '';
        $scope.txtRemarks = '';
    }
    //===============Patient Insert======================
    $scope.savedata = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/AddPSelf_record',
            data: {
                RegNo: $scope.txtRegNo,
                TokenNo: $scope.txtTokenNo,
                PatType: $scope.txtPatType,
                Title: $scope.DDLTitle,
                FirstName: $scope.txtFPatientName,
                MidName: $scope.txtMPatientName,
                LastName: $scope.txtLPatientName,
                Guardian: $scope.txtFathname,
                CNIC: $scope.txtCnic,
                Tel1: $scope.txtTel1,
                Tel2: $scope.txtTel2,
                EmailID: $scope.txtEmailID,
                Address: $scope.txtAddress,
                City: $scope.txtCity,
                Country: $scope.txtCountry,
                gender: $scope.txtGender,
                DOB: $scope.txtDOB,
                ReferBy: $scope.txtReferBy,
                Remarks: $scope.txtRemarks,
                Relation: 'Self'
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Patient Self Data');
                if ($scope.txtPatType == "Consultancy" || $scope.txtPatType == "Session") {
                    $scope.saveFeedata();
                }
                else {
                    $scope.SaveCompData();
                    window.location.href = '/Registeration/RegNew';
                }
                $scope.On_ClearForPopup();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_ClearForPopup();
        });
    };
    //===============Fee Data Insert=========================
    $scope.saveFeedata = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Add_Feerecord',
            data: {
                RegNo: $scope.txtRegNo,
                TokenNo: $scope.txtTokenNo,
                Title: $scope.DDLTitle,
                FirstName: $scope.txtFPatientName,
                MidName: $scope.txtMPatientName,
                LastName: $scope.txtLPatientName,
                CNIC: $scope.txtCnic,
                DrID: $scope.txtDoctID,
                TotalFee: $scope.txtCharges,
                Discount: $scope.txtDiscount,
                PaidFee: $scope.txtPaidFee,
                Balance: $scope.txtBalance,
                DisAprov: $scope.txtDisAprov,
                DiscountType: $scope.DDLDisType,
                PaymentMeth: $scope.txtPayMethod,
                Bank: $scope.txtBank
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Fee');
                $scope.SaveCompData();
                window.location.href = '/Registeration/RegNew';
                $scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //==================Print Report=======================
    $scope.PrintRpt = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Print_Rpt",
            data: {
                TokenNo: $scope.txtTokenNo
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Inserted") {
                $scope.Clear();
            }
            else {
                $scope.Notification('warning', 'Something went wrong');
            }
        }, function myError(Return) {
            $scope.Clear();
            $scope.Notification('error', Return.data);
        });
    };
    //==============================END============================================
    //===========Display Address Type Data by Dropdown=============
    $scope.GetAddressType = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_AddressTyp",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.dtGetAddressType = angular.fromJson(Return.data);
            }
            else {

            }

        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //=============Get Bank Name======================
    $scope.GetBank = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_BankName",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtBankName = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===================Get Bank Name By ID==================
    $scope.GetBankName = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_Bankbyid",
            data: {
                Bankid: $scope.txtBank
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtBank = dt[0].BankName;
            }
            else {
                $scope.txtBank = '0';
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============Get Payment Method======================
    $scope.GetPayMeth = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_PayMethod",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtPayMeth = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===================Get Payment Method By ID==================
    $scope.GetPayByid = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_Paybyid",
            data: {
                Payid: $scope.txtPayMethod
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtPayMethod = dt[0].MethodName;
            }
            else {
                $scope.txtPayMethod = '';
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==================Address Data Delete=============
    $scope.DeleteAddress = function (id) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Delete_Address",
            data: {
                ID: id
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Delete") {
                $scope.On_ClearA();
                $scope.Notification('success', 'Operation Completed', 'Delete Address');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==================Contact Data Delete=============
    $scope.DeleteContact = function (id) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Delete_Contact",
            data: {
                ID: id
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Delete") {
                $scope.On_ClearC();
                $scope.Notification('success', 'Operation Completed', 'Delete Contact');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==========Display All Patient Related lookup Data================
    $scope.GetAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Patient data Get By id=================
    $scope.GetDataByID = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_databyid",
            data: {
                id: ID
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.txtRegistrationNo = dt[0].RegNo;
                $scope.txtTokenNo = dt[0].TokenNo;
                $scope.txtPatType = dt[0].PatType;
                $scope.DDLTitle = dt[0].Title;
                $scope.txtFPatientName = dt[0].FirstName;
                $scope.txtMPatientName = dt[0].MidName;
                $scope.txtLPatientName = dt[0].LastName;
                $scope.txtCNIC = dt[0].CNIC;
                $scope.txtGuardianName = dt[0].GuardianName;
                $scope.txtTel1 = dt[0].Tel1;
                $scope.txtTel2 = dt[0].Tel2;
                $scope.txtGender = dt[0].Gender;
                $scope.txtEmailID = dt[0].EmailID;
                $scope.txtAddress = dt[0].Address;
                $scope.txtCity = dt[0].City;
                $scope.txtCountry = dt[0].Country;
                $scope.txtDOB = new Date(dt[0].DOB);
                $scope.txtReferBy = dt[0].ReferBy;
                $scope.txtRemarks = dt[0].Remarks;
                $scope.txtRelation = dt[0].Relation;
                $scope.txtDivisionCode = dt[0].DivisionID;
                $scope.txtSiteCode = dt[0].SiteID;
                $scope.txtLoginID = dt[0].LoginID;
                $scope.txtDoctName = dt[0].DrName;
                $scope.txtCharges = dt[0].TotalFee;
                $scope.txtDiscount = dt[0].Discount;
                $scope.txtDisAprov = dt[0].DiscountApproval;
                $scope.txtPaidFee = dt[0].PaidFee;
                $scope.txtBalance = dt[0].Balance;
                $scope.DDLDisType = dt[0].DiscountType;

                $scope.CUSaveBtn = true;
                $scope.txtCNIC_Disable = true;
                $scope.CUUpdateBtn = false;
            }
            else {
                $scope.CUSaveBtn = false;
                $scope.CUUpdateBtn = true;

                $scope.txtRegistrationNo = '';
                $scope.txtTokenNo = '';
                $scope.txtPatType = 'Consultancy';
                $scope.DDLTitle = '';
                $scope.CheckNewCnic_Mobile = 'NewCnic';
                $scope.CheckNewCnic_Mobile = 'NewCnic';
                $scope.txtFPatientName = '';
                $scope.txtMPatientName = '';
                $scope.txtLPatientName = '';
                $scope.txtYear = '';
                $scope.txtMonth = '';
                $scope.txtDay = '';
                $scope.txtCNIC = '';
                $scope.txtGuardianName = '';
                $scope.txtTel1 = '';
                $scope.txtTel2 = '';
                $scope.txtGender = '';
                $scope.txtEmailID = '';
                $scope.txtAddress = '';
                $scope.txtCity = '';
                $scope.txtCountry = '';
                $scope.txtDOB = '';
                $scope.txtReferBy = '';
                $scope.txtRemarks = '';
                $scope.txtRelation = '';
                $scope.txtDivisionCode = '';
                $scope.txtSiteCode = '';
                $scope.txtLoginID = '';
                $scope.txtDoctName = '0';
                $scope.txtDoctID = '';
                //$scope.txtPatType = 'Consultancy';
                $scope.txtCharges = 0;
                $scope.txtDiscount = 0;
                $scope.txtPaidFee = 0;
                $scope.txtBalance = 0;
                $scope.txtDisAprov = '';
                $scope.DDLDisType = '0';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===========Display Contact Type Data by Dropdown=============
    $scope.GetContactType = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_ContactTyp",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.dtGetContactType = angular.fromJson(Return.data);
            }
            else {
                alert("Nothing in this else field");
            }
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //===============Register CNIC Transfer to New Patient Form======================
    $scope.REG_CNIC_PanalData = function (CnicReg) {
        $scope.CnicDataInsert(CnicReg);
        var displayReq = {
            method: 'POST',
            url: '/Registeration/RegisterPanal_CNIC',
            data: {
                CNIC: CnicReg
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.OpenCNICRegForm();
                $scope.Notification('success', 'Operation Completed', 'CNIC Transfer');
                $scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //===============Register CNIC Transfer to New Patient Form======================
    $scope.REG_CNIC = function (CnicReg) {
        $scope.CnicDataInsert(CnicReg);
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Register_CNIC',
            data: {
                CNIC: CnicReg
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.OpenCNICRegForm();
                $scope.Notification('success', 'Operation Completed', 'CNIC Transfer');
                $scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //===============Patient Insert======================
    $scope.TrasferCNData = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/TrsfrCNData",
            data: {
                CNIC: $scope.txtCnic
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Done") {
                $scope.Notification('success', 'Move To New Patient Form');
                $window.location.href = '/PatientReg/PatientReg';
                //$window.open("/PatientReg/PatientReg?DateFrom=" + SessionTkn);
            }
            else {
                $scope.Notification('warning', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', Return.data);
        });
    };
    //===============Patient Insert======================
    $scope.SaveCompData = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Add_record',
            data: {
                RegNo: $scope.txtRegNo,
                RegDate: new Date($scope.txtRegDate),
                CNIC: $scope.txtCnic,
                DOB: $scope.txtDOB,
                Title: $scope.DDLTitle,
                FirstName: $scope.txtFPatientName,
                MidName: $scope.txtMPatientName,
                LastName: $scope.txtLPatientName,
                Guardian: $scope.txtFname,
                CNICIssue: $scope.txtCnicIssue,
                CNICExp: $scope.txtCnicExp,
                FamilyNo: $scope.txtFamilyNo,
                CNICIdentity: $scope.txtCnicIdentity,
                ReferBy: $scope.txtReferBy,
                gender: $scope.txtGender,
                Remarks: $scope.txtORemarks
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Patient CNIC');
                //$scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            //$scope.On_Clear();
        });
    };
    //===============Patient Update======================
    $scope.UpdateCompData = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/UpdateComData',
            data: {
                RegNo: $scope.txtRegNo,
                RegDate: new Date($scope.txtRegDate),
                CNIC: $scope.txtCnic,
                DOB: $scope.txtDOB,
                Title: $scope.DDLTitle,
                FirstName: $scope.txtFPatientName,
                MidName: $scope.txtMPatientName,
                LastName: $scope.txtLPatientName,
                Guardian: $scope.txtFname,
                CNICIssue: $scope.txtCnicIssue,
                CNICExp: $scope.txtCnicExp,
                FamilyNo: $scope.txtFamilyNo,
                CNICIdentity: $scope.txtCnicIdentity,
                ReferBy: $scope.txtReferBy,
                gender: $scope.txtGender,
                Remarks: $scope.txtORemarks
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Updated") {
                $scope.Notification('success', 'Operation Completed', 'Update Patient');
                //$scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            //$scope.On_Clear();
        });
    };
    //===============Patient Address Insert======================
    $scope.savedataA = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Add_Address',
            data: {
                RegNo: $scope.txtRegNo,
                RegDate: new Date($scope.txtRegDate),
                CNIC: $scope.txtCnic,
                AddressTyp: $scope.txtType,
                HouseNo: $scope.txtHouseNo,
                Town: $scope.txtTown,
                StreetNo: $scope.txtStreetNo,
                City: $scope.txtCity,
                State: $scope.txtState,
                Country: $scope.txtCountry,
                Zip: $scope.txtZip,
                Address: $scope.txtAddress,
                RemarksA: $scope.txtARemarks,
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Address');
                $scope.GetAllAVData($scope.txtRegNo);
                $scope.On_ClearA();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //===============Patient Contact Insert======================
    $scope.savedataC = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Add_Contact',
            data: {
                RegNo: $scope.txtRegNo,
                RegDate: new Date($scope.txtRegDate),
                CNIC: $scope.txtCnic,
                ContactType: $scope.txtContactType,
                TeleNo: $scope.txtTelephone,
                Email: $scope.txtEmail,
                RemarksC: $scope.txtCRemarks,
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Contact');
                $scope.GetAllCVData($scope.txtRegNo);
                $scope.On_ClearC();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //===========Proceed Modal Hide=========
    $scope.CheckWhtsProceedModal = function (RegNo, RegDate) {
        $scope.txtWRegNo = RegNo;
        $scope.txtWRegDate = new Date(RegDate);
        $scope.ShowCNICReg = false;
        $scope.ShowPatient = false;
        $scope.ShowWhatsCnt = true;
    };
    //===============Patient Whats Contact Insert======================
    $scope.savedataContact = function (ContactType, Telephone, Email, CRemarks) {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Add_WContact',
            data: {
                RegNo: $scope.txtRegNo,
                RegDate: new Date($scope.txtRegDate),
                CNIC: $scope.txtCnic,
                ContactType: ContactType,
                TeleNo: Telephone,
                Email: Email,
                RemarksC: CRemarks
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Contact');
                $scope.CloseWhatsAppModel();
                //$scope.ShowPatient = false;
                $scope.WhatsAppBtn = true;
                $scope.ShowCNICReg = true;
                //$scope.On_ClearC();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //==============Close Popup if Patient are not Avilable=================
    $scope.CloseWhatsAppModel = function () {
        $scope.ShowWhatsCnt = false;
    };
    //===============Patient CNIC Insert======================
    $scope.savedataCN = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Add_CNICDet',
            data: {
                CNIC: $scope.txtCnic,
                CNICIssue: new Date($scope.txtCnicIssue),
                CNICExp: new Date($scope.txtCnicExp),
                FamilyNo: $scope.txtFamilyNo,
                CNICIdentity: $scope.txtCnicIdentity,
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert CNIC Detail');
                $scope.GetAllCNData($scope.txtRegNo);
                $scope.On_ClearCN();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //==================Gender Selection===================
    $scope.GenderSelction = function () {
        if ($scope.DDLTitle == "Mr" || $scope.DDLTitle == "Master") {
            $scope.txtGender = "Male";
        }
        else if ($scope.DDLTitle == "Mrs" || $scope.DDLTitle == "MS" || $scope.DDLTitle == "Baby") {
            $scope.txtGender = "Female";
        }
    }
    $scope.TokenPrint = function () {
        $window.open("/Registeration/Token_Print?TokenNo=" + $scope.txtTokenNo, "_blank");
    };
    //=================CNIC No Transfer to Registration No====================
    $scope.TESTING = function (id) {
        $scope.txtRegNo = id;
        $scope.txtCnic = id;
    };
    //==============Close Popup if Patient are not Avilable=================
    $scope.CloseCNICRegModal = function () {
        $scope.ShowCNICReg = false;
    };
    //==============Close Popup of if patient are not Available for Proceed=================
    $scope.OpenCNICRegForm = function () {
        $scope.ShowCNICReg = false;
        window.location.href = '/PatientReg/PatientReg';
    };
    //===========Get Patient Data By CNIC IF Already Available
    $scope.GetPatAvail = function (id) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_PatAvailable",
            data: {
                CNIC: id
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.dtGetPatAvail = angular.fromJson(Return.data);
            if ($scope.dtGetPatAvail.length > 0) {
                if ($scope.dtGetPatAvail[0].ContactType == "Whats App") {
                    $scope.ShowCNICReg = true;
                    $scope.WhatsAppBtn = true;
                }
                else {
                    $scope.WhatsAppLabel = 'Please Enter Whats App Number!';
                    $scope.WhatsAppBtn = false;
                    $scope.ShowCNICReg = true;
                    $scope.txtRegDate = new Date($scope.dtGetPatAvail[0].RegDate);
                }
            }
            else {
                $scope.ShowCNICReg = false;
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //======================================Panal Working=============================
    //===============Register Panal CNIC Transfer to New Patient Form======================
    //$scope.Register_Panal_CNIC = function () {
    //    var displayReq = {
    //        method: 'POST',
    //        url: '/Registeration/Register_Panal_CNIC',
    //        data: {
    //            CNIC1: $scope.txtCnic
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {

    //        if (Return.data == "Inserted") {
    //            $scope.Notification('success', 'Operation Completed', 'Panal CNIC Transfer');
    //            $scope.On_Clear();
    //        }
    //        else {
    //            $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
    //        }
    //    }, function myError(Return) {
    //        $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
    //        $scope.On_Clear();
    //    });
    //};
    //===========Get Panal Patient Data By CNIC IF Already Available=========
    $scope.GetPanalPatAvail = function (id) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_PanlPatAvailable",
            data: {
                CNIC: id
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.dtPanlGetPatAvail = angular.fromJson(Return.data);
            if ($scope.dtPanlGetPatAvail.length > 0) {
                $scope.ShowPatient = true;
            }
            else {
                $scope.ShowPatient = false;
                $scope.GetPatAvail(id);
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===========Get Whats App No=========
    //$scope.GetWhatsappAvail = function (id) {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/Registeration/Get_WhatsAppAvailable",
    //        data: {
    //            CNIC: id
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        var dt = angular.fromJson(Return.data);
    //        if (dt[0].ContactType == "Whats App") {
    //            $scope.GetPatAvail(id);
    //            $scope.ShowCNICReg = false;
    //            $scope.WhatsAppBtn = true;
    //        }
    //        else {
    //            $scope.ShowCNICReg = false;
    //            $scope.GetPatAvail(id);
    //            $scope.WhatsAppLabel = 'Please Enter Whats App Number!';
    //            $scope.WhatsAppBtn = false;
    //        }
    //    }, function myError(Return) {
    //        $scope.Notification('error', 'Error Code LC0001', Return.data);
    //    });
    //};
    //==============Close Panal Popup if Patient are not Avilable=================
    $scope.ClosePanalPatientModal = function () {
        $scope.ShowPatient = false;
    };
    //==============Close Popup of if patient are not Available for Proceed=================
    $scope.OpenPanalCNICRegForm = function () {
        $scope.ShowPatient = false;
        window.location.href = '/PatientReg/PatientReg';
    };
    //==================Title Selection===================
    $scope.TitleSelction = function () {
        if ($scope.DDLTitle == "Mr" || $scope.DDLTitle == "Master") {
            $scope.txtGender = "Male";
        }
        else if ($scope.DDLTitle == "Mrs" || $scope.DDLTitle == "MS" || $scope.DDLTitle == "Baby") {
            $scope.txtGender = "Female";
        }
    }
    //=============Patient Detail if Patient is already Register Get By ID AND Token============
    $scope.CnicDataInsert = function (ID) {
        //alert('ID is : ' + ID + ' Token is : ' + Token);
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_PanlPatAvailable",
            data: {
                CNIC: ID
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtRegNo = dt[0].CNIC;
                $scope.txtCnic = dt[0].CNIC;
                $scope.txtRegDate = new Date();
                $scope.txtDOB = new Date(dt[0].DOB);
                $scope.DDLTitle = dt[0].Title;
                $scope.txtFPatientName = dt[0].FirstName;
                $scope.txtMPatientName = dt[0].MidName;
                $scope.txtLPatientName = dt[0].LastName;
                $scope.txtFname = dt[0].GuardianName;
                $scope.txtCnicIssue = dt[0].CNICIssueDate;
                $scope.txtCnicExp = dt[0].CNICExpiryDate;
                $scope.txtFamilyNo = dt[0].FamilyNumber;
                $scope.txtCnicIdentity = dt[0].CNICIdentity;
                $scope.txtGender = dt[0].Gender;
                $scope.txtORemarks = dt[0].Remarks;
                $scope.SavePanalCompData();
            }
            else {
                $scope.txtRegNo = '';
                $scope.txtRegDate = new Date();
                $scope.txtDOB = new Date('01/01/1900');
                $scope.DDLTitle = 'Mr';
                $scope.CheckNewCnic_Mobile = 'NewCnic';
                $scope.txtFPatientName = '';
                $scope.txtMPatientName = '';
                $scope.txtLPatientName = '';
                $scope.txtYear = '';
                $scope.txtMonth = '';
                $scope.txtDay = '';
                $scope.txtCnic = '';
                $scope.txtCnicIssue = new Date('01/01/1900');
                $scope.txtCnicExp = new Date('01/01/1900');
                $scope.txtGender = '';
                $scope.txtReferBy = '';
                $scope.txtORemarks = '';
                $scope.txtCnicIdentity = '';
                $scope.txtFamilyNo = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===============Panal Patient Insert======================
    $scope.SavePanalCompData = function () {
        var displayReq = {
            method: 'POST',
            url: '/Registeration/Add_Panalrecord',
            data: {
                RegNo: $scope.txtRegNo,
                RegDate: new Date($scope.txtRegDate),
                CNIC: $scope.txtCnic,
                DOB: $scope.txtDOB,
                Title: $scope.DDLTitle,
                FirstName: $scope.txtFPatientName,
                MidName: $scope.txtMPatientName,
                LastName: $scope.txtLPatientName,
                Guardian: $scope.txtFname,
                CNICIssue: $scope.txtCnicIssue,
                CNICExp: $scope.txtCnicExp,
                FamilyNo: $scope.txtFamilyNo,
                CNICIdentity: $scope.txtCnicIdentity,
                ReferBy: $scope.txtReferBy,
                gender: $scope.txtGender,
                Remarks: $scope.txtORemarks
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Patient CNIC');
                //$scope.On_Clear();
                $scope.OpenPanalCNICRegForm();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            //$scope.On_Clear();
        });
    };
    //=====================================Panal END=============================================
    //==========View Address Data================
    $scope.GetAllAVData = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/GetAView_data",
            data: {
                RegNo: $scope.txtCnic
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtAViewData = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==========View Contact Data================
    $scope.GetAllCVData = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/GetCView_data",
            data: {
                RegNo: $scope.txtCnic
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtCViewData = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==========View CNIC Data================
    $scope.GetAllCNData = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/GetCNView_data",
            data: {
                RegNo: $scope.txtCnic
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtCNICViewData = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==========Get All Data================
    $scope.GetCNAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Registeration/GetCNAll_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            $scope.dtCNGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Patient data Get By id=================
    $scope.GetCNDataByID = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_CNdatabyid",
            data: {
                RegNo: ID
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.txtRegNo = dt[0].RegNo;
                $scope.txtRegDate = new Date(dt[0].RegDate);
                $scope.txtDOB = new Date(dt[0].DOB);
                $scope.DDLTitle = dt[0].Title;
                $scope.txtFPatientName = dt[0].FirstName;
                $scope.txtMPatientName = dt[0].MidName;
                $scope.txtLPatientName = dt[0].LastName;
                $scope.txtFname = dt[0].GuardianName;
                $scope.txtCnic = dt[0].CNIC;
                $scope.txtCnicIssue = new Date(dt[0].CNICIssueDate);
                $scope.txtCnicExp = new Date(dt[0].CNICExpiryDate);
                $scope.txtGender = dt[0].Gender;
                $scope.txtReferBy = dt[0].ReferBy;
                $scope.txtORemarks = dt[0].Remarks;
                $scope.txtCnicIdentity = dt[0].CNICIdentity;
                $scope.txtFamilyNo = dt[0].FamilyNumber;
            }
            else {
                $scope.txtRegNo = '';
                $scope.txtRegDate = new Date();
                $scope.txtDOB = new Date('01/01/1900');
                $scope.DDLTitle = 'Mr';
                $scope.CheckNewCnic_Mobile = 'NewCnic';
                $scope.txtFPatientName = '';
                $scope.txtMPatientName = '';
                $scope.txtLPatientName = '';
                $scope.txtYear = '';
                $scope.txtMonth = '';
                $scope.txtDay = '';
                $scope.txtCnic = '';
                $scope.txtCnicIssue = new Date('01/01/1900');
                $scope.txtCnicExp = new Date('01/01/1900');
                $scope.txtGender = '';
                $scope.txtReferBy = '';
                $scope.txtORemarks = '';
                $scope.txtCnicIdentity = '';
                $scope.txtFamilyNo = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    $scope.TypeWiseSelection = function () {
        if ($scope.txtPatType == "Consultancy") {
            if ($scope.txtDoctName == '') {
                $scope.CUSaveBtn = true;
            }
            $scope.txtDoctName = '0';
            $scope.txtDoctID = '';
            $scope.txtCharges = 0;
            $scope.txtPaidFee = 0;
            $scope.DDLDisType = '0';
            $scope.txtDisAprov = '';
            $scope.txtBalance = 0;
            $scope.txtDiscount = 0;
            $scope.txtBank = '0';
            $scope.txtPayMethod = '0';
            $scope.CUSaveBtn = true;
            $scope.DocBankBtnDisable = false;
            $scope.DocBankInpDisable = false;
            $scope.DocPayBtnDisable = false;
            $scope.DocPayInpDisable = false;
            $scope.DocBalDisable = false;
            $scope.DocPaidDisable = false;
            $scope.DocApprDisable = false;
            $scope.DocDiscDisable = false;
            $scope.DocFeeDisable = false;
            $scope.DocNamSelDisable = false;
            $scope.DocIDDisable = false;
            $scope.DocNamDisable = false;
        }
        else if ($scope.txtPatType == "First Aid") {
            $scope.CUSaveBtn = false;
            $scope.DocBankBtnDisable = true;
            $scope.DocBankInpDisable = true;
            $scope.DocPayBtnDisable = true;
            $scope.DocPayInpDisable = true;
            $scope.DocBalDisable = true;
            $scope.DocPaidDisable = true;
            $scope.DocApprDisable = true;
            $scope.DocDiscDisable = true;
            $scope.DocFeeDisable = true;
            $scope.DocNamSelDisable = true;
            $scope.DocIDDisable = true;
            $scope.DocNamDisable = true;
        }
    }
    //==================Type Wise Insert Selection===================
    $scope.TypeWiseInsert = function () {
        if ($scope.txtPatType == "Consultancy" || $scope.txtPatType == "Session") {
            $scope.savedata();
            //$scope.SaveCompData();
            $scope.TokenPrint();
        }
        else if ($scope.txtPatType == "First Aid") {
            $scope.savedata();
            //$scope.SaveCompData();
        }
    }
    //==============View Address data Get By id=================
    //$scope.GetADataByID = function (ID) {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/Registeration/Get_Adatabyid",
    //        data: {
    //            id: ID
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {

    //        var dt = angular.fromJson(Return.data);

    //        if (dt.length > 0) {
    //            $scope.txtRegistrationNo = dt[0].RegNo;
    //            $scope.txtTokenNo = dt[0].TokenNo;
    //            $scope.txtPatType = dt[0].PatType;
    //        }
    //        else {
    //            $scope.CUSaveBtn = false;
    //            $scope.CUUpdateBtn = true;

    //            $scope.txtRegistrationNo = '';
    //            $scope.txtTokenNo = '';
    //            $scope.txtPatType = '';
    //            $scope.DDLTitle = '';

    //        }

    //    }, function myError(Return) {
    //        $scope.Notification('error', 'Error Code LC0001', Return.data);
    //    });
    //};
    //===================Clear Function======================
    $scope.On_Clear = function () {
        $scope.txtRegNo = '';
        $scope.txtRegDate = new Date();
        $scope.txtDOB = new Date('01/01/1900');
        $scope.DDLTitle = 'Mr';
        $scope.CheckNewCnic_Mobile = 'NewCnic';
        $scope.txtGender = 'Male';
        $scope.txtFamilyNo = '';
        $scope.txtFPatientName = '';
        $scope.txtMPatientName = '';
        $scope.txtLPatientName = '';
        $scope.txtYear = '';
        $scope.txtMonth = '';
        $scope.txtDay = '';
        $scope.txtCnic = '';
        $scope.txtCnicExp = new Date('01/01/1900');
        $scope.txtCnicIssue = new Date('01/01/1900');
        $scope.txtCnicIdentity = '';
        $scope.txtORemarks = '';
        $scope.txtFname = '';
        $scope.txtReferBy = '';
        //$scope.CUSaveBtn = false;
        //$scope.CUUpdateBtn = true;
    }
    //=============On Clear For Address=============
    $scope.On_ClearA = function () {
        $scope.txtType = '0';
        $scope.txtHouseNo = '';
        $scope.txtTown = '';
        $scope.txtStreetNo = '';
        $scope.txtCity = '';
        $scope.txtState = '';
        $scope.txtCountry = '';
        $scope.txtZip = '';
        $scope.txtAddress = '';
        $scope.txtARemarks = '';
        //$scope.GetAllAVData('');
        $scope.dtAViewData = '';
    }
    //=============On Clear CNIC Detail=============
    $scope.On_ClearCN = function () {
        $scope.txtCnicIssue = new Date('01/01/1900');
        $scope.txtCnicExp = new Date('01/01/1900');
        $scope.txtFamilyNo = '';
        $scope.txtCnicIdentity = '';
        $scope.dtCNICViewData = '';
    }
    //=============On Clear For Contact=============
    $scope.On_ClearC = function () {
        $scope.txtContactType = '0';
        $scope.txtTelephone = '';
        $scope.txtEmail = '';
        $scope.txtCRemarks = '';
        //$scope.GetAllCVData('');
        $scope.dtCViewData = '';
    }
    //===================On Load Function======================
    $scope.OnLoad = function () {
        $scope.CheckNewCnicSelction();
        $scope.CheckNewCnic_Mobile = 'NewCnic';
        $scope.GetAddressType();
        $scope.GetContactType();
        $scope.txtRegDate = new Date();
        $scope.txtGender = 'Male';
        $scope.txtContactType = '0';
        $scope.txtDOB = new Date('01/01/1900');
        $scope.txtCnicIssue = new Date('01/01/1900');
        $scope.txtCnicExp = new Date('01/01/1900');
        $scope.txtYear = '';
        $scope.txtMonth = '';
        $scope.txtDay = '';
        //===Address===
        $scope.txtType = '0';
        //===For Proceed Button
        $scope.txtDoctName = '0';
        $scope.txtDoctID = '';
        $scope.txtBank = '0';
        $scope.txtPatType = 'Consultancy';
        $scope.DDLDisType = '0';
        $scope.DDLTitle = 'Mr';
        $scope.CheckNewCnic_Mobile = 'NewCnic';
        $scope.txtPayMethod = 'Cash';
        //===Doctor Portion Disable
        $scope.DocBankBtnDisable = true;
        $scope.DocBankInpDisable = true;
        $scope.DocPayBtnDisable = true;
        $scope.DocPayInpDisable = true;
        $scope.DocBalDisable = true;
        $scope.DocPaidDisable = true;
        $scope.DocApprDisable = true;
        $scope.DocDiscDisable = true;
        $scope.DocFeeDisable = true;
        $scope.DocNamSelDisable = true;
        $scope.DocIDDisable = true;
        $scope.DocNamDisable = true;
        //$scope.AlertMessagges();
    };
    $scope.fordisable = function () {
        $scope.DocBankBtnDisable = true;
        $scope.DocBankInpDisable = true;
        $scope.DocPayBtnDisable = true;
        $scope.DocPayInpDisable = true;
        $scope.DocBalDisable = true;
        $scope.DocPaidDisable = true;
        $scope.DocApprDisable = true;
        $scope.DocDiscDisable = true;
        $scope.DocFeeDisable = true;
        $scope.DocNamSelDisable = true;
        $scope.DocIDDisable = true;
        $scope.DocNamDisable = true;
    };
    //$scope.AlertMessagges = function () {
    //    alert('CNIC,DOB and Firstname is required for Correct Entry');
    //}
    //===============END===============
    $scope.OnLoad();

});