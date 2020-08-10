

function popUpmodal1() {
    
    blockOverflow()
    $('.modal-bg').addClass('bg-active');

    $('.modal_1').addClass('md-active');
    
  
}

function popUpmodal2() {

    blockOverflow()
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
    $('.modal-bg').removeClass('bg-active');
    $('.modal_1').removeClass('md-active');
    $('.modal_2').removeClass('md-active');
}

