﻿using System;
using System.IO;
using System.Web.UI;

public partial class ReportesDaños : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_ReportesDaños", Gridvarios);
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(Gridvarios,Response,"Reclamos Varios");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}