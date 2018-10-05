var map;
jQuery(document).ready(function () {

    /* ======= Flexslider ======= */
    $('.flexslider').flexslider({
        animation: "fade"
    });

    /* ======= jQuery Placeholder ======= */
    $('input, textarea').placeholder();


    /* ======= Carousels ======= */
    $('#news-carousel').carousel({ interval: false });
    $('#videos-carousel').carousel({ interval: false });
    $('#testimonials-carousel').carousel({ interval: 6000, pause: "hover" });
    $('#awards-carousel').carousel({ interval: false });


    /* ======= Flickr PhotoStream ======= */
    $('#flickr-photos').jflickrfeed({
        limit: 12,
        qstrings: {
            id: '32104790@N02' /* Use idGettr.com to find the flickr user id */
        },
        itemTemplate:
            '<li>' +
            '<a rel="prettyPhoto[flickr]" href="{{image}}" title="{{title}}">' +
            	'<img src="{{image_s}}" alt="{{title}}" />' +
            '</a>' +
            '</li>'

    }, function (data) {
        $('#flickr-photos a').prettyPhoto();
    });

    /* ======= Pretty Photo ======= */
    // http://www.no-margin-for-errors.com/projects/prettyphoto-jquery-lightbox-clone/ 
    $('a.prettyphoto').prettyPhoto();

    /* ======= Twitter Bootstrap hover dropdown ======= */

    // apply dropdownHover to all elements with the data-hover="dropdown" attribute
    //$('[data-hover="dropdown"]').dropdownHover();


    /* ======= Style Switcher ======= */

    $('#config-trigger').on('click', function (e) {
        var $panel = $('#config-panel');
        var panelVisible = $('#config-panel').is(':visible');
        if (panelVisible) {
            $panel.hide();;
        } else {
            $panel.show();
        }
        e.preventDefault();
    });

    $('#config-close').on('click', function (e) {
        e.preventDefault();
        $('#config-panel').hide();
    });


    $('#color-options a').on('click', function (e) {
        var $styleSheet = $(this).attr('data-style');
        var $logoImage = $(this).attr('data-logo');
        $('#theme-style').attr('href', $styleSheet);
        $('#logo').attr('src', $logoImage);

        var $listItem = $(this).closest('li');
        $listItem.addClass('active');
        $listItem.siblings().removeClass('active');

        e.preventDefault();

    });


    /* ======= Nav Bar ======= */

    var url = window.location.pathname + window.location.search;
    var activePage = url.substring(url.lastIndexOf('/') + 1, url.lastIndexOf('?'));

    $('.navbar-nav li a').each(function () {
        var currentPage = this.href.substring(this.href.lastIndexOf('/') + 1);

        if (activePage == "" || activePage.toLowerCase() == "default.aspx") {
            $('body').addClass('home-page')
        }

        $(this).parent().removeClass("active");

        if (activePage == "") {
            $(this).parent().addClass('active');
            return false;
        } else if (activePage == currentPage) {
            $(this).parent().addClass('active');
            return false;
        }
    });

    /* ======= baseQueryString ======= */
    $(".baseQueryString").each(function () {
        var qs = $(this).attr('href').split('?');
        $(this).attr('href', qs[0] + $('#hddBaseQueryString').val() + (qs.length > 1 ? '&' + qs[1] : ''));
    });

    $(".espQueryString").each(function () {
        var qs = $(this).attr('href').split('?');
        $(this).attr('href', qs[0] + $('#hddEspQueryString').val() + (qs.length > 1 ? '&' + qs[1] : ''));
    });

    /* ======= Logged ======= */
    $(".logged").each(function () {
        if ($('#hddLogged').val() == "True") {
            $('.logged').show();
            $('.offline').hide();
        } else {
            $('.logged').hide();
            $('.offline').show();
        }
    });


    setMenuTeacher();

    /* ======= Alert ======= */

    $('.alert').hide();
});

function setMenuTeacher() {
    $('.teacher').hide();
    if ($.QueryString("user") != null) {
        $.ajax({
            type: "POST",
            url: "Default.aspx/AjaxGetTeacher?ac=" + $.QueryString("ac"),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d != null && msg.d.length > 0) {
                    $.each(msg.d, function (i, row) {
                        $(".teacher ul").append('<li><a class="teacherQueryString" href="Teacher.aspx?ac=' + $.QueryString("ac") + '&user=' + $.QueryString("user") + '&courseId=' + row.courseId + '">' + row.couseName + '</a></li>');
                    });
                    $('.teacher').show();
                } 
                //$(".teacher").each(function () {
                //    if ($('#hddTeacher').val() == "True") {
                //        $('.teacher').show();
                //    } else {
                //        $('.teacher').hide();
                //    }
                //});
            },
            error: function (data, status, e) {
            }
        });
    }
}

function alertMsg(status, msg) {
    //alert-success; alert-info; alert-warning; alert-danger;
    $('.alert').removeClass('alert-success');
    $('.alert').removeClass('alert-info');
    $('.alert').removeClass('alert-warning');
    $('.alert').removeClass('alert-danger');
    $('.alert').empty();
    if (status == 'success') {
        $('.alert').addClass('alert alert-success');
        $('.alert').html('<strong>Sucesso! </strong> ' + msg);
    } else if (status == 'info') {
        $('.alert').addClass('alert alert-info');
        $('.alert').html('<strong>Atenção! </strong> ' + msg);
    } else if (status == 'warning') {
        $('.alert').addClass('alert alert-warning');
        $('.alert').html('<strong>Aviso! </strong> ' + msg);
    } else if (status == 'danger') {
        $('.alert').addClass('alert alert-danger');
        $('.alert').html('<strong>Erro! </strong> ' + msg);
    }
    $('.alert').fadeIn('slow', function () {
        $(this).delay(5000).fadeOut('slow');
    });
}

function popupCentral(f, l, a, s) {
    var i = (screen.width - l) / 2;
    var j = (screen.height - a) / 2;
    window.open(f, 'modulo', 'resizable=yes,scrollbars=' + s + ',height=' + a + ',width=' + l + ',top=' + j + ',left=' + i);
}

function addslashes(str) {
    return (str + '').replace(/[\\"']/g, '\\$&').replace(/\u0000/g, '\\0');
}