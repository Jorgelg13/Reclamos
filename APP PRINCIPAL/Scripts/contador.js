
$(document).ready(function () {
    var clock;
    var tiempo = $('#ContentPlaceHolder1_txtTiempo').val();
    var tiempo2 = parseInt(tiempo)

    clock = $('.clock').FlipClock(tiempo2, {
        clockFace: 'DailyCounter',
        autoStart: false,
        callbacks: {
            stop: function () {
                $('.message').html('The clock has stopped!')
            }
        }
    });
   
    clock.setCountdown(false);

    var estado = $('#ContentPlaceHolder1_txtValorEstado').val();

    if (estado == 2)
    {
        clock.stop();
    }
    else
    {
        clock.start();
    }
});