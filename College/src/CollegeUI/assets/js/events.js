jQuery(document).ready(function () {
    $('.urlFeaturedEvent').attr('src', $('#hddUrlFeaturedEvent').val());

    $('.hyVideo').click(function () { 
        //var row = $(this).parents("article:first");
        //row.insertBefore($("article:first"));

        var row = $("iframe");
        row.appendTo($(this).parent().parent().parent().parent().children('aside').children('section'));
        $('.urlFeaturedEvent').attr('src', $(this).attr('video'));

        scrolltotop.setting.scrollto = 'article:eq(' + $(this).parent().parent().parent().parent().index()+ ')';
        scrolltotop.scrollup();
        scrolltotop.setting.scrollto = 0;
    });
});