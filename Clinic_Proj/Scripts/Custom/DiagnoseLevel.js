function Notification(Type, Heading, Test) {
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
}
function savedata() {
    var NodeID = document.getElementById("TxtNodeID").value;
    var ParentID = document.getElementById("TxtParentID").value;
    var InActive = document.getElementById("TxtInActive").value;
    var ICDCode = document.getElementById("TxtICDCode").value;
    var ICDName = document.getElementById("TxtICDName").value;
    $.ajax({
        method: "POST",
        url: "/Diagnoses/Add_NodeRecord/",
        data: {
            NodeID: NodeID,
            ParentID: ParentID,
            InActive: InActive,
            ICDCode: ICDCode,
            ICDName: ICDName
        },
        success: function (message) {
            if (message == "Inserted") {
                GetParentList();
                Notification("success", "Operation Completed", "Node Updated");
                //Node_Header_Get();
                OnClear();
            }
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.data);
        }
    });
}
function saveChdata() {
    var NodeID = document.getElementById("TxtChNodeID").value;
    var ParentID = document.getElementById("TxtChildID").value;
    var InActive = document.getElementById("TxtChInActive").value;
    var ICDCode = document.getElementById("TxtICDChCode").value;
    var ICDName = document.getElementById("TxtChICDName").value;
    $.ajax({
        method: "POST",
        url: "/Diagnoses/Add_NodeRecord/",
        data: {
            NodeID: NodeID,
            ParentID: ParentID,
            InActive: InActive,
            ICDCode: ICDCode,
            ICDName: ICDName
        },
        success: function (message) {
            if (message == "Inserted") {
                GetParentList();
                Notification("success", "Operation Completed", "Node Added");
                //Node_Header_Get();
                OnClear();
            }
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.data);
        }
    });
}
function GetParentList() {
    $.ajax({
        method: "GET",
        url: "/Diagnoses/Get_ParentList/",
        data: {},
        success: function (message) {
            var dt = JSON.parse(message);
            
            var html_Body = "<ul>";
            for (var i = 0; i < dt.length; i++) {
                html_Body += "<li id=\"" + dt[i].NodeID + "\"><button class=\"btn btn-link\" id=\"btn_" + dt[i].NodeID + "\" onclick=\"Node_Get_Child(" + dt[i].NodeID + " , '" + dt[i].NodeName + "')\" > " + dt[i].NodeName + "</button></li>";
            }
            html_Body += "</ul>";
            document.getElementById("AllNodes").innerHTML = html_Body;
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.data);
        }
    });
}
function Node_Get_Child(id, Name) {
    Node_Detail_Get(id);
    $.ajax({
        method: "POST",
        url: "/Diagnoses/Get_ChildList/",
        data: {
            ParentID: id
        },
        success: function (message) {
            document.getElementById("DelBtn").disabled = false;
            document.getElementById("SaveBtn").disabled = false;
            var dt = JSON.parse(message);
            var html_Body = "<button class=\"btn btn-link\" id=\"btn_" + id + "\" onclick=\"Node_Get_Child(" + id + ",'" + Name + "')\" >" + Name + "</button> " + "<ul>";

            html_Body += "<ul>";
            for (var i = 0; i < dt.length; i++) {
                html_Body += " <li id=\"" + dt[i].NodeID + "\"><button class=\"btn btn-link\" id=\"btn_" + dt[i].NodeID + "\" onclick=\"Node_Get_Child(" + dt[i].NodeID + ", '" + dt[i].NodeName + "')\" > " + dt[i].NodeName + "</button></li>";
            }
            html_Body += "</ul>";
            document.getElementById(id).innerHTML = html_Body;
            html_Body += "</ul>";
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.responseText);
        }
    });
}
//=============================Start On Load======================
//function GetOnLoadParentList() {
//    $.ajax({
//        method: "GET",
//        url: "/Diagnoses/Get_ParentList/",
//        data: {},
//        success: function (message) {
//            var dt = JSON.parse(message);

