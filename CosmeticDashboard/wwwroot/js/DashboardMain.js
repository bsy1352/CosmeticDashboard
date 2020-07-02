$(document).ready(function () {
    $.ajax({
        url: 'Dashboard/MainPage',
        type: 'GET',
        cache: false,
        success: function (data) {
            $('#Main').html(data);
        }
    });
});