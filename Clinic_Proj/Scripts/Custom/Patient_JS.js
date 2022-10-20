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
    //==========Get Secound Token In One Relation================
    //$scope.GetSecound_InOne = function () {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/PatientReg/Secound_TokenRelation",
    //        data: {
    //            SecoundTkn: $scope.txtRelationNm,
    //            CNIC: $scope.txtCNIC,
    //            Relation: $scope.txtRelation
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        var dt = angular.fromJson(Return.data);
    //        if (dt.length > 0) {
    //            $scope.txtTokenNo = dt[0].TokenNo;
    //        }
    //        else {
    //            $scope.txtTokenNo = dt[0].TokenNo;
    //        }
    //    }, function myError(Return) {
    //        $scope.Notification('error', Return.data);
    //    });
    //};
    //==================Get Date Of Birth Calculate=======================
    $scope.GetMonthCalc = function () {
        var YY = $filter('date')(new Date(), 'yyyy');
        if ($scope.txtMonth == "" || $scope.txtMonth == "0" || $scope.txtDay == "" || $scope.txtDay == "0") {
            var Month = $filter('date')(new Date(), 'MM');
            var Days = $filter('date')(new Date(), 'dd');
            var CalcYear = YY - $scope.txtYear;
            var Fulldate = Month + '/' + Days + '/' + CalcYear;
            $scope.txtDOB = new Date(Month + "/" + Days + "/" + CalcYear);
        }
        else {
            var CalcYear = YY - $scope.txtYear;
            $scope.txtDOB = new Date($scope.txtMonth + '/' + $scope.txtDay + '/' + CalcYear);
        }
    };
    //=================CNIC No Transfer to Registration No====================
    $scope.Testing = function () {
        $scope.txtRegistrationNo = $scope.txtCNIC;
    };
    //==================Patient Related Data Get For Pharmacy===================
    $scope.GetPharmaAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_PharmacyMed",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.dtPharmaGetAll = angular.fromJson(Return.data);
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
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
        $window.open("/PatientReg/Token_Print?TokenNo=" + $scope.txtTokenNo, "_blank");
    };
    //==================Type Wise Insert Selection===================
    $scope.TypeWiseInsert = function () {
        if ($scope.txtPatType == "Consultancy" || $scope.txtPatType == "Session") {
            $scope.savedata();
            $scope.TokenPrint();
        }
        else if ($scope.txtPatType == "First Aid") {
            $scope.savedata();
        }
    }
    //==================Type Wise Update Selection===================
    //$scope.TypeWiseUpdate = function () {
    //    if ($scope.txtPatType == "Consultancy") {
    //        $scope.On_Update();
    //    }
    //    else if ($scope.txtPatType == "First Aid") {
    //        $scope.On_Update();
    //    }
    //}
    //==================Type Wise Update Selection===================
    //$scope.TypeWiseUpdate = function () {
    //    if ($scope.txtPatType == "Consultancy") {
    //        $scope.On_Update();
    //        $scope.On_Fee_Update();
    //    }
    //    else if ($scope.txtPatType == "First Aid") {
    //        $scope.On_Update();
    //    }
    //}
    $scope.TypeWiseSelection = function () {
        if ($scope.txtPatType == "Consultancy") {
            if ($scope.txtDoctName == '') {
                $scope.CUSaveBtn = true;
                $scope.CUUpdateBtn = true;
            }
            $scope.DocBankBtnDisable = false;
            $scope.DocBankInpDisable = false;
            $scope.CompIDDis = true;
            $scope.CompNameDis = true;
            $scope.DocPayBtnDisable = false;
            $scope.DocPayInpDisable = false;
            $scope.DocBalDisable = false;
            $scope.DocPaidDisable = false;
            $scope.DocApprDisable = false;
            $scope.DocDiscDisable = false;
            $scope.DocFeeDisable = false;
            $scope.DocNamSelDisable = false;
            $scope.DocNamDisable = false;
            $scope.DocIDDisable = false;
            $scope.GetPanalDataByCNIC($scope.txtRegistrationNo);
        }
        else if ($scope.txtPatType == "First Aid") {
            //alert("jkl");
            $scope.CUSaveBtn = false;
            $scope.DocBankBtnDisable = true;
            $scope.DocBankInpDisable = true;
            $scope.CompIDDis = true;
            $scope.CompNameDis = true;
            $scope.DocPayBtnDisable = true;
            $scope.DocPayInpDisable = true;
            $scope.DocBalDisable = true;
            $scope.DocPaidDisable = true;
            $scope.DocApprDisable = true;
            $scope.DocDiscDisable = true;
            $scope.DocFeeDisable = true;
            $scope.DocNamSelDisable = true;
            $scope.DocNamDisable = true;
            $scope.DocIDDisable = true;
            $scope.txtCharges = 0;
            $scope.txtDiscount = 0;
            $scope.txtPaidFee = 0;
            $scope.txtBalance = 0;
            $scope.txtDoctName = '';
            $scope.txtDoctID = '';
            $scope.DDLDisType = '0';
            $scope.txtPayMethod = 'Cash';
            $scope.txtCompID = '';
            $scope.txtCompName = '';
        }
        else if ($scope.txtPatType == "Session") {
            $scope.Notification('Warning', 'You Cannot Generate Direct Session Token From This Module');
            window.location.href = '/Registeration/RegNew';
        }
    }
    //==========Display All Patient Related lookup Data================
    $scope.GetAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==========Check Panal CNIC================
    $scope.CheckPanalCNIC = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/GetPanal_CNIC",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtCNIC = dt[0].CNIC;
                $scope.txtRegistrationNo = dt[0].CNIC;
                $scope.GetPanalDataByCNIC(dt[0].CNIC);
            }
            //else {
            //    $scope.txtCNIC = '';
            //    $scope.txtRegistrationNo = '';
            //}
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //===============Get Token Type From Function====================
    $scope.GetTknType_FromFunc = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/CheckTyp_record",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {
            var result = Return.data;
            if (result == "Session") {
                $scope.CheckSessionCNIC();
            }
            else
            if (result == "Panal") {
                $scope.CheckPanalCNIC();
            }
                else
            if (result == "Walk-In") {
                $scope.CheckCNIC();
            }

        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //==========Check CNIC================
    $scope.CheckCNIC = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_CNIC",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.txtCNIC = dt[0].CNIC;
                $scope.txtRegistrationNo = dt[0].CNIC;
                $scope.DDLTitle = dt[0].Title;
                $scope.txtGender = dt[0].Gender;
                $scope.GetDataByCNIC(dt[0].CNIC);
            }
            //else {
            //    $scope.txtCNIC = '';
            //}
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //==========Check Session CNIC================
    $scope.CheckSessionCNIC = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_SessionCNIC",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.txtCNIC = dt[0].SessionToken;
                $scope.GetSessionDataByCNIC(dt[0].SessionToken);
            }
            //else {
            //    $scope.txtCNIC = '';
            //}
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //==========Get Panal CNIC data================
    $scope.GetPanalDataByCNIC = function (id) {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/PanalRegister_CNIC",
            data: {
                CNIC: id
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtRelation = dt[0].Relation;
                $scope.DDLTitle = dt[0].Title;
                $scope.txtFPatientName = dt[0].FirstName;
                $scope.txtMPatientName = dt[0].MidName;
                $scope.txtLPatientName = dt[0].LastName;
                $scope.txtTel1 = dt[0].Tel1;
                $scope.txtTel2 = dt[0].Tel2;
                $scope.txtGuardianName = dt[0].GuardianName;
                $scope.txtReferBy = dt[0].ReferBy;
                $scope.txtGender = dt[0].Gender;
                $scope.txtAddress = dt[0].Address;
                $scope.txtCity = dt[0].City;
                $scope.txtCountry = dt[0].Country;
                $scope.txtDOB = new Date(dt[0].DOB);
                $scope.txtRemarks = dt[0].Remarks;
                if (dt[0].Discount1 > 0) {
                    $scope.DDLDisType = '%';
                    $scope.txtDisAprov = dt[0].CompanyName + ' ' + 'Panal Discount';
                }
                else {
                    $scope.DDLDisType = '0';
                    $scope.txtDisAprov = dt[0].CompanyName;
                }
                $scope.txtDiscount = dt[0].Discount1;
                $scope.txtCompID = dt[0].CompanyID;
                $scope.txtCompName = dt[0].CompanyName;
                $scope.NewToken(dt[0].CNIC, dt[0].Relation);
                $scope.Relationbtn = true;
                //$scope.MrbtnDisabl = true;
                }
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //==========Get CNIC Session data================
    $scope.GetSessionDataByCNIC = function (id) {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/RegisterSession_Token",
            data: {
                TokenNo: id
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtCNIC = dt[0].RegNo;
                $scope.txtRelation = dt[0].Relation;
                $scope.txtTokenNo = dt[0].SessionToken;
                $scope.txtPatType = dt[0].PatType;
                $scope.DDLTitle = dt[0].Title;
                $scope.txtFPatientName = dt[0].FirstName;
                $scope.txtMPatientName = dt[0].MidName;
                $scope.txtLPatientName = dt[0].LastName;
                $scope.txtDOB = new Date(dt[0].DOB);
                $scope.txtGender = dt[0].Gender;
                $scope.txtGuardianName = dt[0].GuardianName;
                //$scope.txtGuardianName = dt[0].GuardianName;
                $scope.txtTel1 = dt[0].Tel1;
                $scope.txtTel2 = dt[0].Tel2;
                $scope.txtRegistrationNo = dt[0].RegNo;
                $scope.txtAddress = dt[0].Address;
                $scope.txtCity = dt[0].City;
                $scope.txtCountry = dt[0].Country;
                $scope.txtEmailID = dt[0].EmailID;
                $scope.txtTel1 = dt[0].Tel1;
                $scope.txtTel2 = dt[0].Tel2;
                $scope.txtReferBy = dt[0].ReferBy;
                $scope.txtRemarks = dt[0].Remarks;
                $scope.txtDoctID = dt[0].DoctorID;
                $scope.txtDoctName = dt[0].DrName;
                $scope.txtCharges = dt[0].TotalFee;
                $scope.DDLDisType = dt[0].DiscountType;
                $scope.txtDiscount = dt[0].Discount;
                $scope.txtDisAprov = dt[0].DiscountApproval;
                $scope.txtPaidFee = dt[0].PaidFee;
                $scope.txtBalance = dt[0].Balance;
                $scope.pattypbtnDisabl = true;
                $scope.DocPayBtnDisable = false;
                $scope.DocBankBtnDisable = false;
                $scope.Relationbtn = true;
            }
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //==========Get CNIC data================
    $scope.GetDataByCNIC = function (id) {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Register_CNIC",
            data: {
                CNIC: id
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.GetPatAvail(dt[0].RegNo);
                $scope.txtRegistrationNo = dt[0].RegNo;
                $scope.DDLTitle = dt[0].Title;
                $scope.txtGender = dt[0].Gender;
                $scope.txtCNIC = dt[0].RegNo;
            }
            //else {
            //    $scope.txtRegistrationNo = dt[0].RegNo;
            //    $scope.txtRelation = dt[0].Relation;
            //    $scope.txtPatType = dt[0].PatType;
            //    $scope.DDLTitle = dt[0].Title;
            //    $scope.txtFPatientName = dt[0].FirstName;
            //    $scope.txtMPatientName = dt[0].MidName;
            //    $scope.txtLPatientName = dt[0].LastName;
            //    $scope.txtGuardianName = dt[0].GuardianName;
            //    $scope.txtTel1 = dt[0].Tel1;
            //    $scope.txtTel2 = dt[0].Tel2;
            //    $scope.txtGender = dt[0].Gender;
            //    $scope.txtEmailID = dt[0].EmailID;
            //    $scope.txtAddress = dt[0].Address;
            //    $scope.txtCity = dt[0].City;
            //    $scope.txtCountry = dt[0].Country;
            //    $scope.txtDOB = new Date(dt[0].DOB);
            //    $scope.txtReferBy = dt[0].ReferBy;
            //    $scope.txtRemarks = dt[0].Remarks;
            //    $scope.txtDoctName = dt[0].DrName;
            //}
        }, function myError(Return) {
            $scope.Notification('error', Return.data);
        });
    };
    //=================Get New Token====================
    $scope.NewToken = function (CNIC, Relation) {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_NewTknbyid",
            data: {
                CNIC: CNIC,
                Relation: Relation
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtTokenNo = dt[0].TokenNo;
            }
            else {
                $scope.txtTokenNo = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============Patient Detail if Patient is already Register Get By ID AND Token============
    $scope.GeExistdataid = function (ID, Relation,CCPL_ID) {
        //alert('ID is : ' + ID + ' Token is : ' + Token);
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_PatExibyid",
            data: {
                CNIC: ID,
                Relation: Relation,
                CCPL_RowID: CCPL_ID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.ShowPatient = false;
                $scope.txtTokenNo = dt[0].TokenNo;
                $scope.txtRegistrationNo = dt[0].RegNo;
                //$scope.txtPatType = dt[0].PatType;
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
                $scope.Relationbtn = true;
                //$scope.txtDoctName = dt[0].DrName;
                $scope.NewToken(dt[0].RegNo, dt[0].Relation)

                $scope.CUSaveBtn = true;
                $scope.txtCNIC_Disable = true;
                //$scope.CUUpdateBtn = false;
            }
            else {
                $scope.GetPatByRelation(Relation);
                $scope.CUSaveBtn = false;
                //$scope.CUUpdateBtn = true;
                $scope.txtPatType = '';
                $scope.DDLTitle = 'Mr';
                $scope.txtFPatientName = '';
                $scope.txtMPatientName = '';
                $scope.txtLPatientName = '';
                //$scope.txtCNIC = '';
                $scope.txtGuardianName = '';
                $scope.txtTel1 = '';
                $scope.txtTel2 = '';
                //$scope.txtGender = '';
                $scope.txtEmailID = '';
                $scope.txtAddress = '';
                $scope.txtCity = '';
                $scope.txtYear = '';
                $scope.txtMonth = '';
                $scope.txtDay = '';
                $scope.txtCountry = '';
                $scope.txtDOB = new Date('01/01/1900');
                $scope.txtReferBy = '';
                $scope.txtRemarks = '';
                //$scope.txtRelation = '';
                $scope.txtDivisionCode = '';
                $scope.txtSiteCode = '';
                $scope.txtLoginID = '';
                $scope.txtDoctName = '';
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
    //=============Patient get by CNIC From Registration============
    $scope.GetCNICFromRegist = function (ID, Token) {
        //alert('ID is : ' + ID + ' Token is : ' + Token);
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_PatExibyid",
            data: {
                CNIC: ID,
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.ShowPatient = false;
                $scope.txtTokenNo = dt[0].TokenNo;
                //$scope.txtPatType = dt[0].PatType;
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
                //$scope.txtDoctName = dt[0].DrName;

                $scope.CUSaveBtn = false;
                $scope.txtCNIC_Disable = true;
                //$scope.CUUpdateBtn = false;
            }
            else {
                $scope.CUSaveBtn = false;
                //$scope.CUUpdateBtn = true;
                $scope.txtPatType = '';
                $scope.DDLTitle = 'Mr';
                $scope.txtFPatientName = '';
                $scope.txtMPatientName = '';
                $scope.txtLPatientName = '';
                $scope.txtCNIC = '';
                $scope.txtGuardianName = '';
                $scope.txtTel1 = '';
                $scope.txtTel2 = '';
                $scope.txtYear = '';
                $scope.txtMonth = '';
                $scope.txtDay = '';
                $scope.txtGender = 'Male';
                $scope.txtEmailID = '';
                $scope.txtAddress = '';
                $scope.txtCity = '';
                $scope.txtCountry = '';
                $scope.txtDOB = new Date('01/01/1900');
                $scope.txtReferBy = '';
                $scope.txtRemarks = '';
                $scope.txtRelation = '';
                $scope.txtDivisionCode = '';
                $scope.txtSiteCode = '';
                $scope.txtLoginID = '';
                $scope.txtDoctName = '';
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
    //==============Patient data Get By id=================
    $scope.GetDataByID = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_databyid",
            data: {
                TokenNo : ID
            }
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.txtRegistrationNo = dt[0].RegNo;
                $scope.txtTokenNo = dt[0].TokenNo;
                //$scope.txtPatType = dt[0].PatType;
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
                $scope.txtDoctID = dt[0].DrID;
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
                $scope.txtPatType = '';
                $scope.DDLTitle = 'Mr';
                $scope.txtFPatientName = '';
                $scope.txtMPatientName = '';
                $scope.txtLPatientName = '';
                $scope.txtCNIC = '';
                $scope.txtGuardianName = '';
                $scope.txtTel1 = '';
                $scope.txtTel2 = '';
                $scope.txtGender = '';
                $scope.txtEmailID = '';
                $scope.txtYear = '';
                $scope.txtMonth = '';
                $scope.txtDay = '';
                $scope.txtAddress = '';
                $scope.txtCity = '';
                $scope.txtCountry = '';
                $scope.txtDOB = new Date('01/01/1900');
                $scope.txtReferBy = '';
                $scope.txtRemarks = '';
                $scope.txtRelation = '';
                $scope.txtDivisionCode = '';
                $scope.txtSiteCode = '';
                $scope.txtLoginID = '';
                $scope.txtDoctName = '';
                $scope.txtDoctID = '';
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
    //==================Delete Patient=============================
    $scope.OnDelete = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/OnDelete",
            data: {
                ID: $scope.txtRegistrationNo
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.On_Clear();
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Site');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });

    };
    //===========New Token Create=================
    $scope.GetPatTokByID = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/get_Pat_Token",
            data: {}
        }
        $http(displayReq).then(function (Return) {

            var dt = angular.fromJson(Return.data);

            if (dt.length > 0) {
                $scope.txtTokenNo = dt[0].TokenNo;
            }
            else {
                $scope.txtTokenNo = '';
            }
            $scope.CnicDis = false;
            $scope.On_ClearToken();

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==========Get Patient Relation by id==============
    $scope.GetPatByRelation = function (Relation) {
        $scope.txtRelation = Relation;
        $scope.NewToken($scope.txtCNIC, $scope.txtRelation);
    };
    //=============Get Patient Relation related All Data=================
    $scope.GetPatRelation = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_PatdataRelation",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetRelationAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===================Get Dr Name By ID==================
    //$scope.GetDoctorName = function (DoctorName, Charges,ID) {

    //};
    $scope.GetDoctorName = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/Registeration/Get_databyid",
            data: {
                DrID: ID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                if (dt[0].DiscountApproval != 'Free Camp') {
                    $scope.txtDoctName = dt[0].DrName;
                    $scope.CUSaveBtn = false;
                    $scope.txtDoctID = dt[0].DrID;
                    $scope.CUUpdateBtn = true;
                    $scope.txtCharges = dt[0].Charges;
                    $scope.txtPaidFee = dt[0].Charges;
                    if ($scope.txtCompID == '' || $scope.txtCompID == null || $scope.txtCompID == undefined) {
                        $scope.DDLDisType = '0';
                        $scope.txtPayMethod = 'Cash';
                        $scope.txtDiscount = 0;
                        $scope.txtDisAprov = '';
                    }
                    else {
                        //Nothing
                    }
                    $scope.CalculateDiscount();
                }
                else if (dt[0].DiscountApproval == 'Free Camp') {
                    $scope.txtDoctName = dt[0].DrName;
                    $scope.CUSaveBtn = false;
                    $scope.txtDoctID = dt[0].DrID;
                    $scope.CUUpdateBtn = true;
                    $scope.txtCharges = dt[0].Charges;
                    $scope.txtPaidFee = 0;
                    $scope.DDLDisType = dt[0].DiscountType;
                    $scope.txtPayMethod = 'Cash';
                    $scope.txtDiscount = dt[0].Discount;
                    $scope.txtDisAprov = dt[0].DiscountApproval;
                    $scope.CalculateDiscount();
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
    //=============Get Doctor Name======================
    $scope.GetDoctorname = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_DoctorName",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetDocName = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============Get Bank Name======================
    $scope.GetBank = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_BankName",
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
    $scope.GetBankName = function (BankName) {
        $scope.txtBank = BankName;
    };
    //=============Get Payment Method======================
    $scope.GetPayMeth = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_PayMethod",
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
    $scope.GetPayByid = function (MethodName) {
        $scope.txtPayMethod = MethodName;
    };
    //================Get Patient Type like Consultancy,Emergency,First Aid Etc============
    $scope.GetPatByType = function (PatType) {
        $scope.txtPatType = PatType;
        $scope.TypeWiseSelection();
    };
    //=================Get Patient Type By lookup====================
    $scope.GetPatType = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_PatdataType",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {
            if ($scope.txtDiscount == 0 || $scope.txtDiscount == null || $scope.txtDiscount == '') {
                $scope.txtPayMethod = 'Cash';
                $scope.txtBank = '';
                $scope.txtDoctName = '';
                $scope.txtDoctID = '';
                $scope.txtCharges = 0;
                $scope.txtDiscount = 0;
                $scope.txtPaidFee = 0;
                $scope.txtBalance = 0;
                $scope.txtDisAprov = 'No Discount';
                $scope.DDLDisType = '0'; 
            }
            $scope.dtGetTypeAll = angular.fromJson(Return.data);
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==================Print Report=======================
    $scope.PrintRpt = function () {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Print_Rpt",
            data: {
                TokenNo: $scope.txtTokenNo
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Print") {
                //alert("G");
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
    //===============Patient Insert======================
    $scope.savedata = function () {
        var displayReq = {
            method: 'POST',
            url: '/PatientReg/Add_record',
            data: {
                RegNo: $scope.txtRegistrationNo,
                TokenNo: $scope.txtTokenNo,
                PatType: $scope.txtPatType,
                PatName: $scope.txtPatientName,
                Title: $scope.DDLTitle,
                FirstName: $scope.txtFPatientName,
                MidName: $scope.txtMPatientName,
                LastName: $scope.txtLPatientName,
                CNIC: $scope.txtCNIC,
                Guardian: $scope.txtGuardianName,
                Tel1: $scope.txtTel1,
                Tel2: $scope.txtTel2,
                Gender: $scope.txtGender,
                EmailID: $scope.txtEmailID,
                Address: $scope.txtAddress,
                City: $scope.txtCity,
                Country: $scope.txtCountry,
                DOB: $scope.txtDOB,
                ReferBy: $scope.txtReferBy,
                Remarks: $scope.txtRemarks,
                Relation: $scope.txtRelation
                //DivisionID: $scope.txtDivisionCode,
                //SiteID: $scope.txtSiteCode,
                //LoginID: $scope.txtLoginID
            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Patient');
                if ($scope.txtPatType == 'Consultancy' || $scope.txtPatType == 'Session') {
                    $scope.saveFeedata();
                }
                else {
                    window.location.href = '/Registeration/RegNew';
                }
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
    //===============Fee Data Insert=========================
    $scope.saveFeedata = function () {
        var displayReq = {
            method: 'POST',
            url: '/PatientReg/Add_Feerecord',
            data: {
                RegNo: $scope.txtRegistrationNo,
                TokenNo: $scope.txtTokenNo,
                Title: $scope.DDLTitle,
                FirstName: $scope.txtFPatientName,
                MidName: $scope.txtMPatientName,
                LastName: $scope.txtLPatientName,
                CNIC: $scope.txtCNIC,
                DrName: $scope.txtDoctName,
                DrID: $scope.txtDoctID,
                TotalFee: $scope.txtCharges,
                Discount: $scope.txtDiscount,
                PaidFee: $scope.txtPaidFee,
                Balance: $scope.txtBalance,
                Remarks: $scope.txtRemarks,
                DisAprov: $scope.txtDisAprov,
                PaymentMeth: $scope.txtPayMethod,
                Bank: $scope.txtBank,
                CompanyID: $scope.txtCompID,
                CompanyName: $scope.txtCompName,
                //DivisionID: $scope.txtDivisionCode,
                //SiteID: $scope.txtSiteCode,
                //LoginID: $scope.txtLoginID,
                DiscountType: $scope.DDLDisType
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Fee');
                $scope.On_Clear();
                window.location.href = '/Registeration/RegNew';
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };

    //========================Patient Update===============
    //$scope.On_Update = function () {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/PatientReg/update_record",
    //        data: {
    //            RegNo: $scope.txtRegistrationNo,
    //            TokenNo: $scope.txtTokenNo,
    //            PatType: $scope.txtPatType,
    //            Title: $scope.DDLTitle,
    //            FirstName: $scope.txtFPatientName,
    //            MidName: $scope.txtMPatientName,
    //            LastName: $scope.txtLPatientName,
    //            CNIC: $scope.txtCNIC,
    //            Guardian: $scope.txtGuardianName,
    //            Tel1: $scope.txtTel1,
    //            Tel2: $scope.txtTel2,
    //            Gender: $scope.txtGender,
    //            EmailID: $scope.txtEmailID,
    //            Address: $scope.txtAddress,
    //            City: $scope.txtCity,
    //            Country: $scope.txtCountry,
    //            DOB: $scope.txtDOB,
    //            ReferBy: $scope.txtReferBy,
    //            Remarks: $scope.txtRemarks,
    //            Relation: $scope.txtRelation,
    //            DivisionID: $scope.txtDivisionCode,
    //            SiteID: $scope.txtSiteCode,
    //            LoginID: $scope.txtLoginID
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        if (Return.data == "Updated") {
    //            $scope.Notification('success', 'Operation Completed', 'Update Patient');
    //            if ($scope.txtPatType == 'Consultancy') {
    //                $scope.On_Fee_Update();
    //            }
    //            $scope.On_Clear();
    //        }
    //        else {
    //            $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
    //        }
    //    }, function myError(Return) {
    //        $scope.On_Clear();
    //        $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
    //    });
    //};
    //======================Fee Update===================
    //$scope.On_Fee_Update = function () {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/PatientReg/update_Feerecord",
    //        data: {
    //            RegNo: $scope.txtRegistrationNo,
    //            TokenNo: $scope.txtTokenNo,
    //            Title: $scope.DDLTitle,
    //            FirstName: $scope.txtFPatientName,
    //            MidName: $scope.txtMPatientName,
    //            LastName: $scope.txtLPatientName,
    //            CNIC: $scope.txtCNIC,
    //            DrName: $scope.txtDoctName,
    //            DrID: $scope.txtDoctID,
    //            TotalFee: $scope.txtCharges,
    //            Discount: $scope.txtDiscount,
    //            PaidFee: $scope.txtPaidFee,
    //            Balance: $scope.txtBalance,
    //            Remarks: $scope.txtRemarks,
    //            DisAprov: $scope.txtDisAprov,
    //            DivisionID: $scope.txtDivisionCode,
    //            SiteID: $scope.txtSiteCode,
    //            LoginID: $scope.txtLoginID,
    //            CompanyID: $scope.txtCompID,
    //            CompanyName: $scope.txtCompName,
    //            DiscountType: $scope.DDLDisType
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        if (Return.data == "Updated") {
    //            $scope.Notification('success', 'Operation Completed', 'Update Fee');
    //            $scope.On_Clear();
    //        }
    //        else {
    //            $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
    //        }
    //    }, function myError(Return) {
    //        $scope.On_Clear();
    //        $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
    //    });
    //};
    //====================Clear Function==================
    $scope.On_Clear = function () {
        $scope.txtRegistrationNo = '';
        $scope.txtTokenNo = '';
        $scope.txtPatType = '';
        $scope.DDLTitle = 'Mr';
        $scope.txtFPatientName = '';
        $scope.txtMPatientName = '';
        $scope.txtLPatientName = '';
        $scope.txtCNIC = '';
        $scope.txtGuardianName = '';
        $scope.txtTel1 = '';
        $scope.txtTel2 = '';
        $scope.txtGender = 'Male';
        $scope.txtEmailID = '';
        $scope.txtAddress = '';
        $scope.txtYear = '';
        $scope.txtMonth = '';
        $scope.txtDay = '';
        $scope.txtCity = '';
        $scope.txtCountry = '';
        $scope.txtDOB = new Date('01/01/1900');
        $scope.txtReferBy = '';
        $scope.txtRemarks = '';
        $scope.txtCompID = '';
        $scope.txtCompName = '';
        $scope.txtRelation = '';
        $scope.txtDivisionCode = '';
        $scope.txtSiteCode = '';
        $scope.txtLoginID = '';
        $scope.txtPayMethod = 'Cash';
        $scope.txtBank = '';
        $scope.txtDoctName = '';
        $scope.txtDoctID = '';
        $scope.txtCharges = 0;
        $scope.txtDiscount = 0;
        $scope.txtPaidFee = 0;
        $scope.txtBalance = 0;
        $scope.txtDisAprov = 'No Discount';
        $scope.DDLDisType = '0';

        txtCNIC_Disable = false;
        $scope.CUSaveBtn = false;
        $scope.CUUpdateBtn = true;

    };
    //==========================================================
    $scope.On_ClearToken = function () {
        $scope.txtRegistrationNo = '';

        $scope.txtPatType = '';
        $scope.DDLTitle = 'Mr';
        $scope.txtFPatientName = '';
        $scope.txtMPatientName = '';
        $scope.txtLPatientName = '';
        $scope.txtCNIC = '';
        $scope.txtGuardianName = '';
        $scope.txtCompID = '';
        $scope.txtCompName = '';
        $scope.txtTel1 = '';
        $scope.txtTel2 = '';
        $scope.txtGender = 'Male';
        $scope.txtEmailID = '';
        $scope.txtAddress = '';
        $scope.txtCity = '';
        $scope.txtCountry = '';
        $scope.txtYear = '';
        $scope.txtMonth = '';
        $scope.txtDay = '';
        $scope.txtDOB = new Date('01/01/1900');
        $scope.txtReferBy = '';
        $scope.txtRemarks = '';
        $scope.txtRelation = '';
        $scope.txtDivisionCode = '';
        $scope.txtSiteCode = '';
        $scope.txtLoginID = '';
        $scope.txtDoctName = '';
        $scope.txtCharges = 0;
        $scope.txtPayMethod = 'Cash';
        $scope.txtBank = '';
        $scope.txtDiscount = 0;
        $scope.txtPaidFee = 0;
        $scope.txtBalance = 0;
        $scope.txtDisAprov = '';
        $scope.DDLDisType = '0';

        $scope.txtCNIC_Disable = false;

        $scope.CUSaveBtn = false;
        $scope.CUUpdateBtn = true;
        $scope.DDLTitle = 'Mr';

    };
    //===========Get Patient Data By CNIC And Relation IF Already Available
    $scope.GetPatAvail_ByRelation = function (ID,Relation) {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/GetPat_Available",
            data: {
                CNIC: ID,
                Relation: Relation
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.ShowPatient = true;
            }
            else {
                $scope.GetPatByRelation(Relation);
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===========Get Patient Data By CNIC IF Already Available
    $scope.GetPatAvail = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/PatientReg/Get_PatAvailable",
            data: {
                CNIC : ID
            }
        }
        $http(displayReq).then(function (Return) {

            //alert(Return.data);

            $scope.dtGetPatAvail = angular.fromJson(Return.data);
            if ($scope.dtGetPatAvail.length > 0) {
                $scope.ShowPatient = true;
                //$scope.ShowCNICReg = false;
                //$scope.NewToken(ID, 'Self');
            }
            else {
                //$scope.ShowCNICReg = true;
                $scope.ShowPatient = false;

            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Close Popup of Already Available Patient=================
    $scope.ClosePatientModal = function () {
        $scope.ShowPatient = false;
    };
    //==============Close Popup if Patient are not Avilable=================
    $scope.CloseCNICRegModal = function () {
        $scope.ShowCNICReg = false;
    };
    //==============Close Popup of if patient are not Available for Proceed=================
    $scope.OpenCNICRegForm = function () {
        $scope.ShowCNICReg = false;
        window.location.href = '/Registeration/RegNew';
    };
    //===================On Load Function If View File Reload============
    $scope.OnLoad = function () {
        $scope.CUSaveBtn = false;
        $scope.CUUpdateBtn = true;
        $scope.CnicDis = true;
        $scope.txtCharges = 0;
        $scope.txtDiscount = 0;
        $scope.txtPaidFee = 0;
        $scope.txtBalance = 0;
        $scope.txtGender = 'Male';
        $scope.txtYear = '';
        $scope.txtMonth = '';
        $scope.txtDay = '';
        $scope.txtDoctName = '';
        $scope.txtDoctID = '';
        $scope.DDLDisType = '0';
        $scope.txtDOB = new Date('01/01/1900');
        $scope.txtTokenDate = new Date();
        $scope.DDLTitle = 'Mr';
        $scope.txtCNIC = '';
        $scope.txtPayMethod = 'Cash';
        //$scope.CheckSessionCNIC();
        //$scope.CheckPanalCNIC();
        //$scope.CheckCNIC();
        $scope.GetTknType_FromFunc();
        //Doc Detail Disable
        $scope.DocBankBtnDisable = true;
        $scope.CompIDDis = true;
        $scope.CompNameDis = true;
        $scope.DocBankInpDisable = true;
        $scope.DocPayBtnDisable = true;
        $scope.DocPayInpDisable = true;
        $scope.DocBalDisable = true;
        $scope.DocPaidDisable = true;
        $scope.DocApprDisable = true;
        $scope.DocDiscDisable = true;
        $scope.DocFeeDisable = true;
        $scope.DocNamSelDisable = true;
        $scope.DocNamDisable = true;
        $scope.DocIDDisable = true;
    };
    $scope.OnLoad();
});