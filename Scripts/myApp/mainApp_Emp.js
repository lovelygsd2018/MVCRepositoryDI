//mainAppp_Emp.js

$(document).ready(function () {
    var paramAjax = { url: '', type: '' };  //ajax parameter for url, type
    var paramDt = {EmployeeID:'',EmployeeName:'',Salary:'', DepartmentID:''};                       //update & save data

    //hide subform(add,edit,del) // Removing row color from main list table
    $("#Container_subEmp_Emp_2").hide();
    $("#divTblEmpList_Emp_2 tr").removeClass("rowColor2");

    /*** AddNew Process ***/
    //AddNew button from Index.cshtm => open subform
    $("#btnAddNew_Emp_2").click(function () {
        //Setup Ajax parameter
        paramAjax.url = '/Emp/prvShowAddfrm';
        paramAjax.type = 'GET';
        fnc_openSubform(paramAjax);          //Open 'Add Subform' 
        paramAjax = { url: '', type: '' };
    });
    //AddNew Subform: Save data
    $(document).on('click', '#btnSave_A_Emp_2', function () {
        paramAjax.url = '/Emp/prvSaveAddfrm';
        paramAjax.type = 'POST';
        paramDt.EmployeeName = $("#txtEmpName_A_Emp_2").val();
        paramDt.Salary = $("#txtEmpSalary_A_Emp_2").val();
        fnc_SaveDataBtn_Emp_2(paramAjax, paramDt);
    });
    //AddNew Subform: Cancel button clicked => subform disappear
    $(document).on('click', '#btnCancel_A_Emp_2', function () {
        $("#Container_subEmp_Emp_2").hide();
    });

    /***** Edit Process *****/
    //Open Edit subform
    $(".btnEdit_Emp_2").click(function () {
        var sSelectedEmpId = $(this).parents("tr:first").children("td:nth-child(1)").text().trim();
        $("#divTblEmpList_Emp_2 tr").removeClass("rowColor2");
        $(this).parents("tr").addClass("rowColor2");
        //Open 'Edit Subform' 
        paramAjax.url = '/Emp/prvShowEditfrm';
        paramAjax.type = 'Get';
        fnc_openSubform(paramAjax, sSelectedEmpId);
    });
    //Edit Subform: Save data
    $(document).on('click', '#btnSave_E_Emp_2', function () {
        paramAjax.url = '/Emp/prvSaveEditfrm';
        paramAjax.type = 'POST';
        paramDt.EmployeeID = $("#txtEmpID_E_Emp_2").val();
        paramDt.EmployeeName = $("#txtEmpName_E_Emp_2").val();
        paramDt.Salary = $("#txtEmpSalary_E_Emp_2").val();
        paramDt.DepartmentID = $("#dllDeptEdit_Emp_2").val();
        fnc_SaveDataBtn_Emp_2(paramAjax, paramDt);
    });
    //Edit Subform: Cancel button clicked => subform disappear
    $(document).on('click', '#btnCancel_E_Emp_2', function () {
        $("#Container_subEmp_Emp_2").hide();
    });
});

//Functions
//(1)Open Subform
function fnc_openSubform(para1, paraID) {
    $.ajax({
        url: para1.url,
        type: para1.type,
        data: { sID: paraID },  
        success: function (result) {
            $("#Section_subEmp_Emp_2").empty().append(result);
            $("#Container_subEmp_Emp_2").show();
        },
        error: function () {
            alert("Something wrong...");
        }
    });
}
//(2) funciton : Saving Data from AddNew Partial View 
function fnc_SaveDataBtn_Emp_2(para1, para2) {
    $.ajax({
        url: para1.url,
        type: para1.type,
        data: { Dt: para2 },  
        success: function (result) {
            alert("Data is saved!");
            window.location.reload();
        },
        error: function () {
            alert("Something Wrong: Data was not Saved.");
        }
    });
}
