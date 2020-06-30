jQuery(document).ready(function ($) {
    // Play when in viewport
    $(window).on('scroll load', function () {
        $('.responsive-vid iframe').each(function (i) {
            player.pauseVideo();
            var scroll_position = $(window).scrollTop();
            var bottom_of_video = $(this).offset().top + ($(this).outerHeight() / 2);
            var bottom_of_window3 = $(window).scrollTop() + $(window).height();
            if (bottom_of_window3 > bottom_of_video && scroll_position < bottom_of_video) {
                player.playVideo();
                $('#player').css({ 'opacity': '1' });
            } else {
                player.pauseVideo();
                $('#player').css({ 'opacity': '.6' });
            }
        });
    });

});