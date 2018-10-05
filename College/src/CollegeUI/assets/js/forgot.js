jQuery(document).ready(function () {
    /* ======= Validade Form Submit ======= */

    $('#btnForgot').click(function () {
        var bSubmit = true;
        $("label.req").each(function () {
            var txtAttrb = $(this).attr('for');
            if (txtAttrb.length > 0) {
                var txtVal = $('#' + txtAttrb);
                if (txtVal.val() == '') {
                    $(this).find('span').show();
                    txtVal.focus();
                    bSubmit = false;
                    return false;
                } else {
                    $(this).find('span').hide();
                }
            }
        });
        if (bSubmit == true) {
            $.ajax({
                type: "POST",
                url: "Forgot.aspx/AjaxForgot?ac=" + $.QueryString("ac"),
                data: "{'email':'" + $("#email").val() + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == true) {
                        alertMsg('success', 'Email enviado com sucesso');
                        setTimeout(function () {
                            $(location).attr('href', 'Login.aspx?ac=' + $.QueryString("ac"));
                        }, 3000);
                    } else {
                        alertMsg('warning', 'Email inexistente');
                        return false;
                    };
                },
                error: function (data, status, e) {
                    alertMsg('danger', 'Não foi possível efetuar a operação');
                    return false;
                }
            });
        }
        return false;
    });
});