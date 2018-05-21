function abrirDetallePoliza() {
     $ramo = $('.inputTxtRamo').val();
     if (parseInt($ramo) === 2) {
         $('.cuerpo-autos').removeClass('ocultar-cuerpo');
         $('.cuerpo-danos').addClass('ocultar-cuerpo');
       
    } else {
         $('.cuerpo-autos').addClass('ocultar-cuerpo');
         $('.cuerpo-danos').removeClass('ocultar-cuerpo');
     }

    $('#modalDetallePoliza').modal('show');
}

$(document).ready(function () {

    var getUrlParameter = function getUrlParameter(sParam) {
        var sPageURL = decodeURIComponent(window.location.search.substring(1)),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }
    };

    $('.home').click(function () {
        $.cookie('tab', 'home');
    });

    $('.coberturas').click(function () {
        $.cookie('tab', 'coberturas');
    });

    $('.profile').click(function () {
        $.cookie('tab', 'profile');
    });

    $('.ingreso-datos').click(function () {
        $.cookie('tab', 'ingreso-datos');
    });


    // funcion para mantener la pantalla en el mismo tab 
    setTimeout(function () {
        var tab = $.cookie('tab');
        $('.home').removeClass('active');
        $('#home').removeClass('active');
        $('.coberturas').removeClass('active');
        $('#coberturas').removeClass('active');
        $('.profile').removeClass('active');
        $('#profile').removeClass('active');
        $('.ingreso-datos').removeClass('active');
        $('#ingreso-datos').removeClass('active');

        if (tab) {
            $('#' + tab).addClass('active');
            $('.' + tab).addClass('active');
        } else {
            $('#home').addClass('active');
            $('.home').addClass('active');
        }
        
    }, 500);
});

//funcion para mostrar el editor de texto de las cartas
$(document).ready(function () {

    if ($('#ContentPlaceHolder1_chCartaCierre')[0].checked && $('#ContentPlaceHolder1_lblBanderaCierreInterno').text() == 'True') {
        $('#summernote').html($('#ContentPlaceHolder1_lblcarta').html());
    }
    else {
        $('#summernote').html($('#MemosReclamos').html());
    }

    if ($('#ContentPlaceHolder1_chCartaDeclinado')[0].checked && $('#ContentPlaceHolder1_lblBanderaDeclinado').text() == 'True') {
        $('#summernote').html($('#ContentPlaceHolder1_lblcarta').html());
    }
    else {
        $('#summernote').html($('#MemosReclamos').html());
    }

    if ($('#ContentPlaceHolder1_chEnvioCarta')[0].checked && $('#ContentPlaceHolder1_lblBanderaEnvioCheque').text() == 'True') {
        $('#summernote').html($('#ContentPlaceHolder1_lblcarta').html());
    }
    else {
        $('#summernote').html($('#MemosReclamos').html());
    }
    try {
        $('#summernote').summernote();
    }
    catch ($ex) {

    }
});


//funcion para enviar correo electronico
function enviarCorreo()
{
   var body = $('#ContentPlaceHolder1_txtMensaje').val();
   console.log(body); 
   var body2 = body.replace('\n\n', '%0a');
   var to = $('#ContentPlaceHolder1_txtDestinatario').val();
   var asunto = $('#ContentPlaceHolder1_txtAsunto').val();
   window.open('https://outlook.office.com/owa/?path=/mail/action/compose&to='+to+'&subject='+asunto+'&body='+body2+'');
}

//funcion para enviar notificaciones de escritorio cuando hay mas de 1 reclamo
function notificarme()
{
    var reclamos = $('#totalReclamosAutos').html();
    var totalReclamos = parseInt(reclamos);

    if (totalReclamos > 0)
    {
        if (!("Notification" in window)) {
            alert("Este navegador no soporta notificaciones de escritorio");
        }
        else if (Notification.permission === "granted") {
            var options = {
                body: "Tienes reclamos pendientes de dar seguimiento..!",
                icon: "http://reclamosgt.unitypromotores.com/imgUnity/Unity.jpg",
                dir: "ltr",
                lang: "ES",
                timeout: 50000
            };
            var notification = new Notification("Sistema De Reclamos Unity..", options);
            var audio = new Audio("http://reclamosgt.unitypromotores.com/imgUnity/notificacion.mp3");

            notification.onclick = function () {
                window.open("http://reclamosgt.unitypromotores.com/DashboardCabina.aspx");
                this.close();
            }

            audio.play();

        }
        else if (Notification.permission !== 'denied') {
            Notification.requestPermission(function (permission) {
                if (!('permission' in Notification)) {
                    Notification.permission = permission;
                }
                if (permission === "granted") {
                    var options = {
                        body: "Descripción o cuerpo de la notificación",
                        icon: "url_del_icono.jpg",
                        dir: "ltr"
                    };
                    var notification = new Notification("Hola :)", options);
                }
            });
        }
    }
}


function NotificacionSMS($telefono, $mensaje, $token)
{
    $.post("http://192.168.81.225:9900/movistar/enviar", {
        token: $token,
        numero: $telefono,
        mensaje: $mensaje
    }).done(function() {
        toastr.success('Se a enviado una notificacion SMS con exito al asegurado', 'Excelente..!');
    }).fail(function() {
        toastr.error('No se a podido enviar la notificacion SMS', 'Error..!');
    });
}

