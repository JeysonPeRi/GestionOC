using DevExpress.Web;
using GestionOC.Mod;
using GestionOC.Neg;
using System;

namespace GestionOC.Web
{
    public partial class Informe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlarToobar(AgvInforme.VisibleRowCount > 0);
            if (!IsPostBack && !IsCallback)
            {
                PrepararInicio();
            }
        }

        protected void AcpInforme_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] datos = e.Parameter.Split(',');
            switch (datos[0])
            {
                case "ValidaRut":
                    ValidarRut(datos[1]);
                    break;
                default:
                    break;
            }
        }

        protected void ValidarRut(string Rut)
        {
            try
            {
                int rut = FuncionGlobal.FormaterarRutEntero(Rut);
                Proveedor proveedor = ProveedorNeg.BuscarProveedor(rut, out int codigo, out string mensaje);
                BetRut.Text = proveedor.RutFormateado;
                BetRut.ClientEnabled = true;
                TxtRazonSocial.Text = proveedor.RazonSocial;
            }
            catch (Exception ex)
            {
                AcpInforme.JSProperties["cpCodigo"] = -1;
                AcpInforme.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void PrepararInicio()
        {
            DetInicio.Date = DateTime.Today.AddDays(-1);
            DetInicio.MaxDate = DateTime.Today;
            DetFin.Date = DateTime.Today;
            DetFin.MaxDate = DateTime.Today;
            AgvInforme.FocusedRowIndex = -1;
        }

        protected void AgvDetalleInforme_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["DetalleInformeNumero"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void OdsInforme_Selected(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            Session["filtroParametro"] = e.OutputParameters["filtro"];
            Session["formularioImprimir"] = "Informe.aspx";
            try
            {
                int.TryParse(e.OutputParameters["codigo"].ToString(), out int codigo);
                ControlarToobar(codigo > 0);
                if (codigo <= -1)
                {
                    AgvInforme.JSProperties["cpCodigo"] = e.OutputParameters["codigo"];
                    AgvInforme.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
                }
            }
            catch (Exception ex)
            {
                AcpInforme.JSProperties["cpCodigo"] = -1;
                AcpInforme.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void ControlarToobar(bool estado)
        {
            foreach (GridViewToolbarItem item in AgvInforme.Toolbars[0].Items)
            {
                item.Enabled = estado;
            }
        }
    }
}