//            var html_Body = "<ul>";
//            for (var i = 0; i < dt.length; i++) {
//                html_Body += "<li id=\"" + dt[i].NodeID + "\"><button class=\"btn btn-link\" id=\"btn_" + dt[i].NodeID + "\" onclick=\"Node_Get_OnLoad_Child(" + dt[i].NodeID + " , '" + dt[i].NodeName + "')\" > " + dt[i].NodeName + "</button></li>";
//                Node_Get_OnLoad_Child(dt[i].NodeID, dt[i].NodeName);
//            }
//            html_Body += "</ul>";
//            document.getElementById("AllNodes").innerHTML = html_Body;
//        },
//        error: function (error) {
//            Notification("error", "Operation Failed", error.data);
//        }
//    });
//}
//function Node_Get_OnLoad_Child(id, Name) {
//    Node_Detail_Get(id);
//    $.ajax({
//        method: "POST",
//        url: "/Diagnoses/Get_ChildList/",
//        data: {
//            ParentID: id
//        },
//        success: function (message) {
//            document.getElementById("DelBtn").disabled = false;
//            document.getElementById("SaveBtn").disabled = false;
//            var dt = JSON.parse(message);
//            var html_Body = "<button class=\"btn btn-link\" id=\"btn_" + id + "\" onclick=\"Node_Get_OnLoad_Child(" + id + ",'" + Name + "')\" >" + Name + "</button> " + "<ul>";

//            html_Body += "<ul>";
//            for (var i = 0; i < dt.length; i++) {
//                html_Body += " <li id=\"" + dt[i].NodeID + "\"><button class=\"btn btn-link\" id=\"btn_" + dt[i].NodeID + "\" onclick=\"Node_Get_OnLoad_Child(" + dt[i].NodeID + ", '" + dt[i].NodeName + "')\" > " + dt[i].NodeName + "</button></li>";
//                Node_Get_OnLoad_Child(dt[i].NodeID, dt[i].NodeName);
//            }
//            html_Body += "</ul>";
//            document.getElementById(id).innerHTML = html_Body;
//            html_Body += "</ul>";
//        },
//        error: function (error) {
//            Notification("error", "Operation Failed", error.responseText);
//        }
//    });
//}
//=============================End On Load========================
function Node_Detail_Get(RowID) {
    $.ajax({
        method: "POST",
        url: "/Diagnoses/Get_Diseasedatabyid/",
        data: {
            NodeID: RowID
        },
        success: function (message) {
            var dt = JSON.parse(message);
            if (dt.length > 0) {
                document.getElementById("TxtNodeID").value = dt[0].NodeID;
                document.getElementById("TxtICDCode").value = dt[0].NodeTitle;
                document.getElementById("TxtICDName").value = dt[0].NodeDescription;
                document.getElementById("TxtInActive").value = dt[0].InActive;
                Parent_Detail_Get(dt[0].ParentID);
                Child_Detail_Get(dt[0].NodeID,dt[0].NodeDescription);
            }
            else {
                document.getElementById("TxtInActive") = 'true';
                document.getElementById("TxtICDCode") = '';
                document.getElementById("TxtICDName") = '';
            }
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.data);
        }
    });
}

function Parent_Detail_Get(RowID) {
    $.ajax({
        method: "POST",
        url: "/Diagnoses/Get_Diseasedatabyid/",
        data: {
            NodeID: RowID
        },
        success: function (message) {
            var dt = JSON.parse(message);
            if (dt.length > 0) {
                document.getElementById("TxtParentID").value = dt[0].NodeID;
                document.getElementById("TxtParentName").value = dt[0].NodeDescription;
            }
            else {
                document.getElementById("TxtParentID").value = 0;
                document.getElementById("TxtParentName") = '';
            }
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.data);
        }
    });
}
function Child_Detail_Get(RowID,ChId) {
        document.getElementById("TxtChildID").value = RowID;
        document.getElementById("TxtChParentName").value = ChId;
}
function GetNodeID() {
    $.ajax({
        method: "GET",
        url: "/Diagnoses/Get_NodeID/",
        data: {},
        success: function (message) {
            var dt = JSON.parse(message)
            document.getElementById("TxtChNodeID").value = dt[0].NodeID;
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.responseText);
        }
    });
}

