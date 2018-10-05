$(function () {
    $('#btnSendCode').click(function () {
        if ($(this).parent().children('.cod-group').children('.form-control').val() != '') {
            $.ajax({
                type: "POST",
                url: "MyCourses.aspx/AjaxSendCode?ac=" + $.QueryString("ac") + "&user=" + $.QueryString("user"),
                data: "{'code':'" + $(this).parent().children('.cod-group').children('.form-control').val() +
                     "','enrollment':'" + $(this).parent().children('.cod-group').children('input:hidden').eq(0).val() +
                     "','course':'" + $(this).parent().children('.cod-group').children('input:hidden').eq(1).val() + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == true) {
                        alertMsg('success', 'C�digo V�lido');
                        setTimeout(function () {
                            $(location).attr('href', 'MyCourses.aspx?ac=' + $.QueryString('ac') + '&user=' + $.QueryString('user'));
                        }, 3000);
                    } else {
                        alertMsg('warning', 'N�o foi poss�vel validar o c�digo');
                    };
                },
                error: function (data, status, e) {
                    alertMsg('danger', 'N�o foi poss�vel efetuar a opera��o');
                }
            });
        } 
    });
});