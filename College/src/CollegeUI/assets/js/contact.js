jQuery(document).ready(function () {
    /* ======= Validade Form Submit ======= */

    $('#btnSend').click(function () {
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
                url: "Contact.aspx/AjaxContact?ac=" + $.QueryString("ac"),
                data: "{'name':'" + addslashes($("#name").val()) +
                     "','email':'" + $("#email").val() +
                     "','message':'" + addslashes($('#message').val()) + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == true) {
                        alertMsg('success', 'Email enviado com sucesso');                        
                    } else {
                        alertMsg('warning', 'Não foi possível efetuar a operação');
                    };
                },
                error: function (data, status, e) {
                    alertMsg('danger', 'Não foi possível efetuar a operação');
                }
            });
        }
    });
});