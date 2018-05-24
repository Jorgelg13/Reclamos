<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbGastosMedicos.aspx.cs" Inherits="Modulos_MdScanner_wbGastosMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Scanear Documentos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dwtcontrolContainer"></div>
        <input type="button" value="Scan" onclick="AcquireImage();" />
        <input type="button" value="subir" onclick="UploadImage();" />

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
            }
            function OnHttpUploadFailure(errorCode, errorString, sHttpResponse) {
                alert(errorString + sHttpResponse);
            }

            function UploadImage() {
                if (DWObject) {
                    if (DWObject.HowManyImagesInBuffer == 0)
                        return;

                    var strHTTPServer = "reclamosgt.unitypromotores.com"; 
                   // var strHTTPServer = "http://localhost:4000"; 
                    var strActionPage = "/SaveToFile.aspx";
                    DWObject.IfSSL = false; 
                    DWObject.HTTPPort = 80;
                    var Digital = new Date();
                    var uploadfilename = valor; 
                    DWObject.HTTPUploadAllThroughPostAsPDF(strHTTPServer, strActionPage, uploadfilename + ".pdf", OnHttpUploadSuccess, OnHttpUploadFailure);
                }
            }
        </script>
    </form>
</body>
</html>
