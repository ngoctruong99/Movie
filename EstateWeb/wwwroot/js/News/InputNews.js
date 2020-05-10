// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var controller = "/movie";

var InputNews = function () {
    var urlInputNew = controller + "/InputNews";
    var objNews = $("#form-input-movie").serializeObject();

    $.post(urlInputNew, objNews, InputNewsCallBack);
}

var InputNewsCallBack = function (result) {
    if (result.success) {
        $('#showSuccess').modal('toggle');
        window.location.href = '../Movie';
    }
    else {
        $('#showError').modal('toggle');
    }
}
var InputRoom = function () {
    var urlInputRoom = controller + "/InputRoom";
    var obj = $("#form-input-room").serializeObject();

    $.post(urlInputRoom, obj, InputRoomsCallBack);
}

var InputRoomsCallBack = function (result) {
    if (result.success) {
        $('#showSuccess').modal('toggle');
        window.location.href = '../Movie';
    }
    else {
        $('#showError').modal('toggle');
    }
}

var DateMovieChange = function (event) {
    var id = event.target.value;
    var urlGetDistrict = controller + "/GetRoom?CalendarMovieId= " + id;
    $.getJSON(urlGetDistrict, GetRoomCallBack);
};

var GetRoomCallBack = function (data, status) {
    if (status === "success") {
        var option = "<option value='0'>---Chọn Phòng ---</option>";
        data.forEach(function (item) {
            option += "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#slbRoom").empty();
        $("#slbRoom").append(option);
    }
    else {

    }
};
var RoomChange = function (event) {
    var id = event.target.value;
    var urlGetDistrict = controller + "/GetSeat?RoomId= " + id;
    $.getJSON(urlGetDistrict, GetSeatCallBack);
};

var GetSeatCallBack = function (data, status) {
    if (status === "success") {
        var option = "<option value='0'>---Chọn Ghế ---</option>";
        data.forEach(function (item) {
            option += "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#slbSeat").empty();
        $("#slbSeat").append(option);
    }
    else {

    }
};
var GotoDetail = function (obj) {
    window.location.href = '../Movie/Detail?id=' + obj;
}
var Book = function (obj) {
    window.location.href = '../Movie/Book?id=' + obj;
}

