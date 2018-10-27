<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbFrmFormulario.aspx.cs" Inherits="formulario_wbFrmFormulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/summernote.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toastr.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../css/GridviewScroll.css" rel="stylesheet" />
    <link href="../css/estilosFirma.css" rel="stylesheet" />
    <title>Formulario Colectivo</title>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            font-size: 12px;
            padding-left: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 115px;">
            <h2 style="width: 781px; padding-bottom: 20px;">Consentimiento de seguro colectivo</h2>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -90px; width: 235px;" />
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <br />
        <br />
        <div class="container-fluid col-lg-12 col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <b>
                        Formulario Colectivo
                    </b>
                </div>
                  <asp:Label ID="lblId" Style="display: none" runat="server"></asp:Label>
                <div class="panel-body" id="imprimir">
                    <p style="text-align: center"><b>CONSENTIMIENTO DE SEGURO COLECTIVO</b></p>
                    <p style="text-align: center"><b>ACCIDENTES PERSONALES</b></p>
                    <div class="form-group col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <label for="poliza">POLIZA No.</label>
                        <asp:TextBox ID="txtPoliza" required="true" Text="56005" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <label for="certificado">CERTIFICADO No.</label>
                        <asp:TextBox ID="txtCertificado" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-12 col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <label for="vigencia">Vigencia</label>
                        <asp:TextBox ID="txtVigencia" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <label for="contratante">CONTRATANTE</label>
                        <asp:TextBox ID="txtContratante" required="true" Text="PROMOTORES DE PROTECCION, S.A" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <p style="padding-left: 20px"><b>DATOS DEL ASEGURADO:</b></p>
                    <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <label for="nombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" required="true" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        <label style="padding-left: 60px; padding-right: 10px;">1er. Apellido</label><label style="padding-left: 20px;">2do. Apellido</label><label style="padding-left: 20px;">Apellido Casada</label><label style="padding-left: 70px;">Nombres</label>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <label for="dpi">DPI</label>
                        <asp:TextBox ID="txtDpi" required="true" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <label for="dpi">Numero de Nit</label>
                        <asp:TextBox ID="txtNit" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <label for="direccion">Direccion</label>
                        <asp:TextBox ID="txtDireccion" required="true" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <label for="telefono">Telefono</label>
                        <asp:TextBox ID="txtTelefono" required="true" type="number" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <label for="email">Email</label>
                        <asp:TextBox ID="txtEmail" Style="width: 95%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <p style="padding-left: 20px"><b>INFORMACION DEL ASEGURADO TITULAR Y DEPENDIENTES (SI SE DESEA COBERTURA PARA ELLOS)</b></p>
                    <div class="container-fluid">
                        <table style="width: 98%" class="table-responsive table-hover col-md-12 col-sm-12">
                            <tr>
                                <th></th>
                                <th>Nombre Completo</th>
                                <th>Ocupacion</th>
                                <th>Peso</th>
                                <th>Estatura</th>
                                <th>Fecha Nacimiento</th>
                            </tr>
                            <tr>
                                <td>Asegurado Titular</td>
                                <td>
                                    <asp:TextBox ID="txtNombreCompletoTitular" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtocupacionTitular" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpesoTitular" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtEstaturaTitular" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtFechaNacimientoTitular" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Conyuge</td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>Hijos</td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>.</td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                               </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>.</td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                               </td>
                                <td>
                               </td>
                            </tr>
                        </table>
                        <br />
                        <p style="padding-left: 20px"><b>BENEFICIARIOS DEL ASEGURADO TITULAR</b></p>
                        <p>Expresamente nombro como beneficiarios de los beneficios de la Póliza Colectiva a:</p>
                        <br />
                        <table style="width: 98%" class="table-responsive table-hover">
                            <tr>
                                <th>Nombre Completo</th>
                                <th>Parentesco</th>
                                <th>Porcentaje</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNombreBeneficiario1" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtParentesco1" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtPorcentaje1" required="true" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNombreBeneficiaro2" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtParentesco2" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtPorcentaje2" Style="width: 100%" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                        <br />
                        <p style="text-align: justify"><b>¿ Ha sufrido alguna vez de diabetes, enfermedades al riñón cardíacas, hipertensión arterial, enfermedades coronarias y soplos cardiacos, arritmias, obesidad con un IMC > 35 (peso/estatura), enfermedades del pulmón, cáncer, hepatitis, (excepto la A), enfermedades gastrointestinales como cirrosis hepática, úlcera gástrica, colitis, ulcerosa, enfermedades hematológicas como leucemia,linfoma, anemia (exepto por falta de hierro), desordenes nerviosos o mentales, SIDA, sindrome de Down y enfermedades neurológicas como accidentales vasculares cerebrales, epilepsia y enfermedad de Alzheimer?</b>
                            <asp:CheckBox ID="checkNo" Text="No" runat="server" /><asp:CheckBox ID="checkSi" Text="Si" runat="server" /></p>
                        <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <label for="dpi">En caso sea Afirmativo de detalles</label>
                            <asp:TextBox ID="txtDetalleEnfermedad" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <p><b>¿A su leal saber y entender, se encuentra ahora en buen estado de salud y libre de todo impedimento o deformidad fisica?
                            <asp:CheckBox ID="checkImpedimentoFisicoNo" Text="No" runat="server" /><asp:CheckBox ID="checkImpedimientoFisicoSi" Text="Si" runat="server" /><b></p>
                        <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <label for="dpi">En caso Negativo de detalles</label>
                            <asp:TextBox ID="txtDetallesImpedimemtos" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <label for="dpi">Indique que enfermedades a padecido recientemente</label>
                            <asp:TextBox ID="txtEnfermedadesRecientes" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <p><b>¿incluye en su rutina diaria, ocupación o pasatiempos alguna actividad o deporte peligroso?
                            <asp:CheckBox ID="checkActividadFisicaNo" Text="No" runat="server" /><asp:CheckBox ID="chekActividadFisicaSi" Text="Si" runat="server" /></b></p>
                        <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <label for="dpi">Especifique</label>
                            <asp:TextBox ID="txtAcitividadFisica" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <p style="text-align: justify">Expresamente declaro que la información anteriormente es verídica al momento de firmar el presente consentimiento, el cual se origina de mi solicitud para adherir a la Póliza de Seguro Colectivo de Accidentes personales arriba identificada. Asimismo, expresamente manifiesto que acepto la adhesión a la poliza en los términos y condiciones que se hacen constar en el certificado individual de Seguro</p>
                        <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <label for="lugar">Lugar y Fecha</label>
                            <asp:TextBox ID="txtLugar" required="true" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <label for="solicitante">Nombre del solicitante :</label>
                            <asp:TextBox ID="txtSolicitante" required="true" Style="width: 98%" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <h3>Firme dentro del cuadro
                        </h3>
                        <div class="wrapper" style="border:solid 1px;">
                            <canvas id="signature-pad" class="signature-pad" width="400" height="200"></canvas>
                        </div>
                        <div >
                            <button style="display:none;" id="save">Guardar</button>
                            <button id="clear">Limpiar</button>
                        </div>
                            <br />
                            <br />
                            <br />
                            <p style="text-align: justify"><b>Este texto es responsabilidad de la aseguradora y fue registrado en la Superintendencia de Bancos Resolución Número 273-2015 del 20 de marzo del 2015</b></p>
                        </div>
                        <asp:Button ID="btngGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btngGuardar_Click" />
                        <input id="btnEnviar" type="button" onclick="enviarImagen()" value="Enviar Formulario" class="btn btn-success" />
                        <asp:Button ID="btnlimpiar" CssClass="btn btn-primary" runat="server" Text="Nuevo Registro" OnClick="btnlimpiar_Click" />
                    </div>
                </div>
            </div>
        <script>
            function printDiv(imprimir) {
                var contenido = document.getElementById(imprimir).innerHTML;
                var contenidoOriginal = document.body.innerHTML;
                document.body.innerHTML = contenido;
                window.print();
                document.body.innerHTML = contenidoOriginal;
                window.location.reload(true);
            }
        </script>

        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../Scripts/signaturePad.js"></script>
        <script src="../Scripts/firma.js"></script>
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
        <script src="../Scripts/jquery.cookie.min.js"></script>
        <script src="../Scripts/toastr.min.js"></script>
        <script src="../Scripts/envioFormulario.js"></script>
    </form>
</body>
</html>
