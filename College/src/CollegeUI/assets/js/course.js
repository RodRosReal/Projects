function SetEnrollment() {
    $.ajax({
        type: "POST",
        url: "Course.aspx/AjaxSetEnrollment?ac=" + $.QueryString("ac") + "&user=" + $.QueryString("user") + "&c=" + $.QueryString("c"),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == true) {
                alertMsg('success', 'Inscri��o efetuada com sucesso. Pr�ximo passo envie um C�digo de Matr�cula v�lido');
                setTimeout(function () {
                    $(location).attr('href', 'MyCourses.aspx?ac=' + $.QueryString('ac') + '&user=' + $.QueryString('user'));
                }, 5000);
            } else {
                alertMsg('warning', 'N�o foi poss�vel efetuar a inscri��o');
            };
        },
        error: function (data, status, e) {
            alertMsg('danger', 'N�o foi poss�vel efetuar a opera��o');
        }
    });
}