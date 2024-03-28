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
            //==============Calculate Fee=============
            $scope.CalculateFee = function () {
                var Paid = $scope.txtPaid;
                var totalcharges = $scope.txtTotalFee;
                $scope.txtBalance = totalcharges-Paid;
            };
            //==============For Save Data =============
            $scope.SaveCheck = function () {
                if ($scope.txtTokenNo == '' || $scope.txtTokenNo == null) {
                    $scope.Notification('error', 'System Alert', 'Please Select Patient To Popup List');
                }
                else {
                    if ($scope.txtPaid > 0) {
                        $scope.SaveData();
                        $scope.FAPrint();
                    }
                    else {
                        $scope.Notification('error', 'System Alert', 'Please Enter Paid Amount');
                    }
                }
            };
            //=========First Aid Slip============
            $scope.FAPrint = function () {
                $window.open("/FirstAidPay/FAPrint?TokenNo=" + $scope.txtTokenNo, "_blank");
            };
            //==============Display Patient Look up Data===================
            $scope.GetAllData = function () {
                var displayReq = {
                    method: "POST",
                    url: "/FirstAidPay/Get_data",
                    data: {
                    }
                }
                $http(displayReq).then(function (Return)
                {
                    $scope.dtGetAll = angular.fromJson(Return.data);
                    //$scope.On_Clear();

                }, function myError(Return) {
                    $scope.Notification('error', 'Error Code LC0001', Return.data);
                });
            };
            //==================Check Payment Record=======================
            $scope.CheckFaPayment = function (Token) {
                var displayReq = {
                    method: "POST",
                    url: "/FirstAidPay/FA_CheckPayment",
                    data: {
                        TokenNo: Token
                    }
                }
                $http(displayReq).then(function (Return) {
                    var dtList = angular.fromJson(Return.data);
                    if (dtList.length > 0) {
                        $scope.Notification('error', 'System Alert', 'You Already Received Payment');
                        $scope.AfterPayRec = true;
                    }
                    else {
                        if ($scope.txtTotalFee == 0) {
                            $scope.Notification('error', 'System Alert', 'Contact to First Aid Incharge For OUT this Command');
                            $scope.AfterPayRec = true;
                        }
                        else {
                            if ($scope.txtTotalFee > 0) {
                                $scope.Notification('success', 'System Alert', 'Please Generate Bill To this Payment Amount');
                                $scope.AfterPayRec = false;
                            }
                        }
                  }
                }, function myError(Return) {
                    $scope.Notification('error', 'Error Code LC0001', Return.data);
                });
            };
             //=============Display Patient Data Get By ID================
            $scope.GetDataByID = function (ID) {
                var displayReq = {
                    method: "POST",
                    url: "/FirstAidPay/Get_databyid",
                    data: {
                        TokenNo : ID
                    }
                }
                $http(displayReq).then(function (Return) {
                    var dt = angular.fromJson(Return.data);
                    if (dt.length > 0)
                    {
                        $scope.txtTokenNo = dt[0].TokenNo;
                        $scope.txtTokenDate = dt[0].TokenDate;
                        $scope.txtRegNo = dt[0].RegNo;
                        $scope.txtGender = dt[0].Gender;
                        $scope.txtPatAge = dt[0].Age;
                        $scope.txtPatCNIC = dt[0].CNIC;
                        $scope.txtPatName = dt[0].FullName;
                        $scope.txtDocName = dt[0].DoctorName;
                        $scope.txtTotalFee = dt[0].TotalFee;
                        //$scope.txtPaid = dt[0].PaidFee;
                        $scope.CheckFaPayment(dt[0].TokenNo);
                        $scope.txtBalance = dt[0].Balance;

                        //$scope.GetModeTxtByID(dt[0].TokenNo);
                        //$scope.GetTotal();
                        //$scope.GetViewAllData(dt[0].TokenNo);
                        //$scope.GetRecViewAllData(dt[0].TokenNo);

                        $scope.CUSaveBtn = false;
                        //$scope.CUUpdateBtn = True;
                    }
                    else {
                        $scope.CUSaveBtn = false;
                        //$scope.CUUpdateBtn = false;

                        $scope.txtTokenNo = '';
                        $scope.txtTokenDate = '';
                        $scope.txtRegNo = '';
                        $scope.txtGender = '';
                        $scope.txtPatAge = '';
                        $scope.txtPatCNIC = '';
                        $scope.txtPatName = '';
                        $scope.txtDocName = '';
                    }

                }, function myError(Return) {
                    $scope.Notification('error', 'Error Code LC0001', Return.data);
                });
            };
            //For Insert First Aid Payment
            $scope.SaveData = function () {
                var displayReq = {
                    method: "POST",
                    url: "/FirstAidPay/Save_record",
                    data: {
                        TokenNo: $scope.txtTokenNo,
                        RegNo: $scope.txtRegNo,
                        FullName: $scope.txtPatName,
                        TokenDate: $scope.txtTokenDate,
                        Age: $scope.txtPatAge,
                        Gender: $scope.txtGender,
                        DoctorName: $scope.txtDocName,
                        TotalAmount: $scope.txtTotalFee,
                        PaymentMeth: $scope.txtPayMethod,
                        Bank: $scope.txtBank,
                        Balance: $scope.txtBalance,
                        PaidFee: $scope.txtPaid,
                        Remarks: $scope.txtRemarks
                        //RefundApproval: $scope.txtRefundApproval,
                        //RefundType: $scope.txtPatRefundType
                    }
                }
                $http(displayReq).then(function (Return) {
                    if (Return.data == "Inserted")
                    {
                        $scope.Notification('success', 'Operation Completed', 'Insert Patient FA Payment');
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
            //=================Clear Function=====================
            $scope.On_Clear = function () {
                $scope.txtTokenNo = '';
                $scope.txtRegNo = '';
                $scope.txtPatName = '';
                $scope.txtTokenDate = '';
                $scope.txtPatAge = '';
                $scope.txtGender = '';
                $scope.txtDocName = '';
                $scope.txtTotalFee = 0;
                $scope.txtBalance = 0;
                $scope.txtPaid = 0;
                $scope.txtRemarks = '';
                $scope.txtPayMethod = 'Cash';
                $scope.txtBank='';
            };
            $scope.OnLoad = function () {
                $scope.CUSaveBtn = false;
                $scope.CUUpdateBtn = true;
                $scope.txtTotalFee = 0;
                $scope.txtBalance = 0;
                $scope.txtPaid = 0;
                $scope.txtPayMethod = 'Cash';
            };
            $scope.OnLoad();
});