function Node_Delete() {
    var NodeLevel = document.getElementById("TxtNodeID").value;
    $.ajax({
        method: "POST",
        url: "/Diagnoses/OnDelete_Node/",
        data: {
            NodeID: NodeLevel
        },
        success: function (message) {
            if (message == "Delete") {
                Notification("success", "Operation Completed", "Node Deleted");
                OnClear();
            }
        },
        error: function (error) {
            Notification("error", "Operation Failed", error.data);
        }
    });
}
function OnClear() {
    GetParentList();
    GetNodeID();
    document.getElementById("TxtParentID").value = 0;
    document.getElementById("TxtNodeID").value = 0;
    document.getElementById("TxtInActive").value = 'true';
    document.getElementById("TxtICDCode").value = '';
    document.getElementById("TxtParentName").value = '';
    document.getElementById("DelBtn").disabled = true;
    document.getElementById("SaveBtn").disabled = true;
    document.getElementById("TxtICDName").value = '';
    document.getElementById("TxtChildID").value = 0;
    document.getElementById("TxtChInActive").value = 'true';
    document.getElementById("TxtICDChCode").value = '';
    document.getElementById("TxtChParentName").value = '';
    document.getElementById("TxtChICDName").value = '';
}
function onLoad() {
    GetParentList();
    GetNodeID();
    document.getElementById("TxtParentID").value=0;
    document.getElementById("TxtNodeID").value=0;
    document.getElementById("TxtInActive").value ='true';
    document.getElementById("TxtICDCode").value = '';
    document.getElementById("TxtParentName").value = '';
    document.getElementById("DelBtn").disabled = true;
    document.getElementById("SaveBtn").disabled = true;
    document.getElementById("TxtICDName").value = '';
    document.getElementById("TxtChildID").value = 0;
    document.getElementById("TxtChInActive").value ='true';
    document.getElementById("TxtICDChCode").value = '';
    document.getElementById("TxtChParentName").value = '';
    document.getElementById("TxtChICDName").value = '';
}
onLoad();
//var RegistrationForm = angular.module("LevelForm", []);
//RegistrationForm.controller("Home", function ($scope, $http) {

