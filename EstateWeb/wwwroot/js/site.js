// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Đổi Quận theo Tỉnh/Thành
var ProvinceChange = function (event) {
    var id = event.target.value;
    var urlGetDistrict = "home/GetDistrict?provinceId= " + id;
    $.getJSON(urlGetDistrict, GetDistrictCallBack);  
};

var GetDistrictCallBack = function (data, status) {
    if (status === "success") {
        var option = "<option value='0'>---Chọn Quận Huyện---</option>";
        var option1 = "<option value='0'>---Chọn Đường--</option>";
        var option2 = "<option value='0'>---Chọn Xã/Phường--</option>";
        var option3 = "<option value='0'>---Dự án--</option>";
        data.forEach(function (item) {
            option += "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#slbDistrict").empty();
        $("#slbStreet").empty();
        $("#slbWard").empty();
        $("#slbProject").empty();
        $("#slbDistrict").append(option);
        $("#slbStreet").append(option1);
        $("#slbWard").append(option2);
        $("#slbProject").append(option3);
    }
    else {

    }
};

//Đổi Đường theo Quận
var DistrictChange = function (event) {
    var id = event.target.value;
    var urlGetStreet = "home/GetStreet?streetId= " + id;
    $.getJSON(urlGetStreet, GetStreetCallBack);
};

var GetStreetCallBack = function (data, status) {
    if (status === "success") {
        var option = "<option value='0'>---Chọn Đường--</option>";
        data.forEach(function (item) {
            option += "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#slbStreet").empty();
        $("#slbStreet").append(option);
    }
    else {

    }
};

//Đổi Phường/Xã theo Quận
var DistrictChange1 = function (event) {
    var id = event.target.value;
    var urlGetWard = "home/GetWard?wardId= " + id;
    $.getJSON(urlGetWard, GetWardCallBack);
};

var GetWardCallBack = function (data, status) {
    if (status === "success") {
        var option = "<option value='0'>---Chọn Xã/Phường--</option>";
        data.forEach(function (item) {
            option += "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#slbWard").empty();
        $("#slbWard").append(option);
    }
    else {

    }
};

//Đổi Dự án theo Quận
var DistrictChange2 = function (event) {
    var id = event.target.value;
    var urlGetProject = "home/GetProject?projectID= " + id;
    $.getJSON(urlGetProject, GetProjectCallBack);
};

var GetProjectCallBack = function (data, status) {
    if (status === "success") {
        var option = "<option value='0'>---Dự án--</option>";
        data.forEach(function (item) {
            option += "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#slbProject").empty();
        $("#slbProject").append(option);
    }
    else {

    }
};

//Hàm
$(function () {
    $.validator.addMethod("noSpace", function (value, element) {
        return value == '' || value.trim().length != 0
    }, "Không được nhập khoảng trắng");

    $.validator.addMethod('selectcheck', function (value) {
        return (value != '0');
    }, "*Vui lòng chọn");

});

//Validate form
$("#frm").validate({
    rules: {
        Title: {
            required: true,
            noSpace: true
        },
        Content: {
            required: true,
            noSpace: true
        },
        Acreage: {
            required: true,
            noSpace: true,
            number: true
        },
        Price: {
            required: true,
            noSpace: true,
            number: true
        },
        NewsType: {
            required: true,
            selectcheck: true
        },
        EstateType: {
            required: true,
            selectcheck: true
        },
        PriceType: {
            required: true,
            selectcheck: true
        }
    },
    messages: {
        Title: {
            required: "*Vui lòng nhập tiêu đề"
        },
        Content: {
            required: "*Vui lòng nhập nội dung"
        },
        Acreage: {
            required: "*Vui lòng nhập diện tích",
            number: "*Vui lòng nhập số"
        },
        Price: {
            required: "*Vui lòng nhập giá",
            number: "*Vui lòng nhập số"
        },
        NewsType: {
            selectcheck: "*Bạn chưa chọn loại tin"
        },
        EstateType: {
            selectcheck: "*Bạn chưa chọn loại BĐS"
        },
        PriceType: {
            selectcheck: "*Bạn chưa chọn đơn vị tính"
        }
    }
});

//Validate địa chỉ
$("#NO").rules("add", {
    required: true,
    noSpace : true,
    messages: {
        required: "*Vui lòng nhập địa chỉ"
    }
});

//Validate chiều ngang
$("#Width").rules("add", {
    required: true,
    noSpace: true,
    messages: {
        required: "*Vui lòng nhập chiều ngang"
    }
});

//Validate số lầu
$("#NumberOfFloors").rules("add", {
    required: true,
    noSpace: true,
    number: true,
    messages: {
        required: "*Vui lòng nhập số lầu",
        number: "*Vui lòng nhập số"
    }
});

//Validate chiều dài
$("#Lenght").rules("add", {
    required: true,
    noSpace: true,
    messages: {
        required: "*Vui lòng nhập chiều dài"
    }
});

//Validate đường trước nhà
$("#WidthOfStreet").rules("add", {
    required: true,
    noSpace: true,
    number: true,
    messages: {
        required: "*Vui lòng nhập đường trước nhà",
        number: "*Vui lòng nhập số"
    }
});

//Validate số phòng ngủ
$("#NumberOfRooms").rules("add", {
    required: true,
    noSpace: true,
    number: true,
    messages: {
        required: "*Vui lòng nhập số phòng ngủ",
        number: "*Vui lòng nhập số"
    }
});

//Validate tên
$("#Name").rules("add", {
    required: true,
    noSpace: true,
    messages: {
        required: "*Vui lòng nhập tên liên hệ"
    }
});

//Validate số điện thoại
$(function () {
    $cf = $('#Phone');
    $cf.blur(function (e) {
        var vnf_regex = /((09|03|07|08|05)+([0-9]{8})\b)/g;
        var mobile = $(this).val();
        if (mobile !== '') {
            if (vnf_regex.test(mobile) == false) {
                alert('Số điện thoại của bạn không đúng định dạng!');
                $('#Phone').val('');
            } else {
                alert('Số điện thoại của bạn hợp lệ!');
            }
        }
        else {
            alert("Bạn chưa nhập số điện thoại!");
        }
    });
});
$("#Phone").rules("add", {
    required: true,
    noSpace: true,
    number: true,
    messages: {
        required: "*Vui lòng nhập số điện thoại",
        number: "*Vui lòng nhập số"
    }
});

//Validate Tỉnh
$("#slbProvince").rules("add", {
    required: true,
    selectcheck: true,
    messages: {
        selectcheck: "*Bạn chưa chọn tỉnh"
    }
});

//Validate dự án
$("#slbProject").rules("add", {
    required: true,
    selectcheck: true,
    messages: {
        selectcheck: "*Bạn chưa chọn dự án"
    }
});

//Validate quận
$("#slbDistrict").rules("add", {
    required: true,
    selectcheck: true,
    messages: {
        selectcheck: "*Bạn chưa chọn quận"
    }
});

//Validate đường
$("#slbStreet").rules("add", {
    required: true,
    selectcheck: true,
    messages: {
        selectcheck: "*Bạn chưa chọn đường"
    }
});

//Validate xã/phường
$("#slbWard").rules("add", {
    required: true,
    selectcheck: true,
    messages: {
        selectcheck: "*Bạn chưa chọn xã/phường"
    }
});

//Validate hướng
$("#Direction").rules("add", {
    required: true,
    selectcheck: true,
    messages: {
        selectcheck: "*Bạn chưa chọn hướng"
    }
});

//Validate pháp lý
$("#Juridical").rules("add", {
    required: true,
    selectcheck: true,
    messages: {
        selectcheck: "*Bạn chưa chọn pháp lý"
    }
});
