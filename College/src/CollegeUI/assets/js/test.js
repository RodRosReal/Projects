jQuery(document).ready(function () {
    window.opener.location.reload();
    if ($('#pnMsg').length) {
        if ($('#hddStatus').val() == '1') {
            alertMsg('success', 'Questão salva com sucesso');
            window.opener.location.reload();
        } else if ($('#hddStatus').val() == '0') {
            alertMsg('warning', 'Não foi possível efetuar a operação');
        } else if ($('#hddStatus').val() == '2') {
            alertMsg('warning', 'Campo Resposta é obrigatório');
        } else if ($('#hddStatus').val() == '3') {
            alertMsg('warning', 'Não foi possível salvar a questão - tempo do teste expirou.');
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
        $('.alert').html('<strong>Atenção! </strong> ' + msg);
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
