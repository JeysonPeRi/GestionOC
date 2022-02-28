using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionOC.Web
{
    public partial class Imprimir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["formularioImprimir"] != null)
            {
                CachedReportSourceWeb cachedReportSource;
                switch ((string)Session["formularioImprimir"])
                {
                    case "GestionOrdenCompra.aspx":
                        //RptOrdenCompra rptOrdenCompra = new RptOrdenCompra();
                        RptOrdenCompraDoble rptOrdenCompra = new RptOrdenCompraDoble();
                        if (Session["idGardado"] != null && ((int)Session["idGardado"]) > 0)
                        {
                            rptOrdenCompra.Parameters["ocNumero"].Value = Session["idGardado"];
                            Session["idGardado"] = 0;
                        }
                        else
                        {
                            rptOrdenCompra.Parameters["ocNumero"].Value = Session["idSeleccion"];
                        }
                        cachedReportSource = new CachedReportSourceWeb(rptOrdenCompra);
                        WdvOrdenCompra.OpenReport(cachedReportSource);
                        break;
                    case "Informe.aspx":
                        DataTable filtroParametro = (DataTable)Session["filtroParametro"];
                        RptInforme rptInforme = new RptInforme();
                        rptInforme.Parameters["pDesde"].Value = filtroParametro.Rows[0]["desde"];
                        rptInforme.Parameters["pHasta"].Value = filtroParametro.Rows[0]["hasta"];
                        rptInforme.Parameters["pMonedaCodigo"].Value = filtroParametro.Rows[0]["monedaCodigo"];
                        rptInforme.Parameters["pMonedaCodigoTodos"].Value = filtroParametro.Rows[0]["monedaCodigoTodos"];
                        rptInforme.Parameters["pRechazada"].Value = filtroParametro.Rows[0]["rechazada"];
                        rptInforme.Parameters["pProveedorRut"].Value = filtroParametro.Rows[0]["proveedorRut"];
                        rptInforme.Parameters["pProveedorRutTodos"].Value = filtroParametro.Rows[0]["proveedorRutTodos"];
                        cachedReportSource = new CachedReportSourceWeb(rptInforme);
                        WdvOrdenCompra.OpenReport(cachedReportSource);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}