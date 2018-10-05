jQuery(document).ready(function () {
    /* ======= Validade Form Submit ======= */

    $('#btnLogin').click(function () {
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
                url: "Login.aspx/AjaxLogin?ac=" + $.QueryString("ac"),
                data: "{'email':'" + $("#email").val() +
                     "','password':'" + $('#password').val() + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d != '') {
                        //alertMsg('success', 'Login efetuado com sucesso');
                        //setTimeout(function () {
                        $(location).attr('href', 'MyCourses.aspx?ac=' + $.QueryString("ac") + '&user=' + msg.d);
                        //}, 3000);                        
                    } else {
                        alertMsg('warning', 'Não foi possível efetuar a operação');
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