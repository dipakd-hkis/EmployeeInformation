

var emailformat = true;
var uniquecode = true;
$(document).ready(function () {
    addvalidation();
});

function addvalidation() {

    // only digits allow validation.
    $(".onlynumberallow").on("keyup", function (e) {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    // email format validation check on focus change.
    $("#email").on("change", function (e) {
        var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
        var valueToTest = $('#email').val();
        if (!(testEmail.test(valueToTest))) {
            $('#emailformat').show();
            emailformat = false;
        } else {
            $('#emailformat').hide();
            emailformat = true;
        }
    });

    //ajax call for check emplyee code is unique or not.
    $(".empcode").on("change", function (e) {

        var emp_code = e.target.value;
        $.ajax({
            type: "GET",
            url: "getuniquecode",
            data: {
                emp_code: emp_code
            },
            success: function (data) {
                if (data == true) {
                    $('#isuniquecode').hide();
                    uniquecode = true;
                } else {
                    uniquecode = false;
                    $('#isuniquecode').show();
                }
            }
        });
    });
}

function addNumbers(frm) {
    var isValidate = true;
    var input_collection = $('.tr_phone').find(':input');
    input_collection.each(function (i) {
        if (input_collection[i].value == '' || input_collection[i].value.length != 10) {
            isValidate = false;
        }
    });
    if (isValidate == true) {
        $('#multiplenumbervalidation').hide();
        $('.tr_phone').append(`<input name="Phone" type="text" class="form-control mb-4 onlynumberallow" maxlength="10" style="margin-top:20px" placeholder="Enter Phone Number" />`);
    } else {
        $('#multiplenumbervalidation').show();
    }
}



function ValidateForm(frm) {
    var isValid = true;
    if (frm.First_Name.value.trim() == "") {
        $('#isfirstname').show();
        frm.First_Name.focus();
        isValid = false;
    } else {
        $('#isfirstname').hide();
    }
    if (frm.Last_Name.value.trim() == "") {
        $('#islastname').show();
        frm.Last_Name.focus();
        isValid = false;
    } else {
        $('#islastname').hide();
    }

    if (frm.Address.value.trim() == "") {
        $('#isaddress').show();
        frm.Address.focus();
        isValid = false;
    } else {
        $('#isaddress').hide();
    }

    if (frm.Email_Address.value.trim() == "") {
        $('#isemail').show();
        frm.Email_Address.focus();
        isValid = false;
    } else {
        $('#isemail').hide();
    }

    if (frm.Phone.value.trim() == "") {
        $('#isphonenumber').show();
        frm.Phone.focus();
        isValid = false;
    } else {
        $('#isphonenumber').hide();
    }
    if (frm.Employee_Code.value.trim() == "") {
        $('#isemployeecode').show();
        frm.Employee_Code.focus();
        isValid = false;
    } else {
        $('#isemployeecode').hide();
    }

    if (isValid == true && uniquecode == true && emailformat == true) {
        return true;
    } else {
        return false;
    }
}
