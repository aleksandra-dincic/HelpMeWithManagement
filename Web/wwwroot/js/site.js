var Site = {

}

Site.checkEmployeeDetails = function(id) {

    $.ajax({
        url: '/Employee/GetEmployee?employeeId=' + id,
        type: 'GET',
        success: function(result) {

            $("#employeeId").val(result.id);
            $("#employeeFirstName").val(result.firstName);
            $("#employeeLastName").val(result.lastName);
            $("#employeeRoleName").val(result.roleName);
            $("#employeeDateOfBirth").val(result.dateOfBirth);
            $("#employeeStartDate").val(result.started);
            $("#employeePictureUrl").val(result.pictureUrl);

        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.addEmployee = function() {

    var firstName = $("#newEmployeeFirstName").val();
    var lastName = $("#newEmployeeLastName").val();
    var roleName = $("#newEmployeeRoleName").val();
    var dateOfBirth = $("#newEmployeeDateOfBirth").val();
    var startDate = $("#newEmployeeStartDate").val();
    var pictureUrl = $("#newEmployeePictureUrl").val();

    var employee = {
        FirstName: firstName,
        LastName: lastName,
        RoleName: roleName,
        Started: startDate,
        DateOfBirth: dateOfBirth,
        PictureUrl: pictureUrl
    };

    $.ajax({
        url: '/Employee/AddEmployee',
        type: 'POST',
        data: employee,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.addDepartment = function() {

    var name = $("#newDepartmentName").val();
    var type = $("#newDepartmentType").val();
    var description = $("#newDepartmentDescription").val();

    var department = {
        Name: name,
        Type: type,
        Description: description
    };

    $.ajax({
        url: '/Department/CreateDepartment',
        type: 'POST',
        data: department,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.saveEmployee = function() {

    var id = $("#employeeId").val();
    var firstName = $("#employeeFirstName").val();
    var lastName = $("#employeeLastName").val();
    var roleName = $("#employeeRoleName").val();
    var dateOfBirth = $("#employeeDateOfBirth").val();
    var startDate = $("#employeeStartDate").val();
    var pictureUrl = $("#employeePictureUrl").val();

    var employee = {
        Id: id,
        FirstName: firstName,
        LastName: lastName,
        RoleName: roleName,
        Started: startDate,
        DateOfBirth: dateOfBirth,
        PictureUrl: pictureUrl
    };

    $.ajax({
        url: '/Employee/UpdateEmployee',
        type: 'POST',
        data: employee,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.assignEmployeeToDepartment = function() {

    var employee = $("#assignEmployee").val();
    var department = $("#assignToDepartment").val();

    var departmentAssignment = {
        Employee: employee,
        Department: department
    };

    $.ajax({
        url: '/Employee/AssignToDepartment',
        type: 'POST',
        data: departmentAssignment,
        success: function(result) {
            $("#assignToDepartmentMessage").css("display", "block");
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.deleteEmployee = function() {

    var id = $("#employeeId").val();

    $.ajax({
        url: '/Employee/DeleteEmployee?id=' + id,
        type: 'DELETE',
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.deleteDepartment = function(id) {

    $.ajax({
        url: '/Department/DeleteDepartment?id=' + id,
        type: 'DELETE',
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}