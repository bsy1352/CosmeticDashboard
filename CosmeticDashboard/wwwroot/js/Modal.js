

function popUpmodal1(_location) {
    
    blockOverflow()
    $('.modal-bg').addClass('bg-active');

    $('.modal_1').addClass('md-active');
    
    var location = _location;

    $.ajax({
        url: "api/Location/" + location,
        contentType: 'application/json;charset=utf-8',
        method: "get",
        dataType: 'json',
        success: function (response) {
            //var data = JSON.stringify(response.x);
            //$.each(response, function (key, value) {
            //    alert(key + ' / ' + value);
            //});
            ////var data = JSON.stringify(response);
            //alert(Object.keys(response.x).length);
            
            $('.modal_1').children('.modal_children').append('<div class="btn_group"></div>')
            for (var i = 0; i < Object.keys(response.x).length; i++) {
                //alert(JSON.stringify(response.x[i].factoryName));
                $('.modal_1').children('.modal_children').children('.btn_group')
                    .append('<button class="button button1">' + response.x[i].factoryName + '</button>');
            }
        }

    });
  
}

function popUpmodal2() {

    blockOverflow();

    $('.modal-bg').addClass('bg-active');

    $('.modal_2').addClass('md-active');
        

}

function blockOverflow() {

    $('body').addClass('noscrolling');

}

function startOverflow() {

    $('body').removeClass('noscrolling');

}


function popupClose() {
    startOverflow();
    $('.modal_1').children('.modal_children').empty();
    $('.modal-bg').removeClass('bg-active');
    $('.modal_1').removeClass('md-active');
    $('.modal_2').removeClass('md-active');
    
}

