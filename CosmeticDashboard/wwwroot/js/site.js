// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("input:checkbox").on('click', function () {
        if ($(this).prop('checked')) {
            $('#wrap').addClass("ischecked");
        }
        else {
            $('#wrap').removeClass("ischecked");
        }
    });
});