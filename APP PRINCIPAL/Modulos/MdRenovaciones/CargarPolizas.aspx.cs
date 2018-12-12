using System;
using System.Configuration;
using System.IO;
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
        Renovaciones.requerimientos requerimiento = new Renovaciones.requerimientos();

        if (idRecibido == "1")
        {
            foreach (GridViewRow row in GridCargas.Rows)
            {
                try
                {
                    insertar.ramo = Convert.ToInt32(row.Cells[0].Text);
                    insertar.poliza = row.Cells[1].Text;
                    insertar.certificado = row.Cells[2].Text;
                    insertar.cod_aseg = row.Cells[3].Text;
                    insertar.asegurado = row.Cells[4].Text;
                    insertar.cod_agen = row.Cells[5].Text;
                    insertar.vigf = row.Cells[6].Text;
                    insertar.marca = row.Cells[7].Text;
                    insertar.modelo = row.Cells[8].Text;
                    insertar.tipo_vehiculo = row.Cells[9].Text;
                    insertar.pasajeros = row.Cells[10].Text;
                    insertar.tarifa = row.Cells[11].Text;
                    insertar.placa = row.Cells[12].Text;
                    insertar.motor = row.Cells[13].Text;
                    insertar.chasis = row.Cells[14].Text;
                    insertar.telefono1 = row.Cells[15].Text;
                    insertar.telefono2 = row.Cells[16].Text;
                    insertar.telefono3 = row.Cells[17].Text;
                    insertar.telefono4 = row.Cells[18].Text;
                    insertar.sin_incurrido = row.Cells[19].Text;
                    insertar.prima_pendiente = row.Cells[20].Text;
                    insertar.porc_pri_pend = row.Cells[21].Text;
                    insertar.porc_siniestralidad = row.Cells[22].Text;
                    insertar.porc_desc_pol = row.Cells[23].Text;
                    insertar.porc_regc_pol = row.Cells[24].Text;
                    insertar.porc_regc_sin = row.Cells[25].Text;
                    insertar.porc_recg_m1821 = row.Cells[26].Text;
                    insertar.porc_recg_m1618 = row.Cells[27].Text;
                    insertar.porc_bonif = row.Cells[28].Text;
                    insertar.monto_bonif = row.Cells[29].Text;
                    insertar.suma_aseg_vence = row.Cells[30].Text;
                    insertar.suma_aseg_renov = row.Cells[31].Text;
                    insertar.deduc_danos = row.Cells[32].Text;
                    insertar.deduc_min_danos = row.Cells[33].Text;
                    insertar.deduc_robo = row.Cells[34].Text;
                    insertar.deduc_min_robo = row.Cells[35].Text;
                    insertar.prima_neta_vence = row.Cells[36].Text;
                    insertar.prima_neta_renov = row.Cells[37].Text;
                    insertar.prima_menos_bonif = row.Cells[38].Text;
                    insertar.prima_minima_renov = row.Cells[39].Text;
                    insertar.asisto_vence = row.Cells[40].Text;
                    insertar.asisto_renova = row.Cells[41].Text;
                    insertar.asistencia_fun = row.Cells[42].Text;
                    insertar.beneficiario = row.Cells[43].Text;
                    insertar.pagos = row.Cells[44].Text;
                    insertar.monto_por_pago = row.Cells[45].Text;
                    insertar.prima_anual = row.Cells[46].Text;
                    insertar.forma_pago = row.Cells[47].Text;
                    insertar.cod_pagador = row.Cells[48].Text;
                    insertar.nombre_pagador = row.Cells[49].Text;
                    insertar.gastos_emision = row.Cells[50].Text;
                    insertar.recargo_por_frac = row.Cells[51].Text;
                    insertar.valor_iva = row.Cells[52].Text;
                    insertar.confirmar = row.Cells[53].Text;
                    insertar.cob_may18_men_25_anos = row.Cells[54].Text;
                    insertar.cob_may16_men_18_anos = row.Cells[55].Text;
                    insertar.cob_may16 = row.Cells[56].Text;
                    insertar.endoso_renov = row.Cells[57].Text;
                    insertar.correo = row.Cells[58].Text;
                    insertar.dpi = row.Cells[59].Text;
                    insertar.direccion_cobro = row.Cells[60].Text;
                    insertar.pasaporte = row.Cells[61].Text;
                    insertar.nit = row.Cells[62].Text;
                    insertar.estado = 1;
                    DBRenovaciones.renovaciones_polizas.Add(insertar);
                    DBRenovaciones.SaveChanges();
                    row.CssClass = "success";
                    Utils.ShowMessage(this.Page, "Datos Cargados con exito", "Excelente", "success");
                }

                catch (Exception ex)
                {
                    row.CssClass = "danger";
                    Utils.ShowMessage(this.Page, "No se pudieron insertar los datos " + ex.Message.ToString(), "ERROR", "error");
                }
            }
        }

        else
        {
            foreach (GridViewRow row in GridCargas.Rows)
            {
                try
                {
                    requerimiento.poliza = row.Cells[0].Text;
                    requerimiento.renovacion = row.Cells[1].Text;
                    requerimiento.requerimiento = row.Cells[2].Text; 
                    requerimiento.fecha = row.Cells[3].Text;
                    requerimiento.prima_neta = row.Cells[4].Text;
                    requerimiento.comision = row.Cells[5].Text;
                    requerimiento.prima_total = row.Cells[6].Text;
                    DBRenovaciones.requerimientos.Add(requerimiento);
                    DBRenovaciones.SaveChanges();
                    row.CssClass = "success";
                }

                catch(Exception ex)
                {
                    row.CssClass = "danger";
                    Utils.ShowMessage(this.Page, "No se pudieron insertar los datos " + ex.Message.ToString(), "ERROR", "error");
                }
            }
        }
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        RecorrerCarga();
    }
}