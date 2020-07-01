$(document).ready(function (){
    $('#menuicon').on('click',function () {
        $('#sample_video').trigger('pause');
    });
});

$(window).scroll(function () {
    
    var trackerOffset = $('.tracker').offset().top; // offset in document
    var trackerPosition = trackerOffset - $(window).scrollTop(); // offset in viewport
    checkTrackerPos(trackerPosition);
}).trigger('scroll');

function checkTrackerPos(trackerPosition) {
    var triggerTop = $('.trigger-top').position();
    var triggerBottom = $('.trigger-bottom').position();
    if (trackerPosition >= triggerTop.top && trackerPosition <= triggerBottom.top) {
        
        $('#sample_video').trigger('play');
        
    } else {
        $('#sample_video').trigger('pause');
    }
    
}