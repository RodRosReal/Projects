jQuery(document).ready(function () {
    /* ======= Validade Form Submit ======= */
    $(".cpf").mask('999.999.999-99', { reverse: true });
    $('.tel').mask('(99) 9999-9999');
    $('.cel').mask('(99) 9999-9999');


    $('#btnMyAccont').click(function () {
        var bSubmit = true;
        $("label.req").each(function () {
            var txtAttrb = $(this).attr('for');
            if (txtAttrb.length > 0) {
                var txtVal = $('#' + txtAttrb);

                if (txtAttrb == 'password' && $.QueryString("user") != null) {
                    $(this).find('span').hide();
                } else if (txtAttrb == 'cpf' && !$('#cpf').validateCPF()) {
                    $(this).find('span').show();
                    txtVal.focus();
                    bSubmit = false;
                    return false;
                } else if (txtAttrb == 'confirm') {
                    if (($('#password').val() != '' && txtVal.val() == '') ||
                        ($('#password').val() != txtVal.val())) {
                        $(this).find('span').show();
                        txtVal.focus();
                        bSubmit = false;
                        return false;
                    } else {
                        $(this).find('span').hide();
                    }
                } else if (txtVal.val() == '') {
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

            var sendUser = {
                user: {
                    name: addslashes($('#name').val()),
                    surname: addslashes($('#surname').val()),
                    email: $('#email').val(),
                    tel: $('#tel').val(),
                    cel: $('#cel').val(),
                    cpf: $('#cpf').val(),
                    password: addslashes($('#password').val())
                }
            };

            $.ajax({
                type: "POST",
                url: "MyAccont.aspx/AjaxSetUser?ac=" + $.QueryString("ac") + ($.QueryString("user") != null ? '&user=' + $.QueryString("user") : ''),
                data: JSON.stringify(sendUser),
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == '-1') {
                        alertMsg('warning', 'Email já cadastrado');
                    }else {
                        alertMsg('success', 'Operação efetuada com sucesso');
                        return false;
                    } 
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
