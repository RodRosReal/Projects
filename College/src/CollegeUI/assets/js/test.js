jQuery(document).ready(function () {
    window.opener.location.reload();
    if ($('#pnMsg').length) {
        if ($('#hddStatus').val() == '1') {
            alertMsg('success', 'Quest�o salva com sucesso');
            window.opener.location.reload();
        } else if ($('#hddStatus').val() == '0') {
            alertMsg('warning', 'N�o foi poss�vel efetuar a opera��o');
        } else if ($('#hddStatus').val() == '2') {
            alertMsg('warning', 'Campo Resposta � obrigat�rio');
        } else if ($('#hddStatus').val() == '3') {
            alertMsg('warning', 'N�o foi poss�vel salvar a quest�o - tempo do teste expirou.');
        };
    };

    if ($('#countdown_dashboard').length) {
        $('#countdown_dashboard').countDown({
            targetDate: {
                'day': $('#hddDay').val(),
                'month': $('#hddMonth').val(),
                'year': $('#hddYear').val(),
                'hour': $('#hddHour').val(),
                'min': $('#hddMin').val(),
                'sec': $('#hddSec').val()
            }
        });
    }
});

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
        $('.alert').html('<strong>Aten��o! </strong> ' + msg);
    } else if (status == 'warning') {
        $('.alert').addClass('alert alert-warning');
        $('.alert').html('<strong>Aviso! </strong> ' + msg);
    } else if (status == 'danger') {
        $('.alert').addClass('alert alert-danger');
        $('.alert').html('<strong>Erro! </strong> ' + msg);
    }
    $('.alert').fadeIn('slow', function () {
        $(this).delay(3000).fadeOut('slow');
    });
}