//    $scope.Notification = function (Type, Heading, Test) {
//        //info, warning, success, error
//        $.toast({
//            heading: Heading,
//            text: Test,
//            position: 'top-right',
//            loaderBg: '#ff6849',
//            icon: Type,
//            hideAfter: 3500,
//            stack: 6
//        });
//    };
//    //===================Auto Get Node ID=============
//    $scope.GetNodeID = function () {
//        var displayReq = {
//            method: "POST",
//            url: "/Diagnoses/Get_NodeID",
//            data: {
//            }
//        }
//        $http(displayReq).then(function (Return) {
//            var dt = angular.fromJson(Return.data);
//            if (dt.length > 0) {
//                $scope.TxtNodeID = dt[0].NodeID;
//            }
//        }, function myError(Return) {
//            $scope.Notification('error', 'Error Code LC0001', Return.data);
//        });
//    };
    //================Insert Diagnose Level===================================
    //$scope.savedata = function () {
    //    var displayReq = {
    //        method: 'POST',
    //        url: '/Diagnoses/Add_NodeRecord',
    //        data: {
    //            NodeID: $scope.TxtNodeID,
    //            ParentID: $scope.TxtParentID,
    //            InActive: $scope.TxtInActive,
    //            ICDCode: $scope.TxtICDCode,
    //            ICDName: $scope.TxtICDName,
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        if (Return.data == "Inserted") {
    //            $scope.OnLoad(); 
    //            $scope.Notification('success', 'Operation Completed', 'Insert Node');
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

    //header===============

    //===================Auto Get Node ID=============
    //$scope.GetParentList = function () {
    //    var displayReq = {
    //        method: "POST",
    //        url: "/Diagnoses/Get_ParentList/",
    //        data: {
    //        }
    //    }
    //    $http(displayReq).then(function (Return) {
    //        var dt = angular.fromJson(Return.data);
    //        var html_Body = "<ul>";
    //        for (var i = 0; i < dt.length; i++) {
    //            html_Body += "<li id=\"" + dt[i].NodeID + "\"><button class=\"btn btn-link\" id=\"btn_" + dt[i].NodeID + "\" onclick=\"Node_Get_Child(" + dt[i].NodeID + ")\" > " + dt[i].NodeName + "</button></li>";
    //        }
    //        html_Body += "</ul>";
    //        document.getElementById("AllNodes").innerHTML = html_Body;
    //    }, function myError(Return) {
    //        $scope.Notification('error', 'Error Code LC0001', Return.data);
    //    });
    //};
    //$scope.Node_Header_Get = function () {
    //    var displayReq = ({
    //        method: "GET",
    //        url: "/Diagnoses/Get_ParentList/",
    //        data: {},
    //        success: function (message) {
    //            var dt = JSON.parse(message);
    //            var html_Body = "<ul>";
    //            for (var i = 0; i < dt.length; i++) {
    //                html_Body += "<li id=\"" + dt[i].NodeID + "\"><button class=\"btn btn-link\" id=\"btn_" + dt[i].NodeID + "\" onclick=\"Node_Detail_Get(" + dt[i].NodeID + ")\" > " + dt[i].NodeName + "</button></li>";
    //            }
    //            html_Body += "</ul>";
    //            document.getElementById("AllNodes").innerHTML = html_Body;
    //        },
    //        error: function (error) {
    //            Notification("error", "Operation Failed", error.data);
    //        }
    //    });
    //};


    //$scope.Node_Detail_Get = function (RowID) {
    //    var displayReq = ({
    //        method: "POST",
    //        url: "/Diagnoses/LERWF_WorkFlow_Get_NodeDetail/",
    //        data: {
    //            RowID: RowID
    //        },
    //        success: function (message) {
    //            var dt = JSON.parse(message);
    //            if (dt.length > 0) {
    //                //document.getElementById("txtHNodeLvl").value = dt[0].HNodeLevel;
    //                //document.getElementById("txtNodeLvl").value = dt[0].NodeLevel;
    //                //document.getElementById("txtNodeTitle").value = dt[0].Title;
    //                //document.getElementById("txtType").value = dt[0].Recuritment_Type;
    //                ////GetType_Value(); 
    //                //document.getElementById("txtValue").value = dt[0].Recuritment_Description;
    //                Node_Get_Child(dt[0].Title, dt[0].NodeLevel, dt[0].HNodeLevel);
    //            }
    //            else {
    //                //document.getElementById("txtHNodeLvl").value = 0;
    //                //document.getElementById("txtNodeLvl").value = 0;
    //                //document.getElementById("txtNodeTitle").value = "";
    //                //document.getElementById("txtType").value = "";
    //                //document.getElementById("txtValue").value = "";
    //            }
    //        },
    //        error: function (error) {
    //            Notification("error", "Operation Failed", error.data);
    //        }
    //    });
    //}; 



    //$scope.Node_Get_Child = function (id) {
    //    alert("" + id);
    //        var displayReq = {
    //            method: "POST",
    //            url: "/Diagnoses/Get_ChildList/",
    //            data: {
    //                ParentID: id 
    //            }
    //        }
    //        $http(displayReq).then(function (Return) {
    //            var dt = angular.fromJson(Return.data);
    //            var html_Body = "<button class=\"btn btn-link\" id=\"btn_" + NodeID + "\" onclick=\"Node_Detail_Get(" + NodeID + ")\" > " + NodeName + "</button> " + "<ul>";
    //            for (var i = 0; i < dt.length; i++) {
    //                html_Body += " <li id=\"" + dt[i].NodeID + "\"><button class=\"btn btn-link\" id=\"btn_" + dt[i].NodeID + "\" onclick=\"Node_Get_Child(" + dt[i].NodeID + ")\" > " + dt[i].NodeName + "</button></li>";
    //            }
    //            html_Body += "</ul>";
    //            document.getElementById(NodeLevel).innerHTML = html_Body;
    //        }, function myError(Return) {
    //            $scope.Notification('error', 'Error Code LC0001', Return.data);
    //        });
    //    };



//    $scope.OnLoad = function () {
//        $scope.GetNodeID();
//        //$scope.GetParentList();
//        $scope.TxtParentID=0;
//        $scope.TxtInActive ='true';
//        $scope.TxtICDCode = '';
//        $scope.TxtParentName = '';
//        $scope.TxtICDName = '';
//    };


//    $scope.OnLoad();


//});
