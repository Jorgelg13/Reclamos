<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbGastosMedicos.aspx.cs" Inherits="Modulos_MdScanner_wbGastosMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Scanear Documentos</title>
</head>
<body style="background-color: #48086f;">
    <form id="form1" runat="server">
        <div id="dwtcontrolContainer"></div>
        <br />
        <br />
        <fieldset style="color: white;">
            <legend>Elija el archivo que desea escanear</legend>
            <input type="radio" name="tipo" value="Expedientes" checked="checked" />Expedientes<br />
            <input type="radio" name="tipo" value="Complementos" />Complementos<br />
            <input type="radio" name="tipo" value="Liquidacion" />Liquidacion<br />
            <br />
            <input type="button" value="Escanear" onclick="AcquireImage();" />
            <input type="button" value="Guardar" onclick="UploadImage();" />
            <input type="button" value="Cargar Archivos" onclick="LoadImage();" />
        </fieldset>
        <script src="../MdReclamosUnity/Resources/dynamsoft.webtwain.initiate.js"></script>
        <script src="../MdReclamosUnity/Resources/dynamsoft.webtwain.config.js"></script>
        <script src="../../Scripts/jquery-3.1.1.min.js"></script>
        <script type="text/javascript">
            (function ($) {
                $.get = function (key) {
                    key = key.replace(/[\[]/, '\\[');
                    key = key.replace(/[\]]/, '\\]');
                    var pattern = "[\\?&]" + key + "=([^&#]*)";
                    var regex = new RegExp(pattern);
                    var url = unescape(window.location.href);
                    var results = regex.exec(url);
                    if (results === null) {

                        return null;
                    } else {
                        return results[1];
                    }
                }
            })(jQuery);
            var valor = $.get("id");

            var console = window['console'] ? window['console'] : { 'log': function () { } };
            Dynamsoft.WebTwainEnv.RegisterEvent('OnWebTwainReady', Dynamsoft_OnReady); // Register OnWebTwainReady event. This event fires as soon as Dynamic Web TWAIN is initialized and ready to be used

            function Dynamsoft_OnReady() {
                DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer'); // Get the Dynamic Web TWAIN object that is embeded in the div with id 'dwtcontrolContainer'
                if (DWObject) {
                    DWObject.RegisterEvent('OnPostAllTransfers', SaveWithFileDialog);
                }
            }

            //Callback functions for async APIs
            function OnSuccess() {
                console.log('successful');
            }

            function OnFailure(errorCode, errorString) {
                alert(errorString);
            }

            function LoadImage() {
                if (DWObject) {
                    DWObject.IfShowFileDialog = true; // Open the system's file dialog to load image
                    DWObject.LoadImageEx("", EnumDWT_ImageType.IT_ALL, OnSuccess, OnFailure); // Load images in all supported formats (.bmp, .jpg, .tif, .png, .pdf). OnSuccess or OnFailure will be called after the operation
                }
            }

            var DWObject;
            function AcquireImage() {
                DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
                DWObject.IfDisableSourceAfterAcquire = true;
                DWObject.SelectSource();
                DWObject.OpenSource();
                DWObject.AcquireImage();
            }

            function OnHttpUploadSuccess() {
                console.log('successful');
                window.close();
            }
            function OnHttpUploadFailure(errorCode, errorString, sHttpResponse) {
                alert(errorString + sHttpResponse);
            }

            function UploadImage() {
                if (DWObject) {
                    if (DWObject.HowManyImagesInBuffer == 0)
                        return;

                    var server = "reclamosgt.unitypromotores.com"; 
                   // var server = "http://localhost:4000";
                    var pagina = "/Modulos/MdScanner/GuardarArchivoRM.aspx";
                    DWObject.IfSSL = true;
                    DWObject.HTTPPort = 443;
                    var archivo = $('input:radio[name=tipo]:checked').val();
                    DWObject.HTTPUploadAllThroughPostAsPDF(server, pagina, archivo + ".pdf", OnHttpUploadSuccess, OnHttpUploadFailure);
                }
            }
        </script>
    </form>
</body>
</html>
