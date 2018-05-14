function enviarImagen() {
    $.post("http://52.34.115.100:9595/api/v1/envioColectivos/" + parseInt($('#lblId').text()), { imagen: signaturePad.toDataURL() })
        .done(function () {
            setTimeout(
                function () {
                    toastr.success('Formulario enviado con exito', 'Excelente!');
                }, 200);
        })
        .fail(function () {
            setTimeout(
                function () {
                    toastr.error('No se a podido enviar el formulario', 'Error!');
                }, 200);
        });
}
