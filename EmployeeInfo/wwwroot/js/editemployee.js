
function validate(e) {
    e.value = e.value.replace(/[^0-9]/g, '');
}

function addMobileNumber() {
    var isValidate = true;
    var input_collection = $('#phonnumberlist').find(':input');
    input_collection.each(function (i) {
        if (input_collection[i].value == '' || input_collection[i].value.length != 10) {
            isValidate = false;
        }
    });
    if (isValidate == true) {
        $('#phonnumberlist').append('<input maxlength="10" onkeyup="validate(this)" class="form-control onlynumberallow" id="Phone_' + $('#phonnumberlist').find(':input').length + '_" name="Phone_' + $('#phonnumberlist').find(':input').length + '_" type="text" />');
    }
}

function codeCheck(e) {
    debugger
    var emp_code = e.value;
    var getuniquecode = 'getuniquecode';
    $.ajax({
        type: 'GET',
        url: 'getuniquecode',
        data: {
            emp_code: emp_code
        },
        contentType: 'application/json; charset=utf-8',
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
}