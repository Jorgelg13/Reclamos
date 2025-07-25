using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdCargas_CargarAutos : System.Web.UI.Page
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils cargarDatos = new Utils();
    Dictionary<string, string> marcas = new Dictionary<string, string>();
    Dictionary<string, string> aseguradoras = new Dictionary<string, string>();
    Dictionary<string, string> tipoVehiculos = new Dictionary<string, string>();
    Dictionary<string, string> tipoUsos = new Dictionary<string, string>();
    string userlogin = HttpContext.Current.User.Identity.Name;
    protected void Page_Load(object sender, EventArgs e)
    {
        marcas.Add("1307", "ACCU");
        marcas.Add("1308", "ACRO");
        marcas.Add("1", "ACURA");
        marcas.Add("1309", "ADMIRAL");
        marcas.Add("1310", "AJAX");
        marcas.Add("1311", "ALFA");
        marcas.Add("3", "ALFA ROMEO");
        marcas.Add("1312", "ALLIED");
        marcas.Add("1313", "AMG");
        marcas.Add("1314", "APOLO");
        marcas.Add("55", "APRILIA");
        marcas.Add("1315", "ASIA");
        marcas.Add("1316", "ASIA HERO");
        marcas.Add("1317", "ASTA");
        marcas.Add("4", "ASTON MARTIN");
        marcas.Add("2", "AUDI");
        marcas.Add("1060", "AUTOBUS");
        marcas.Add("1318", "AVANTI");
        marcas.Add("1319", "AVILA");
        marcas.Add("1320", "AZTEC");
        marcas.Add("58", "BAJAJ");
        marcas.Add("1321", "BASHAN");
        marcas.Add("60", "BENELLI");
        marcas.Add("1322", "BERTOLINI");
        marcas.Add("1323", "BLUE BIRD");
        marcas.Add("1324", "BMC");
        marcas.Add("7", "BMW");
        marcas.Add("1325", "BMX");
        marcas.Add("1326", "BOBCAT");
        marcas.Add("1327", "BUD");
        marcas.Add("6", "BUICK");
        marcas.Add("1328", "BUSCHOG");
        marcas.Add("1329", "BUSH-HOG");
        marcas.Add("1330", "BUTLER");
        marcas.Add("1331", "BYD");
        marcas.Add("9", "CADILLAC");
        marcas.Add("1332", "CAN-AM ROADSTER");
        marcas.Add("1333", "CASE");
        marcas.Add("1064", "CATERPILLAR");
        marcas.Add("1334", "CAYTRASA");
        marcas.Add("1335", "CFMOTO");
        marcas.Add("1336", "CHALLENGER");
        marcas.Add("1337", "CHANA");
        marcas.Add("1065", "CHANGAN");
        marcas.Add("1338", "CHEROKEE");
        marcas.Add("1339", "CHERRY");
        marcas.Add("13", "CHEVROLET");
        marcas.Add("11", "CHRYSLER");
        marcas.Add("1340", "CISTERNA");
        marcas.Add("1341", "CITROEN");
        marcas.Add("1342", "CMC");
        marcas.Add("1343", "COMANDO");
        marcas.Add("1344", "COMET");
        marcas.Add("1345", "COVET");
        marcas.Add("1346", "DAEWOO");
        marcas.Add("1347", "DAIHATSU");
        marcas.Add("1348", "DAINLER BENZ");
        marcas.Add("1349", "DATSUN");
        marcas.Add("16", "DFSK");
        marcas.Add("14", "DINA");
        marcas.Add("15", "DODGE");
        marcas.Add("1350", "DONGFENG");
        marcas.Add("1351", "DORSEY");
        marcas.Add("72", "DUCATI");
        marcas.Add("1352", "DUMPER");
        marcas.Add("1353", "DUNH");
        marcas.Add("1354", "DUNHAM");
        marcas.Add("1355", "EAGER BEAVER");
        marcas.Add("1356", "EAGLE");
        marcas.Add("1357", "EIK");
        marcas.Add("1358", "ELGIN PELICAN");
        marcas.Add("1359", "EZGO");
        marcas.Add("23", "FAW");
        marcas.Add("20", "FERRARI");
        marcas.Add("22", "FIAT");
        marcas.Add("1360", "FLEXI-VAN");
        marcas.Add("1361", "FLOW BOY");
        marcas.Add("1362", "FONTAINE");
        marcas.Add("19", "FORD");
        marcas.Add("1363", "FORLAND");
        marcas.Add("1364", "FREEDOM");
        marcas.Add("1074", "FREIGHTLINER");
        marcas.Add("1365", "FRUEHAUF");
        marcas.Add("1366", "FURGON");
        marcas.Add("1367", "FUSO");
        marcas.Add("1368", "FUTIAN");
        marcas.Add("1369", "GEELY");
        marcas.Add("1370", "GENESIS");
        marcas.Add("1371", "GENSET");
        marcas.Add("1372", "GEO");
        marcas.Add("1373", "GINDY");
        marcas.Add("1374", "GMC");
        marcas.Add("1375", "GOLDEN DRAGON");
        marcas.Add("1376", "GONOW");
        marcas.Add("1377", "GONZALES");
        marcas.Add("1378", "GREAT DANE");
        marcas.Add("1379", "GREAT WALL");
        marcas.Add("1380", "GSCR");
        marcas.Add("1381", "HAFEI");
        marcas.Add("1382", "HAOJUE");
        marcas.Add("75", "HARLEY-DAVIDSON");
        marcas.Add("76", "HARTFORD");
        marcas.Add("1383", "HAUF");
        marcas.Add("1384", "HERCULES");
        marcas.Add("1385", "HERO");
        marcas.Add("1386", "HIGHWAY");
        marcas.Add("1080", "HINO");
        marcas.Add("1387", "HOBBS");
        marcas.Add("1388", "HOMEMADE");
        marcas.Add("27", "HONDA");
        marcas.Add("1389", "HOWO");
        marcas.Add("29", "HUMMER");
        marcas.Add("80", "HUSQVARNA");
        marcas.Add("1390", "HYSTER");
        marcas.Add("28", "HYUNDAI");
        marcas.Add("30", "INFINITI");
        marcas.Add("1391", "INTERNACIONAL");
        marcas.Add("31", "INTERNATIONAL");
        marcas.Add("33", "ISUZU");
        marcas.Add("84", "ITALIKA");
        marcas.Add("32", "IVECO");
        marcas.Add("34", "JAC");
        marcas.Add("36", "JAGUAR");
        marcas.Add("35", "JEEP");
        marcas.Add("1393", "JIALING");
        marcas.Add("1394", "JIMBEI");
        marcas.Add("1082", "JMC");
        marcas.Add("1395", "JOBBS");
        marcas.Add("1396", "JOHN DEERE");
        marcas.Add("1397", "JOHNSTON");
        marcas.Add("1398", "KAISER");
        marcas.Add("1399", "KARI KOOL");
        marcas.Add("87", "KAWASAKI");
        marcas.Add("1083", "KENWORTH");
        marcas.Add("1084", "KIA");
        marcas.Add("1400", "KIDRON");
        marcas.Add("1401", "KINLON");
        marcas.Add("1402", "KOMATSU");
        marcas.Add("1403", "KORANDO");
        marcas.Add("90", "KTM");
        marcas.Add("91", "KYMCO");
        marcas.Add("40", "LAND ROVER");
        marcas.Add("1404", "LEDWELL");
        marcas.Add("43", "LEXUS");
        marcas.Add("93", "LIFAN");
        marcas.Add("1405", "LINMAX");
        marcas.Add("1406", "LIONCEL");
        marcas.Add("1407", "LIV EMBOLDEN");
        marcas.Add("1408", "LML");
        marcas.Add("1409", "LOADCRAFT");
        marcas.Add("1410", "LONCIN");
        marcas.Add("1411", "LOW BOY");
        marcas.Add("1412", "LUFKIN");
        marcas.Add("1413", "LUFQUIN");
        marcas.Add("1087", "MACK");
        marcas.Add("1414", "MAGIRUZ");
        marcas.Add("1415", "MAHINDRA");
        marcas.Add("1416", "MARCK");
        marcas.Add("114", "MASERATI");
        marcas.Add("1417", "MASSEY");
        marcas.Add("1418", "MAXUS");
        marcas.Add("44", "MAZDA");
        marcas.Add("1419", "MERCEDES");
        marcas.Add("116", "MERCEDES BENZ");
        marcas.Add("115", "MERCURY");
        marcas.Add("1420", "METAGRO");
        marcas.Add("1421", "MILLER");
        marcas.Add("1422", "MILWAUKEE");
        marcas.Add("53", "MINI");
        marcas.Add("1423", "MINI COOPER");
        marcas.Add("48", "MITSUBISHI");
        marcas.Add("1425", "MONON");
        marcas.Add("1426", "MORGAN PLUS");
        marcas.Add("1427", "MOVESA");
        marcas.Add("1428", "NAVISTAR");
        marcas.Add("117", "NISSAN");
        marcas.Add("1429", "OPEL");
        marcas.Add("1430", "OSHKOSH");
        marcas.Add("1431", "OTTAWA");
        marcas.Add("1432", "PENDIENTE");
        marcas.Add("1433", "PETER");
        marcas.Add("1093", "PETERBILT");
        marcas.Add("99", "PEUGEOT");
        marcas.Add("100", "PIAGGIO");
        marcas.Add("1434", "PINES");
        marcas.Add("1435", "PIPA");
        marcas.Add("1436", "PIPATANQUE");
        marcas.Add("1437", "PLYMOUTH");
        marcas.Add("101", "POLARIS");
        marcas.Add("129", "PONTIAC");
        marcas.Add("124", "PORSCHE");
        marcas.Add("1438", "PORTA CONTENEDOR");
        marcas.Add("1439", "QLINK");
        marcas.Add("1440", "RAMIREZ");
        marcas.Add("1441", "RANGE ROVER");
        marcas.Add("1442", "REGUA");
        marcas.Add("144", "RENAULT");
        marcas.Add("1443", "RETESA");
        marcas.Add("1444", "RIVAS");
        marcas.Add("1445", "ROBECA");
        marcas.Add("167", "ROVER");
        marcas.Add("1446", "RSM");
        marcas.Add("1447", "S/M");
        marcas.Add("1448", "SACHS MOPEDS");
        marcas.Add("1449", "SANYANG");
        marcas.Add("1450", "SATURN");
        marcas.Add("1451", "SCHWING");
        marcas.Add("1452", "SCION");
        marcas.Add("1453", "SCOTT GENIUS");
        marcas.Add("150", "SEAT");
        marcas.Add("1454", "SERVIMETAL");
        marcas.Add("1455", "SHINERAY");
        marcas.Add("1456", "SHOALS");
        marcas.Add("1457", "SIN MARCA");
        marcas.Add("1458", "SINSKI");
        marcas.Add("1459", "SKODA");
        marcas.Add("1460", "SKYGO");
        marcas.Add("1461", "SLOWING");
        marcas.Add("149", "SMART");
        marcas.Add("1462", "SSANG YONG");
        marcas.Add("1105", "SSANGYONG");
        marcas.Add("147", "STERLING");
        marcas.Add("1463", "STEYR PUCH");
        marcas.Add("1464", "STOUGHTON");
        marcas.Add("1465", "STRICK");
        marcas.Add("1466", "STRICK 1S1 TRAILER");
        marcas.Add("1467", "STRICK TRAILER");
        marcas.Add("151", "SUBARU");
        marcas.Add("1468", "SUKIDA");
        marcas.Add("103", "SUZUKI,");
        marcas.Add("1469", "THEURER");
        marcas.Add("1470", "TI BOOK");
        marcas.Add("1471", "TITAN");
        marcas.Add("139", "TOYOTA");
        marcas.Add("1472", "TRAILMASTER TANK");
        marcas.Add("1473", "TRAILMOBILE");
        marcas.Add("1474", "TRANSGLOBAL");
        marcas.Add("1475", "TRAVIS");
        marcas.Add("1476", "TRITON");
        marcas.Add("105", "TRIUMPH");
        marcas.Add("106", "TVS");
        marcas.Add("1477", "UD NISSAN");
        marcas.Add("1479", "UNITED MOTORS");
        marcas.Add("1480", "UTILITY");
        marcas.Add("1481", "UTILITY FURGON");
        marcas.Add("1482", "VANCO");
        marcas.Add("1483", "VANTAGE");
        marcas.Add("108", "VENTO");
        marcas.Add("1484", "VIKING");
        marcas.Add("1485", "VILLAGER 8");
        marcas.Add("137", "VOLKSWAGEN");
        marcas.Add("158", "VOLVO");
        marcas.Add("1486", "VORTEX");
        marcas.Add("1487", "VS2RA");
        marcas.Add("1488", "WABASH");
        marcas.Add("1489", "WANFENG");
        marcas.Add("1490", "WARREN");
        marcas.Add("1114", "WHITE");
        marcas.Add("1491", "WHITE GMC");
        marcas.Add("1492", "WULING");
        marcas.Add("1493", "XRT 1550 SE");
        marcas.Add("111", "YAMAHA");
        marcas.Add("1494", "YUMBO");
        marcas.Add("1495", "ZUKYAMA");
        marcas.Add("1496", "ZX");

        aseguradoras.Add("98681", "Afianzadora G&t, S. a.");
        aseguradoras.Add("98665", "Afianzadora Guatemalteca, S. a.");
        aseguradoras.Add("98699", "Afianzadora Solidaria, S.a.");
        aseguradoras.Add("98668", "Aig");
        aseguradoras.Add("98669", "Aig Delam");
        aseguradoras.Add("98689", "Aseguradora Confío, S. a.");
        aseguradoras.Add("98702", "Aseguradora De Los Trabajadores, S. a.");
        aseguradoras.Add("98684", "Aseguradora Fidelis, S. a.");
        aseguradoras.Add("98685", "Aseguradora General, S. a.");
        aseguradoras.Add("98667", "Aseguradora Guatemalteca, Sociedad Anonima");
        aseguradoras.Add("98674", "Aseguradora La Ceiba, S. a.");
        aseguradoras.Add("98682", "Aseguradora Solidum, S. a.");
        aseguradoras.Add("98670", "Asistencia Integral");
        aseguradoras.Add("98706", "Asistencia Quetzal");
        aseguradoras.Add("98703", "Assa Compañía De Seguros, S. a.");
        aseguradoras.Add("98671", "Atlantic");
        aseguradoras.Add("98672", "Bmi Compañía De Seguros De Guatemala, S. a.");
        aseguradoras.Add("98673", "Bupa Guatemala, Compañía De Seguros, S. a.");
        aseguradoras.Add("98676", "Chartis Seguros Guatemala, S.a.");
        aseguradoras.Add("98708", "Columna Compañía De Seguros, S.a.");
        aseguradoras.Add("98700", "Columna, Compañía De Seguros, S. a.");
        aseguradoras.Add("98698", "Compañia De Asistencia Al Viajero De Guatemala, so");
        aseguradoras.Add("98677", "Consultores Y Corredores De Seguros, en");
        aseguradoras.Add("98707", "Continental Assist");
        aseguradoras.Add("98675", "Departamento De Seguros Y Previsión De El Crédito");
        aseguradoras.Add("98679", "Durs");
        aseguradoras.Add("98683", "Fianzas El Roble, S. a.");
        aseguradoras.Add("98697", "Ficohsa Seguros, S. a.");
        aseguradoras.Add("98686", "Hono");
        aseguradoras.Add("98687", "Jarquin Y Cía. Ltda. En Nicaragua");
        aseguradoras.Add("98688", "Mapfre | Seguros Guatemala, S. a.");
        aseguradoras.Add("98690", "PaN-American Life Insurance De Guatemala, Compañía");
        aseguradoras.Add("98704", "Ros");
        aseguradoras.Add("98666", "Seguros Agromercantil, S. a.");
        aseguradoras.Add("98692", "Seguros Del Pais, S.a.");
        aseguradoras.Add("98691", "Seguros El Roble, S. a.");
        aseguradoras.Add("98694", "Seguros G&t, S. a.");
        aseguradoras.Add("98680", "Seguros Privanza, S. a.");
        aseguradoras.Add("98696", "Seguros Universales, S. a.");
        aseguradoras.Add("98695", "Unity - Costa Rica /wtw Costa Rica");
        aseguradoras.Add("98701", "Unity – Inverseguros Nicaragua/wtw Nicaragua");
        aseguradoras.Add("98693", "Unity -Setessa  Wtw El Salvador");
        aseguradoras.Add("98678", "UnitY-Ducruet");
        aseguradoras.Add("98705", "Viaje Seguro");

        tipoVehiculos.Add("1", "Automovil");
        tipoVehiculos.Add("2", "Camión");
        tipoVehiculos.Add("3", "Motocicleta");
        tipoVehiculos.Add("72", "Agrícola 4x2");
        tipoVehiculos.Add("73", "Agrícola 4x4");
        tipoVehiculos.Add("53", "Autobús");
        tipoVehiculos.Add("74", "Bicicleta");
        tipoVehiculos.Add("42", "Bus");
        tipoVehiculos.Add("21", "Cabezal");
        tipoVehiculos.Add("17", "Camioneta");
        tipoVehiculos.Add("75", "Camioneta 4x2");
        tipoVehiculos.Add("76", "Camioneta 4x4");
        tipoVehiculos.Add("77", "Camioneta Sport");
        tipoVehiculos.Add("78", "Camionetilla");
        tipoVehiculos.Add("79", "Carro Funerario");
        tipoVehiculos.Add("20", "Cisterna");
        tipoVehiculos.Add("80", "Cuatrimoto");
        tipoVehiculos.Add("18", "Furgon");
        tipoVehiculos.Add("8", "Jeep");
        tipoVehiculos.Add("81", "Jeep 4x2");
        tipoVehiculos.Add("82", "Jeep 4x4");
        tipoVehiculos.Add("83", "Low Boy");
        tipoVehiculos.Add("84", "Maquinaria");
        tipoVehiculos.Add("11", "Microbús");
        tipoVehiculos.Add("12", "Microbús hasta 12 p.");
        tipoVehiculos.Add("68", "Microbús más 12 p.");
        tipoVehiculos.Add("10", "Mini Van");
        tipoVehiculos.Add("24", "Montacargas");
        tipoVehiculos.Add("69", "Motocarro");
        tipoVehiculos.Add("38", "Panel");
        tipoVehiculos.Add("50", "Pick Up");
        tipoVehiculos.Add("85", "Pick Up 4x4");
        tipoVehiculos.Add("34", "Pick-Up hasta 1 ton.");
        tipoVehiculos.Add("6", "Pick Up 4x2");
        tipoVehiculos.Add("52", "Pick-Up más 1 ton.");
        tipoVehiculos.Add("86", "Pipa");
        tipoVehiculos.Add("25", "Plataforma");
        tipoVehiculos.Add("87", "Porta contenedor");
        tipoVehiculos.Add("88", "Remolque");
        tipoVehiculos.Add("89", "Semiremolque");
        tipoVehiculos.Add("36", "Tractor");
        tipoVehiculos.Add("90", "Transporte de carga");

        tipoUsos.Add("1", "Particular");
        tipoUsos.Add("2", "Misión Internacional");
        tipoUsos.Add("3", "Taxi");
        tipoUsos.Add("4", "Uber");
        tipoUsos.Add("5", "Comercial");
        tipoUsos.Add("6", "Carga");
        tipoUsos.Add("7", "Público Remunerado");
        tipoUsos.Add("8", "Otros");
        tipoUsos.Add("9", "Motocicleta");

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (Archivo.HasFile)
        {
            string FileName = Path.GetFileName(Archivo.PostedFile.FileName);
            string Extension = Path.GetExtension(Archivo.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string FilePath = Server.MapPath(FolderPath + FileName);
            Archivo.SaveAs(FilePath);
            cargarDatos.importar2(FilePath, Extension, rbHDR.SelectedItem.Text, GridCargas);
        }
    }

    private string buscarAseguradora(string clave)
    {
        string aseguradora;
        if (aseguradoras.ContainsKey(clave))
        {
            return aseguradora = aseguradoras[clave];
        }
        else
        {
            return "";
        }
    }

    private string buscarMarca(string clave)
    {
        string marca;
        if (marcas.ContainsKey(clave))
        {
           return marca = marcas[clave];
        }
        else
        {
            return "";
        }
    }

    private string buscarTipoVehiculo(string clave)
    {
        string tipo;
        if (tipoVehiculos.ContainsKey(clave))
        {
            return tipo = tipoVehiculos[clave];
        }
        else
        {
            return "";
        }
    }

    private string buscarTipoUso(string clave)
    {
        string tipoUso;
        if (tipoUsos.ContainsKey(clave))
        {
            return tipoUso = tipoUsos[clave];
        }
        else
        {
            return "";
        }
    }

    private void RecorrerCarga()
    {

        foreach (GridViewRow row in GridCargas.Rows)
        {
            try
            {
                string chasis = row.Cells[5].Text.Trim().Replace("/t","");
                var autoRegistrado = DBReclamos.ViewBusquedaAuto.Where(a => a.chasis == chasis).FirstOrDefault();
                if (autoRegistrado != null)
                {
                    autoRegistrado.contratante = row.Cells[0].Text;
                    autoRegistrado.asegurado = row.Cells[0].Text;
                    autoRegistrado.tipo_vehiculo = buscarTipoVehiculo(row.Cells[1].Text);
                    autoRegistrado.cod_tipo_vehiculo = row.Cells[1].Text;
                    autoRegistrado.marca = buscarMarca(row.Cells[2].Text);
                    autoRegistrado.cod_marca = row.Cells[2].Text;
                    autoRegistrado.modelo = row.Cells[4].Text;
                    autoRegistrado.chasis = row.Cells[5].Text;
                    autoRegistrado.placa = row.Cells[6].Text.Trim();
                    autoRegistrado.valorauto = row.Cells[7].Text;
                    autoRegistrado.uso_vehiculo = buscarTipoUso(row.Cells[8].Text);
                    autoRegistrado.cod_uso_vehiculo = row.Cells[8].Text;
                    autoRegistrado.vigi = Convert.ToDateTime(row.Cells[9].Text);
                    autoRegistrado.vigf = Convert.ToDateTime(row.Cells[10].Text);
                    autoRegistrado.nombre = buscarAseguradora(row.Cells[11].Text);
                    autoRegistrado.cod_aseguradora = row.Cells[11].Text;
                    autoRegistrado.poliza = row.Cells[12].Text;
                    autoRegistrado.gst_nombre = row.Cells[13].Text;
                    autoRegistrado.estado_vehiculo = row.Cells[14].Text;
                    autoRegistrado.ramo = "2";
                    autoRegistrado.usuario_carga = userlogin;
                    autoRegistrado.fecha_carga = DateTime.Now;

                    DBReclamos.SaveChanges();
                    row.CssClass = "success";
                    Utils.ShowMessage(this.Page, "Datos Cargados con exito", "Excelente", "success");
                }

                else
                {
                    ViewBusquedaAuto auto = new ViewBusquedaAuto();

                    auto.contratante = row.Cells[0].Text;
                    auto.asegurado = row.Cells[0].Text;
                    auto.tipo_vehiculo = buscarTipoVehiculo(row.Cells[1].Text);
                    auto.cod_tipo_vehiculo = row.Cells[1].Text;
                    auto.marca = buscarMarca(row.Cells[2].Text);
                    auto.cod_marca = row.Cells[2].Text;
                    auto.modelo = row.Cells[4].Text;
                    auto.chasis = row.Cells[5].Text;
                    auto.placa = row.Cells[6].Text.Trim();
                    auto.valorauto = row.Cells[7].Text;
                    auto.uso_vehiculo = buscarTipoUso(row.Cells[8].Text);
                    auto.cod_uso_vehiculo = row.Cells[8].Text;
                    auto.vigi = Convert.ToDateTime(row.Cells[9].Text);
                    auto.vigf = Convert.ToDateTime(row.Cells[10].Text);
                    auto.nombre = buscarAseguradora(row.Cells[11].Text);
                    auto.cod_aseguradora = row.Cells[11].Text;
                    auto.poliza = row.Cells[12].Text;
                    auto.gst_nombre = row.Cells[13].Text;
                    auto.estado_vehiculo = row.Cells[14].Text;
                    auto.ramo = "2";
                    auto.usuario_carga = userlogin;
                    auto.fecha_carga = DateTime.Now;
                    DBReclamos.ViewBusquedaAuto.Add(auto);
                    DBReclamos.SaveChanges();
                    row.CssClass = "success";
                    Utils.ShowMessage(this.Page, "Datos Cargados con exito", "Excelente", "success");
                }
            }

            catch (Exception ex)
            {
                row.CssClass = "danger";
                Utils.ShowMessage(this.Page, "No se pudieron insertar los datos " + ex.Message.ToString(), "ERROR", "error");
            }
        }
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        RecorrerCarga();
    }

    private async void ocultarColumnas()
    {
        GridCargas.Columns.RemoveAt(0);
    }
}