using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_CargarPolizas : System.Web.UI.Page
{
    Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();
    Utils cargarDatos = new Utils();
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();
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
            cargarDatos.importar(FilePath, Extension, rbHDR.SelectedItem.Text, GridCargas);
        }
    }

    private void RecorrerCarga()
    {
        Renovaciones.renovaciones_polizas insertar = new Renovaciones.renovaciones_polizas();

        foreach (GridViewRow row in GridCargas.Rows)
        {
            try
            {
                insertar.ramo = Convert.ToInt32(row.Cells[0].Text);
                insertar.poliza = row.Cells[1].Text;
                insertar.cod_aseg = row.Cells[2].Text;
                insertar.asegurado = row.Cells[3].Text;
                insertar.vigf = Convert.ToDateTime(row.Cells[4].Text);
                insertar.marca = row.Cells[5].Text;
                insertar.modelo = row.Cells[6].Text;
                insertar.tipo_vehiculo = row.Cells[7].Text;
                insertar.pasajeros = Convert.ToInt32(row.Cells[8].Text);
                insertar.tarifa = Convert.ToInt32(row.Cells[9].Text);
                insertar.placa = row.Cells[10].Text;
                insertar.motor = row.Cells[11].Text;
                insertar.chasis = row.Cells[12].Text;
                insertar.telefono1 = row.Cells[13].Text;
                insertar.telefono2 = row.Cells[14].Text;
                insertar.telefono3 = row.Cells[15].Text;
                insertar.telefono4 = row.Cells[16].Text;
                insertar.sin_incurrido = Convert.ToDecimal(row.Cells[17].Text);
                insertar.prima_pendiente = Convert.ToDecimal(row.Cells[18].Text);
                insertar.porc_siniestralidad = Convert.ToDecimal(row.Cells[19].Text);
                insertar.porc_desc_pol = Convert.ToInt32(row.Cells[20].Text);
                insertar.porc_regc_pol = Convert.ToInt32(row.Cells[21].Text);
                insertar.porc_regc_sin = Convert.ToInt32(row.Cells[22].Text);
                insertar.porc_recg_m1821 = Convert.ToInt32(row.Cells[23].Text);
                insertar.porc_recg_m1618 = Convert.ToInt32(row.Cells[24].Text);
                insertar.porc_bonif = Convert.ToInt32(row.Cells[25].Text);
                insertar.monto_bonif = Convert.ToDecimal(row.Cells[26].Text);
                insertar.suma_aseg_vence = Convert.ToDecimal(row.Cells[27].Text);
                insertar.suma_aseg_renov = Convert.ToDecimal(row.Cells[28].Text);
                insertar.deduc_danos = Convert.ToInt32(row.Cells[29].Text);
                insertar.deduc_min_danos = Convert.ToInt32(row.Cells[30].Text);
                insertar.deduc_robo = Convert.ToInt32(row.Cells[31].Text);
                insertar.deduc_min_robo = Convert.ToInt32(row.Cells[32].Text);
                insertar.prima_neta_vence = Convert.ToDecimal(row.Cells[33].Text);
                insertar.prima_neta_renov = Convert.ToDecimal(row.Cells[34].Text);
                insertar.prima_menos_bonif = Convert.ToDecimal(row.Cells[35].Text);
                insertar.prima_minima_renov = Convert.ToDecimal(row.Cells[36].Text);
                insertar.asisto_vence = Convert.ToDecimal(row.Cells[37].Text);
                insertar.asisto_renova = Convert.ToDecimal(row.Cells[38].Text);
                insertar.asistencia_fun = Convert.ToInt32(row.Cells[39].Text);
                insertar.beneficiario = Convert.ToInt32(row.Cells[40].Text);
                insertar.pagos = Convert.ToInt16(row.Cells[41].Text);
                insertar.monto_por_pago = Convert.ToDecimal(row.Cells[42].Text);
                insertar.prima_anual = Convert.ToDecimal(row.Cells[43].Text);
                insertar.forma_pago = row.Cells[44].Text;
                insertar.cod_pagador = Convert.ToInt32(row.Cells[45].Text);
                insertar.nombre_pagador = row.Cells[46].Text;
                insertar.gastos_emision = Convert.ToDecimal(row.Cells[47].Text);
                insertar.recargo_por_frac = Convert.ToDecimal(row.Cells[48].Text);
                insertar.valor_iva = Convert.ToDecimal(row.Cells[49].Text);
                insertar.confirmar = row.Cells[50].Text;
                insertar.cob_may18_men_25_anos = row.Cells[51].Text;
                insertar.cob_may16_men_18_anos = row.Cells[52].Text;
                insertar.cob_may16 = row.Cells[53].Text;
                insertar.endoso_renov = Convert.ToInt32(row.Cells[54].Text);
                insertar.correo = row.Cells[55].Text;
                insertar.dpi = row.Cells[56].Text;
                insertar.direccion_cobro = row.Cells[57].Text;
                insertar.pasaporte = row.Cells[58].Text;
                insertar.nit = row.Cells[59].Text;
                String nombre = HttpUtility.HtmlDecode(Convert.ToString(row.Cells[60].Text));
                DBRenovaciones.renovaciones_polizas.Add(insertar);
                DBRenovaciones.SaveChanges();
            }

            catch(Exception ex)
            {
                Utils.ShowMessage(this.Page, "No se pudieron insertar los datos " + ex.Message.ToString() , "ERROR","error");
            }
        }
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        RecorrerCarga();
    }
}