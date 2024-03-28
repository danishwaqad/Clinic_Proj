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
    //===================Group Medicine Working
    //=============Get Diagnose ID================
    $scope.Get_GroupOnLoadID = function () {
        if ($scope.txtTokenNo != '' && $scope.txtTokenNo != undefined) {
            $scope.ShowGrpMedic_Mode = true;
            $scope.GetDiagNoseID();
            $scope.GetDocID();
        }
        else {
            alert("Please Select First Patient MR#");
        }
    };
    //===============Get Diagnose by id=======================
    $scope.GetDiag_ForGrpByid = function (ShortName) {
        $scope.txtDiagnoseName = ShortName;
    };
    //==============Display Group Data By Lookup===================
    $scope.GetGroup1AllData = function () {
        var displayReq = {
            method: "POST",
            url: "/DocMedi/GetGroup1_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.dtGroup1All = angular.fromJson(Return.data);
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //============Display Medication View All Data==============
    $scope.Get_GroupMedicineData = function (DiagnoseID, DiagnoseName) {
        var displayReq = {
            method: "POST",
            url: "/DocMedi/GetMed_Viewdata",
            data: {
                RefGroupID: DiagnoseID,
                RefGroupName: DiagnoseName
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dt_GrpMedi_All = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Get Group 1 Record By ID============
    $scope.Get_Group1_Byid = function (Group1_ID) {
        var displayReq = {
            method: "POST",
            url: "/DocMedi/Get_Group1_databyid",
            data: {
                GroupID: Group1_ID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtDiagnoseName = dt[0].GroupName;
                $scope.txtDiagnoseID = dt[0].GroupID;
                $scope.txtDiagnoseHist = dt[0].Remarks;
                $scope.Get_GroupMedicineData(dt[0].GroupID, dt[0].GroupName);
            }
            else {
                $scope.GetDiagNoseID();
                $scope.GetDocID();
                $scope.txtDiagnoseName = '';
                $scope.txtDiagnoseHist = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============Get Diagnose ID================
    $scope.GetDiagNoseID = function () {
        var displayReq = {
            method: "POST",
            url: "/DocMedi/Get_DiagID",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtDiagnoseID = dt[0].ID;
            }
            else {
                $scope.txtDiagnoseID = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============Get Doctor Name And ID================
    $scope.GetDocID = function () {
        var displayReq = {
            method: "POST",
            url: "/DocMedi/Get_DoctorID",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtDoctorID = dt[0].DoctorID;
                $scope.txtDoctorName = dt[0].DoctorName;
            }
            else {
                $scope.txtDoctorID = '';
                $scope.txtDoctorName = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };

    //==================Group Data Insert==================
    $scope.Save_TempGrp_Diag = function () {
        $scope.save_GroupDiagdata();
        for (var i = 0; i < $scope.dt_GrpMedi_All.length; i++) {
            var displayReq = {
                method: 'POST',
                url: '/Consult/Add_Group_Med_Recrd',
                data: {
                    TokenNo: $scope.txtTokenNo,
                    GenericName: $scope.dt_GrpMedi_All[i].ItemName,
                    TypeID: $scope.dt_GrpMedi_All[i].TypeID,
                    SubTypeID: $scope.dt_GrpMedi_All[i].SubTypeID,
                    IsMorning: $scope.dt_GrpMedi_All[i].IsMorning,
                    IsEvening: $scope.dt_GrpMedi_All[i].IsEvening,
                    IsNight: $scope.dt_GrpMedi_All[i].IsNight,
                    NoOfDays: $scope.dt_GrpMedi_All[i].NoOfDays,
                    DosageQty: $scope.dt_GrpMedi_All[i].DosageQty,
                    UrduText: $scope.dt_GrpMedi_All[i].UrduText,
                    MediRemarks: $scope.dt_GrpMedi_All[i].Remarks
                }
            }
            $http(displayReq).then(function (Return) {
                if (Return.data == "Inserted") {
                    $scope.Notification('success', 'Operation Completed', 'Medicines Group Insert');
                    window.location.reload();
                }
                else {
                    $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
                }
            }, function myError(Return) {
                //$scope.On_Clear();
                $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            });
        }
    };
    //================Group Diagnose Data Insert=========================
    $scope.save_GroupDiagdata = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_Group_DiagRecrd',
            data: {
                TokenNo: $scope.txtTokenNo,
                DisagnoseSName: $scope.txtDiagnoseName,
                DiagRemarks: $scope.txtDiagnoseHist

            }
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Diagnose Group Insert');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //=======================================
    //==================Print Report=======================
    //$scope.ConsultacyRept = function () {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/Consult/Print_Slip_Test",
    //        data: {
    //            TokenNo: $scope.txtTokenNo,
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        $scope.dtGetDocHistory = angular.fromJson(Return.data);
    //    }, function myError(Return) {
    //        $scope.Clear();
    //        $scope.Notification('error', Return.data);
    //    });
    //};
    //=================Collapse Cards=========================
    //===============Display Diagnose 2 Related Data ==============
    $scope.GetDiagnose2AllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_DiagnoseViewdata",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.dtDiagnose2ViewGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code GEN0001', Return.data);
        });
    };
    //===============Display Diagnose 2 Related Data get by id==============
    $scope.Get_DiagnoseViewdataByid = function (id) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_DiagnoseViewdataByid",
            data: {
                HeaderID: id
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var body = "";
            for (var i = 0; i < dt.length; i++) {
                body += "<div class=\"card-body\">";
                body += "<input class=\"box-title m-b-0 text-danger\" type=\"checkbox\">" + dt[i].DiseaseName + " </input>";
                body += "</div>";
            }
            document.getElementById("G-" + id).innerHTML = body;

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code GEN0001', Return.data);
        });
    };
    //=================Collapse Cards End=====================
    //============Session Working================================
    //===================Display Session View All Data===================
    $scope.GetSessionViewData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_Sessiondata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.dtGetSessionviewAll = angular.fromJson(Return.data);
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //Display History Session View All Data
    $scope.GetSessionHistViewData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/Get_Sessiondata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                var FromDate = $filter('date')(new Date(dt[i].FromDate), 'dd/MM/yyyy');
                var ToDate = $filter('date')(new Date(dt[i].ToDate), 'dd/MM/yyyy');
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + FromDate + ' </td>';
                TBody = TBody + '<td> ' + ToDate + ' </td>';
                TBody = TBody + '<td> ' + dt[i].NoOfSession + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("Session-" + Token).innerHTML = TBody;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===================Display Session Activity View All Data===================
    $scope.GetSessionActData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_SessionActdata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.dtGetSessionActAll = angular.fromJson(Return.data);
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //====================Display History Session Activity View All Data===============
    $scope.GetHistActivityViewData = function (HistToken) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/Get_SessionActdata",
            data: {
                TokenNo: HistToken
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + dt[i].SessionActivity + ' </td>';
                TBody = TBody + '<td> ' + dt[i].SessionRemarks + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("SessionAct-" + HistToken).innerHTML = TBody;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Display Session Activity Lookup===================
    $scope.GetSessionActAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetSesionAct_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.dtSAGetCNAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Get Session data by id=================
    $scope.GetSAByid = function (SessionAct) {
        $scope.txtSessionAct = SessionAct;
    };
    //==============Session Data Delete============== 
    $scope.OnSessionDelete = function (ids) {
        var displayReq = {
            method: "POST",
            url: "/Consult/OnSessionDelete",
            data: {
                TokenNo: ids
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.txtFromDate = new Date();
            $scope.txtToDate = new Date();
            $scope.txtNoOfSession = 0;
            $scope.txtSessionRemarks = '';
            $scope.GetSessionViewData($scope.txtTokenNo);
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Session Schedule');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==================Session Data Insert==================
    $scope.saveSession = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_SessionRecrd',
            data: {
                TokenNo: $scope.txtTokenNo,
                SessionRemarks: $scope.txtSessionRemarks,
                DateFrom: $scope.txtFromDate,
                DateTo: $scope.txtToDate,
                NoOfSession: $scope.txtNoOfSession
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.GetSessionViewData($scope.txtTokenNo);
            $scope.txtSessionRemarks = '';
            $scope.txtNoOfSession = 0;
            $scope.txtFromDate = new Date();
            $scope.txtToDate = new Date();
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Session');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==================Session Activity Data Insert==================
    $scope.saveActSession = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_SessionActRecrd',
            data: {
                TokenNo: $scope.txtTokenNo,
                SessionActivity: $scope.txtSessionAct,
                SessionActRemarks: $scope.txtSessionActRemarks
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.GetSessionActData($scope.txtTokenNo);
            $scope.txtSessionAct = '';
            $scope.txtSessionActRemarks = '';
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Session Activity');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==============Session Act Data Delete============== 
    $scope.OnSessionActDelete = function (ids) {
        var displayReq = {
            method: "POST",
            url: "/Consult/OnSessionActDelete",
            data: {
                TokenNo: ids
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.txtSessionAct = '';
            $scope.txtSessionActRemarks = '';
            $scope.GetSessionActData($scope.txtTokenNo);
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Session Schedule');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==========================================================================
    //==================Print Report=======================
    $scope.ConsultacyRept = function () {
        $scope.PrintingTest();
        var displayReq = {
            method: "POST",
            url: "/Consult/Print_Slip_Test",
            data: {
                TokenNo: $scope.txtTokenNo
                //DocDate: new Date($scope.DT_Doc)
            }
        }
        $http(displayReq).then(function (Return) {
            //$scope.dtGetDocHistory = angular.fromJson(Return.data);
        }, function myError(Return) {
            //$scope.Clear();
            //alert(Return.data);
            $scope.Notification('error', Return.data);
        });
    };

    $scope.PrintingTest = function () {
        $window.open('/Consult/Print_Slip_Test?TokenNo=' + $scope.txtTokenNo, '_blank');
    };
    //================Display Vital View All Data===============
    $scope.GetViewAllData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_Viewdata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtViewGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //================Display History Vital View All Data===============
    $scope.GetHistViewAllData = function (HistToken) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/Get_VitalViewdata",
            data: {
                TokenNo: HistToken
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + dt[i].VitalName + ' </td>';
                TBody = TBody + '<td> ' + dt[i].VitalValue + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("V-" + HistToken).innerHTML = TBody;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //================Display Patient History On Cosultancy===============
    $scope.GetHistAllData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_ViewHistdata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.dtViewHistGetAll = angular.fromJson(Return.data);
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //================Display Patient History On Cosultancy===============
    $scope.GetHistOwnTknClk = function (Token) {
        $scope.selectedtoken = Token;
        $scope.GetHistViewAllData(Token);
        $scope.GetHistDiagnoseViewData(Token);
        $scope.GetHistLabViewData(Token);
        $scope.GetHistMedViewAllData(Token);
        $scope.GetFAViewData(Token);
        $scope.GetHistFolowViewData(Token);
        $scope.GetSessionHistViewData(Token);
        $scope.GetHistActivityViewData(Token);
    };
    //================Diagnose Data Insert=========================
    $scope.savedata = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_Recrd',
            data: {
                TokenNo: $scope.txtTokenNo,
                DisagnoseSName: $scope.txtDiagnoseNam,
                DiagRemarks: $scope.txtRemarks

            }
        }
        $http(displayReq).then(function (Return) {
            $scope.GetDiagnoseViewData($scope.txtTokenNo);
            $scope.txtDiagnoseNam = '';
            $scope.txtRemarks = '';
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Diagnose');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==============Display Diagnose Data By Lookup===================
    $scope.GetDiagCNAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetDiag_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.dtGetCNAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===============Get Diagnose by id=======================
    $scope.GetDiagByid = function (ShortName) {
        $scope.txtDiagnoseNam = ShortName;
    };
    //===========Diagnose Data Delete====================
    $scope.OnDelete = function (ids) {
        var displayReq = {
            method: "POST",
            url: "/Consult/OnDelete",
            data: {
                id: ids
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.txtDiagnoseNam = '';
            $scope.txtRemarks = '';
            //$scope.On_Clear();
            $scope.GetDiagnoseViewData($scope.txtTokenNo);
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Diagnose');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //============Display Diagnose View All Data===================
    $scope.GetDiagnoseViewData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_ViewDiagdata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetDiagnoseviewAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //============Display History Diagnose View All Data===================
    $scope.GetHistDiagnoseViewData = function (TokenHist) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/Get_ViewDiagdata",
            data: {
                TokenNo: TokenHist
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + dt[i].DisagnoseSName + ' </td>';
                TBody = TBody + '<td> ' + dt[i].Remarks + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("D-" + TokenHist).innerHTML = TBody;

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Display Lab Data By Lookup ===================
    $scope.GetLabCNAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetLab_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.dtLbGetCNAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Get Lab data by id=================
    $scope.GetLabByid = function (LabTest) {
        $scope.txtLabTest = LabTest;
    };
    //==============Lab Data Delete============== 
    $scope.OnLabDelete = function (ids) {
        var displayReq = {
            method: "POST",
            url: "/Consult/OnLabDelete",
            data: {
                id: ids
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.txtLabTest = '';
            $scope.txtLabRemarks = '';
            //$scope.On_Clear();
            $scope.GetLabViewData($scope.txtTokenNo);
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Lab Test');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });

    };
    //===================Display Lab View All Data===================
    $scope.GetLabViewData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_ViewLabdata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetLabviewAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===================Display Hist Lab View All Data===================
    $scope.GetHistLabViewData = function (TokenHist) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/Get_ViewLabdata",
            data: {
                TokenNo: TokenHist
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + dt[i].LabTest + ' </td>';
                TBody = TBody + '<td> ' + dt[i].Remarks + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("L-" + TokenHist).innerHTML = TBody;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==================Lab Data Insert==================
    $scope.saveLabdata = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_LabRecrd',
            data: {
                TokenNo: $scope.txtTokenNo,
                LabTest: $scope.txtLabTest,
                LabRemarks: $scope.txtLabRemarks

            }
        }
        $http(displayReq).then(function (Return) {
            $scope.GetLabViewData($scope.txtTokenNo);
            $scope.txtLabTest = '';
            $scope.txtLabRemarks = '';
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Lab Test');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //======Display Treatment or Service View All Data===============
    $scope.GetTrtViewAllData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetServ_Viewdata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtTrtViewGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //======Display Hist Treatment or Service View All Data===============
    $scope.GetHistTrtViewAllData = function (TokenHist) {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetServ_Viewdata",
            data: {
                TokenNo: TokenHist
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtHistTrtViewGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===============Insert Treatment============
    $scope.saveTrtdata = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/AddSer_Recrd',
            data: {
                TokenNo: $scope.txtTokenNo,
                TrtRemarks: $scope.txtRemarks,
                ServiceName: $scope.txtServame,
                Fee: $scope.txtCharges,
            }
        }
        $http(displayReq).then(function (Return) {
            //$scope.On_Clear();
            $scope.txtServame = '';
            $scope.txtCharges = '';
            $scope.txtRemarks = '';
            $scope.GetTrtViewAllData($scope.txtTokenNo);
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Treatment');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==================Treatment or Service Data Delete=============
    $scope.OnTrtDelete = function (ids) {
        var displayReq = {
            method: "POST",
            url: "/Consult/OntrtDelete",
            data: {
                id: ids
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.txtServame = '';
            $scope.txtRemarks = '';
            //$scope.On_Clear();
            $scope.GetTrtViewAllData($scope.txtTokenNo);
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Treatment');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //===============Display Genric Related Data in Medication With API==============
    $scope.GetGenricAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetAPI",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            var response = angular.fromJson(Return.data);
            if (response.Code == 200) {
                $scope.dtGenricGetAll = response.data;
            }
            else {
                $scope.Notification('error', response.Code, response.Msg);
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code GEN0001', Return.data);
        });
    };
    //===============Display Stock Related Data in Medication With API==============
    $scope.GetStockAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetStockAPI",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            //alert(Return.data);
            var response = angular.fromJson(Return.data);
            if (response.Code == 200) {
                $scope.dtStockGetAll = response.data;
            }
            else {
                alert(Return.data);
                $scope.Notification('error', response.Code, response.Msg);
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code GEN0001', Return.data);
        });

    };
    //===============Medication List Button Enable Or Disable Func=============
    $scope.GetEnabl_Disabl = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetEnable_Data",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt[0].IsAllow == 1) {
                $scope.StockList = false;
                $scope.GenericList = true;
            }
            else {
                $scope.StockList = true;
                $scope.GenericList = false;
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code GEN0001', Return.data);
        });
    };
    //==============Get Generic by id in Medication================
    $scope.GetGenricByid = function (GenericName, Potency, PotencyUOM, SubTypeID) {
        $scope.txtGenric = GenericName;
        $scope.txtPotency = Potency + "" + PotencyUOM;
        $scope.txtTypeID = SubTypeID;
    };
    //==============Get Stock by id in Medication================
    $scope.GetStockByid = function (StockNam, PotencyWUom, SubTypeID) {
        $scope.txtGenric = StockNam;
        $scope.txtPotency = PotencyWUom;
        $scope.txtTypeID = SubTypeID;
    };
    //================Insert Medication==============
    $scope.saveMedidata = function () {
        //alert($scope.TxtDosages + '  ' + $scope.TxtDays);
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_Medication',
            data: {
                TokenNo: $scope.txtTokenNo,
                GenericName: $scope.txtGenric + ' ' + $scope.txtPotency,
                TypeID: $scope.txtTypeID,
                SubTypeID: $scope.txtSbTypeID,
                DosageQty: $scope.TxtDosages,
                IsMorning: $scope.ChkMorning,
                IsEvening: $scope.ChkEvening,
                IsNight: $scope.ChkNight,
                NoOfDays: $scope.TxtDays,
                UrduText: $scope.TxtUrdu,
                MediRemarks: $scope.txtRemarks

            }
        }
        $http(displayReq).then(function (Return) {
            $scope.GetMedViewAllData($scope.txtTokenNo);
            $scope.txtGenric = '';
            $scope.txtPotency = '';
            $scope.txtTypeID = '';
            $scope.txtSbTypeID = '';
            $scope.TxtDosages = '';
            $scope.ChkMorning = '';
            $scope.ChkEvening = '';
            $scope.ChkNight = '';
            $scope.ChkCurrent = '';
            $scope.ChkContinuous = '';
            $scope.TxtDays = '';
            $scope.TxtUrdu = '';
            $scope.txtRemarks = '';
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Medication');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //============Display Medication View All Data==============
    $scope.GetMedViewAllData = function (TokenNo) {
        var displayReq = {
            method: "POST",
            url: "/Consult/GetMed_Viewdata",
            data: {
                TokenNo: TokenNo
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetMediviewAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //============Display History Medication View All Data==============
    $scope.GetHistMedViewAllData = function (TokenNoHist) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/GetMed_Viewdata",
            data: {
                TokenNo: TokenNoHist
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + dt[i].GenericName + ' </td>';
                TBody = TBody + '<td> ' + dt[i].UrduText + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("M-" + TokenNoHist).innerHTML = TBody;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=============For Delete Medication==================
    $scope.OnMediDelete = function (ids) {
        var displayReq = {
            method: "POST",
            url: "/Consult/OnMediDelete",
            data: {
                id: ids
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.GetMedViewAllData($scope.txtTokenNo);
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Medication');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });

    };
    //========Display Medication By token  View API All Data=================
    $scope.GetPharmaAllData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_PharmacyMedTkn",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtPharmaTokenAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //===============For Follow Up Delete================== 
    $scope.OnFolowDelete = function (ids) {
        var displayReq = {
            method: "POST",
            url: "/Consult/OnFolowDelete",
            data: {
                id: ids
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.txtFolowDate = '';
            $scope.txtFolowRemarks = '';
            //$scope.On_Clear();
            $scope.GetFolowViewData($scope.txtTokenNo);
            if (Return.data == "Delete") {
                $scope.Notification('success', 'Operation Completed', 'Delete Follow Up');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });

    };
    //====================Display Follow View All Data===============
    $scope.GetFolowViewData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_ViewFolowdata",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {

            $scope.dtGetfolowviewAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //====================Display History Follow View All Data===============
    $scope.GetHistFolowViewData = function (TokenHist) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/Get_ViewFolowdata",
            data: {
                TokenNo: TokenHist
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + new Date(dt[i].FollowupDate) + ' </td>';
                TBody = TBody + '<td> ' + dt[i].Remarks + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("F-" + TokenHist).innerHTML = TBody;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //Display First Aid View All Data
    $scope.GetFAViewData = function (Token) {
        var displayReq = {
            method: "POST",
            url: "/PatHist/Get_ViewFAData",
            data: {
                TokenNo: Token
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            var TBody = "";
            for (var i = 0; i < dt.length; i++) {
                TBody = TBody + '<tr> ';
                TBody = TBody + '<td> ' + dt[i].FAService + ' </td>';
                TBody = TBody + '<td> ' + dt[i].FACharges + ' </td>';
                TBody = TBody + '</tr> ';
            }
            document.getElementById("FirstAid-" + Token).innerHTML = TBody;
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=================Follow Up Data Insert=================
    $scope.savefollowdata = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_FolowRecrd',
            data: {
                TokenNo: $scope.txtTokenNo,
                FollowupDate: $scope.txtFolowDate,
                Remarks: $scope.txtFolowRemarks
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.GetFolowViewData($scope.txtTokenNo);
            $scope.txtFolowDate = '';
            $scope.txtFolowRemarks = '';
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Follow up');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            //$scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };
    //==============Calculate Fee=============
    //$scope.CalculateFee = function () {

    //    //var Fee = $scope.txtBalance;
    //    var Paid = $scope.txtPaid;
    //    var totalcharges = $scope.txtCharges;
    //    $scope.txtBalance = totalcharges-Paid;
    //};
    //==============Display Patient Token All Data===================
    $scope.GetAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_data",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.On_Clear();
            $scope.dtGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Display Pending Patient Token All Data===================
    $scope.GetAllPendData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_Penddata",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.On_Clear();
            $scope.dtPendGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //============Get Pending Patient Data By Token==================
    $scope.GetPenddDataByID = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_Penddatabyid",
            data: {
                TokenNo: ID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtTokenNo = dt[0].TokenNo;
                $scope.txtTokenDate = dt[0].TokenDate;
                $scope.txtRegNo = dt[0].RegNo;
                $scope.txtGender = dt[0].Gender;
                $scope.txtPatAge = dt[0].Age;
                $scope.txtPatCNIC = dt[0].CNIC;
                $scope.txtPatName = dt[0].FullName;
                $scope.txtDocName = dt[0].DoctorName;
                $scope.GetSessionViewData(dt[0].TokenNo);
                $scope.GetSessionActData(dt[0].TokenNo);
                $scope.CosulDiag = false;
                $scope.GetViewAllData(dt[0].TokenNo);
                $scope.GetDiagnoseViewData(dt[0].TokenNo);
                $scope.GetLabViewData(dt[0].TokenNo);
                $scope.GetFolowViewData(dt[0].TokenNo);
                $scope.GetMedViewAllData(dt[0].TokenNo);
                $scope.GetTrtViewAllData(dt[0].TokenNo);
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
    //==========Display All Service Name Or Treatement==============
    $scope.GetSerAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_Servicedata",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.dtSerGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=======Display Morning Evening night Not In Use============ 
    //$scope.GetMEN = function () {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/Consult/Get_ShiftMEN",
    //        data: {}
    //    }
    //    $http(displayReq).then(function (Return) {

    //        $scope.txtFreq = '';

    //        $scope.dtShifts = angular.fromJson(Return.data);

    //    }, function myError(Return) {
    //        $scope.Notification('error', 'Error Code LC0001', Return.data);
    //    });
    //};
    //=========Display Medicine Type Related Data================= 
    $scope.GetTypeAllData = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_TypeMed",
            data: {}
        }
        $http(displayReq).then(function (Return) {
            $scope.txtTypeID = '';
            $scope.txtSbTypeID = '';
            $scope.dttypeGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==============Get Medicine Type Display by id===============
    $scope.GetTypeByid = function (TypeID) {
        $scope.txtTypeID = TypeID;
    };
    //============Display Medicine Sub Type Related Data=============== 
    $scope.GetSbTypAllData = function (id) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_SubTypMed",
            data: {
                SubTypeID: id
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.dtSbtypGetAll = angular.fromJson(Return.data);

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //============Get Medicine Sub Type Related Data by id=================
    $scope.GetSbTypByid = function (SubTypeID) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_EnableText",
            data: {
                SubTypeID: SubTypeID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                var SubtypeID = dt[0].FirstType;
                $scope.txtSbTypeID = dt[0].SubTypeID;
                $scope.SubTypeUrdu = dt[0].UrduText;
                if (SubtypeID == 1) {
                    $scope.Dosage = true;
                    $scope.DosageLbl = true;
                    $scope.DaysLbl = false;
                    $scope.DaysInp = false;
                    $scope.MorningH = false;
                    $scope.EveningH = false;
                    $scope.NightH = false;
                    $scope.FrequencyH = false;
                    $scope.GenerateUrdu();
                }
                else if (SubtypeID == 0) {
                    $scope.Dosage = false;
                    $scope.DosageLbl = false;
                    $scope.DaysLbl = false;
                    $scope.DaysInp = false;
                    $scope.MorningH = false;
                    $scope.EveningH = false;
                    $scope.NightH = false;
                    $scope.FrequencyH = false;
                    $scope.GenerateUrdu();
                }
                else {
                }
                if ($scope.ChkCurrent == true) {
                    if (SubtypeID == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = true;
                        $scope.EveningH = true;
                        $scope.NightH = true;
                        $scope.FrequencyH = true;
                        $scope.GenerateUrdu();
                    }
                    else if (SubTypeID == 0) {
                        $scope.Dosage = false;
                        $scope.DosageLbl = false;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = true;
                        $scope.EveningH = true;
                        $scope.NightH = true;
                        $scope.FrequencyH = true;
                        $scope.GenerateUrdu();
                    }
                    else {
                    }
                }
                else {
                    //alert('Nothing Can Be Find In Current');
                }
                if ($scope.ChkContinuous == true) {
                    if (SubtypeID == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = true;
                        $scope.GenerateUrdu();
                    }
                    else if (SubtypeID == 0) {
                        $scope.Dosage = false;
                        $scope.DosageLbl = false;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = true;
                        $scope.GenerateUrdu();
                    }
                    else {
                    }
                }
                else {
                    //alert('Nothing Can Be Find In Continuous');
                }
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //=====================After Enter Days then its count days In Urdu text=================
    $scope.UrduDaysCounting = function (dosageid) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_DosageID",
            data:
            {
                urducnt: dosageid
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.TxtUrduDays = dt[0].UrduText;
                $scope.GenerateUrdu();
                //$scope.TxtDays = dt[0].NoOfDays;
            }
            else {
                $scope.TxtUrduDays = '';
                //$scope.TxtDays = 0;
            }


        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    }
    //=====================After Enter Days then its count days In Urdu text=================
    $scope.UrduCounting = function (dosageid) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_DosageID",
            data:
            {
                urducnt: dosageid
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.TxtUrduQty = dt[0].UrduText;
                $scope.GenerateUrdu();
                //$scope.TxtDosages = dt[0].DosageQty;
            }
            else {
                $scope.TxtUrduQty = '';
                //$scope.TxtDosages = 0;
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });

    }
    //===============Generate URDU================
    $scope.GenerateUrdu = function () {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_EnableUrduText",
            data: {
                SubTypeID: $scope.txtSbTypeID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                var Morning, Evening, Night, Current, Continuous;
                var One, Two, Three, Fourth;
                One = dt[0].NormalType;
                Two = dt[0].SecoundType;
                Three = dt[0].ThirdType;
                Fourth = dt[0].FourthType;
                if ($scope.ChkMorning == true) {
                    Morning = 'صبح';
                }
                else {
                    Morning = '';
                }
                if ($scope.ChkEvening == true) {
                    Evening = 'دوپہر';
                }
                else {
                    Evening = '';
                }
                if ($scope.ChkNight == true) {
                    Night = 'شام';
                }
                else {
                    Night = '';
                }
                if ($scope.ChkCurrent == true) {
                    Current = 'ابھی';
                }
                else {
                    Current = '';
                }
                if ($scope.ChkContinuous == true) {
                    Continuous = 'مستقل';
                }
                else {
                    Continuous = '';
                }
                if ($scope.ChkCurrent == false && $scope.ChkContinuous == false && $scope.txtGenric != '') {
                    if (One == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = false;
                        $scope.DaysInp = false;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = false;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + $scope.TxtUrduDays + '  ' + ' دن تک لگائیں ';
                    }
                    else if (Two == 1) {
                        $scope.Dosage = false;
                        $scope.DosageLbl = false;
                        $scope.DaysLbl = false;
                        $scope.DaysInp = false;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = false;
                        $scope.TxtUrdu = '  ' + $scope.TxtUrduQty + '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + $scope.TxtUrduDays + '  ' + ' دن تک استعمال کریں ';
                    }
                    //}
                    else if (Three == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = false;
                        $scope.DaysInp = false;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = false;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + $scope.TxtUrduDays + '  ' + ' دن تک استعمال کریں ';
                    }
                    else {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = false;
                        $scope.DaysInp = false;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = false;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + $scope.TxtUrduDays + '  ' + 'دن تک جاری رکھیں';
                    }
                }
                else {
                    //Nothing
                }
                if ($scope.ChkCurrent == true) {
                    if (One == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = true;
                        $scope.EveningH = true;
                        $scope.NightH = true;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Current + '  ' + 'لگائیں';
                    }
                    else if (Two == 1) {
                        $scope.Dosage = false;
                        $scope.DosageLbl = false;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = true;
                        $scope.EveningH = true;
                        $scope.NightH = true;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.TxtUrduQty + '  ' + $scope.SubTypeUrdu + '  ' + Current + '  ' + 'استعمال کریں';
                    }
                    else if (Three == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = true;
                        $scope.EveningH = true;
                        $scope.NightH = true;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Current + '  ' + 'استعمال کریں';
                    }
                    else {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = true;
                        $scope.EveningH = true;
                        $scope.NightH = true;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Current + '  ' + 'لیں';
                    }
                }
                else {
                    //alert('nothing find in urdu current');
                }
                if ($scope.ChkContinuous == true) {
                    if (One == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + Continuous + '  ' + 'لگائیں';
                    }
                    else if (Two == 1) {
                        $scope.Dosage = false;
                        $scope.DosageLbl = false;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.TxtUrduQty + '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + Continuous + '  ' + 'استعمال کریں';
                    }
                    else if (Three == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = false;
                        $scope.EveningH = false;
                        $scope.NightH = false;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + Continuous + '  ' + 'استعمال کریں';
                    }
                    else if (Fourth == 1) {
                        $scope.Dosage = true;
                        $scope.DosageLbl = true;
                        $scope.DaysLbl = true;
                        $scope.DaysInp = true;
                        $scope.MorningH = true;
                        $scope.EveningH = true;
                        $scope.NightH = true;
                        $scope.FrequencyH = true;
                        $scope.TxtUrdu = '  ' + $scope.SubTypeUrdu + '  ' + Morning + '  ' + Evening + '  ' + Night + '  ' + Continuous + '  ' + 'لیں';
                    }
                }
                else {
                    //alert('nothing find in urdu continous');
                }
            }
        });
    };
    //============Display Service Name By Lookup===============
    $scope.GetSerDataByID = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_Servdatabyid",
            data: {
                id: ID
            }
        }
        $http(displayReq).then(function (Return) {
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtServame = dt[0].ServiceName;
                $scope.txtCharges = dt[0].Charges;
                $scope.CUSaveBtn = false;
            }
            else {
                $scope.CUSaveBtn = false;
                $scope.txtServiceName = '';
                $scope.txtCharges = '';
            }

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    ////============Get Patient Data By Token==================
    //$scope.GetDataByID = function (ID) {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/Consult/Get_databyid",
    //        data: {
    //            TokenNo: ID
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        var dt = angular.fromJson(Return.data);
    //        if (dt.length > 0) {
    //            $scope.txtTokenNo = dt[0].TokenNo;
    //            $scope.txtTokenDate = dt[0].TokenDate;
    //            $scope.txtRegNo = dt[0].RegNo;
    //            $scope.txtGender = dt[0].Gender;
    //            $scope.txtPatAge = dt[0].Age;
    //            $scope.txtPatCNIC = dt[0].CNIC;
    //            $scope.txtPatName = dt[0].FullName;
    //            $scope.txtDocName = dt[0].DoctorName;

    //            $scope.CosulDiag = false;
    //            $scope.GetViewAllData(dt[0].TokenNo);
    //            $scope.GetDiagnoseViewData(dt[0].TokenNo);
    //            $scope.GetLabViewData(dt[0].TokenNo);
    //            $scope.GetFolowViewData(dt[0].TokenNo);
    //            $scope.GetMedViewAllData(dt[0].TokenNo);
    //            $scope.GetTrtViewAllData(dt[0].TokenNo);
    //            $scope.CUSaveBtn = false;
    //            //$scope.CUUpdateBtn = True;
    //        }
    //        else {
    //            $scope.CUSaveBtn = false;
    //            //$scope.CUUpdateBtn = false;

    //            $scope.txtTokenNo = '';
    //            $scope.txtTokenDate = '';
    //            $scope.txtRegNo = '';
    //            $scope.txtGender = '';
    //            $scope.txtPatAge = '';
    //            $scope.txtPatCNIC = '';
    //            $scope.txtPatName = '';
    //            $scope.txtDocName = '';
    //        }
    //        $scope.GetHistAllData($scope.txtTokenNo);
    //    }, function myError(Return) {
    //        $scope.Notification('error', 'Error Code LC0001', Return.data);
    //    });
    //};
    //============Get Patient Data By Token==================
    $scope.GetDataByID = function (ID) {
        var displayReq = {
            method: "POST",
            url: "/Consult/Get_databyid",
            data: {
                TokenNo: ID
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.On_Clear();
            $scope.dttblGetAll = angular.fromJson(Return.data);
            var dt = angular.fromJson(Return.data);
            if (dt.length > 0) {
                $scope.txtTokenNo = dt[0].TokenNo;
                $scope.CosulDiag = false;
                $scope.GetViewAllData(dt[0].TokenNo);
                $scope.GetDiagnoseViewData(dt[0].TokenNo);
                $scope.GetLabViewData(dt[0].TokenNo);
                $scope.GetFolowViewData(dt[0].TokenNo);
                $scope.GetMedViewAllData(dt[0].TokenNo);
                $scope.GetTrtViewAllData(dt[0].TokenNo);
                $scope.GetSessionViewData(dt[0].TokenNo);
                $scope.GetSessionActData(dt[0].TokenNo);
                $scope.GetHistAllData(dt[0].TokenNo);
                $scope.CUSaveBtn = false;
                $scope.CUUpdateBtn = true;
            }
            else {
                $scope.CUSaveBtn = false;
                //$scope.CUUpdateBtn = false;
                $scope.txtTokenNo = '';
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };
    //==================Next Token===================
    $scope.Nxt_Token = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Add_Nxt_tkn_Recrd',
            data: {
                TokenNo: $scope.txtTokenNo
            }
        }
        $http(displayReq).then(function (Return) {
            $scope.On_Clear();
            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Token In Queue');
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };

    //==================Check Doctor Existanc===================
    $scope.CheckDoctor = function () {
        var displayReq = {
            method: 'POST',
            url: '/Consult/Check',
            data: {}
        }
        $http(displayReq).then(function (Return) {
            if (Return.data == "Done") {
                //alert("Done");
                //$scope.Notification('success', 'Operation Completed', 'Insert Token In Queue');
                $scope.NextTkn = false;
            }
            else {
                $scope.NextTkn = true;
            }
        }, function myError(Return) {
            $scope.On_Clear();
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
        });
    };

    //============For Update
    //$scope.On_Update = function () {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/FirstAddController/update_record",
    //        data: {
    //            TokenNo:$scope.txtTokenNo,
    //            TokenDate: $scope.txtTokenDate,
    //            PatName:$scope.txtPatName,
    //            Balance:$scope.txtBalance,
    //            TotalFee:$scope.txtTotalFee,
    //            PaidFee:$scope.txtPaidFee,
    //            RefundFee:$scope.txtFeeRefund,
    //            Remarks:$scope.txtRemarks,
    //            RefundApproval: $scope.txtRefundApproval,
    //            RefundType: $scope.txtPatRefundType
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        $scope.On_Clear();
    //        if (Return.data == "Updated") {
    //            $scope.Notification('success', 'Operation Completed', 'Update Patient Refund');
    //        }
    //        else {
    //            $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
    //        }
    //    }, function myError(Return) {
    //            $scope.On_Clear();
    //            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
    //        });
    //};

    //=============
    $scope.On_Clear = function () {
        $scope.txtTokenNo = '';
        $scope.txtGender = '';
        $scope.txtPatAge = '';
        $scope.txtTokenDate = '';
        $scope.txtRegNo = '';
        $scope.txtPatCNIC = '';
        $scope.txtPatName = '';
        $scope.txtDocName = '';
        $scope.txtServame = '';
        $scope.txtCharges = '';
        $scope.txtMode = '';
        $scope.txtRemarks = '';
        $scope.txtPaid = '';
        $scope.txtBalance = '';
        $scope.txtGenric = '';
        $scope.txtPotency = '';
        $scope.txtTypeID = '';
        $scope.txtSbTypeID = '';
        $scope.TxtDosages = '';
        $scope.ChkMorning = '';
        $scope.ChkEvening = '';
        $scope.ChkNight = '';
        $scope.TxtDays = '';
        $scope.TxtUrdu = '';
        $scope.ChkCurrent = '';
        $scope.ChkContinuous = '';
        $scope.dtViewGetAll = '';
        $scope.dtTrtViewGetAll = '';
        $scope.txtFARemarks = '';
        $scope.dtGetDiagnoseviewAll = '';
        $scope.dtGetLabviewAll = '';
        $scope.dtGetfolowviewAll = '';
        $scope.dtGetMediviewAll = '';
        //History Clear Data
        $scope.dttblGetAll = '';
        $scope.dtViewHistGetAll = '';
        $scope.dtHistViewGetAll = '';
        $scope.dtHistGetDiagnoseviewAll = '';
        $scope.dtHistGetLabviewAll = '';
        $scope.dtGetSessionviewAll = '';
        $scope.dtGetSessionActAll = '';
        $scope.dtHistTrtViewGetAll = '';
        $scope.dtHistGetMediviewAll = '';
        $scope.dtHistGetfolowviewAll = '';
        //$scope.CosulDiag = true;
        //$scope.CosulDiag1 = true;

        $scope.OnLoad();
        $scope.CUSaveBtn = false;
        $scope.CUUpdateBtn = true;
    };
    $scope.OnLoad = function () {
        //$scope.GetStockAllData();
        $scope.CUSaveBtn = false;
        $scope.CUUpdateBtn = true;
        $scope.Dosage = true;
        $scope.DosageLbl = true;
        $scope.CosulDiag = true;
        $scope.CheckDoctor();
        $scope.txtNoOfSession = 0;
        //$scope.GetMEN();
        $scope.GetEnabl_Disabl();
    };
    //===============THE END===================
    $scope.OnLoad();
});