function SetEnrollment() {
    $.ajax({
        type: "POST",
        url: "Course.aspx/AjaxSetEnrollment?ac=" + $.QueryString("ac") + "&user=" + $.QueryString("user") + "&c=" + $.QueryString("c"),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == true) {
                alertMsg('success', 'Inscrição efetuada com sucesso. Próximo passo envie um Código de Matrícula válido');
                setTimeout(function () {
                    $(location).attr('href', 'MyCourses.aspx?ac=' + $.QueryString('ac') + '&user=' + $.QueryString('user'));
                }, 5000);
            } else {
                alertMsg('warning', 'Não foi possível efetuar a inscrição');
            };
        },
        error: function (data, status, e) {
            alertMsg('danger', 'Não foi possível efetuar a operação');
        }
    });
}