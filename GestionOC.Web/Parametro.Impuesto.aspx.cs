using DevExpress.Web;
using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionOC.Web
{
    public partial class Parametro_Impuesto : System.Web.UI.Page
    {
        static Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioConectado"] != null)
            {
                usuario = (Usuario)Session["UsuarioConectado"];
                if (!IsPostBack && !IsCallback)
                {
                    PrepararInicio();
                    LevantarPermisos(AgvImpuesto, Path.GetFileName(Request.PhysicalPath));
                }
            }
        }

        protected void LevantarPermisos(ASPxGridView gridView, string rutaFisicaFormulario)
        {
            try
            {
                if (usuario != null && gridView != null)
                {
                    if (!usuario.Formularios.Exists(x => x.ToLower() == rutaFisicaFormulario.ToLower()))
                    {
                        GridViewToolbar toolbar = gridView.Toolbars[0];
                        GridViewToolbarItemCollection items = toolbar.Items;
                        foreach (GridViewToolbarItem item in items)
                        {  
                            item.Visible = false;
                        }
                    }
                    else
                    {
                        GridViewToolbar toolbar = gridView.Toolbars[0];
                        GridViewToolbarItemCollection items = toolbar.Items;
                        foreach (GridViewToolbarItem item in items)
                        {
                            item.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AcpImpuesto.JSProperties["cpCodigo"] = -1;
                AcpImpuesto.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvImpuesto_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            try
            {
                if (e.NewValues["PorcentajeCompleto"] != null && !string.IsNullOrWhiteSpace(e.NewValues["PorcentajeCompleto"].ToString()) && Convert.ToInt32(e.NewValues["PorcentajeCompleto"]) > 0)
                {
                    if (e.NewValues["Fecha"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Fecha"].ToString()))
                    {
                        return;
                    }
                    else
                    {
                        e.RowError = "Ingrese una fecha valida.";
                    }
                }
                else
                {
                    e.RowError = "Ingrese un porcentaje valido.";
                }
            }
            catch (Exception ex)
            {
                e.RowError = ex.Message;
            }
        }

        protected void OdsImpuesto_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.OutputParameters["codigo"]) <= -1)
                {
                    AgvImpuesto.JSProperties["cpCodigo"] = e.OutputParameters["codigo"];
                    AgvImpuesto.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
                }
            }
            catch (Exception ex)
            {
                AcpImpuesto.JSProperties["cpCodigo"] = -1;
                AcpImpuesto.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsImpuesto_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                AgvImpuesto.JSProperties["cpCodigo"] = e.OutputParameters["codigoSalida"];
                AgvImpuesto.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
            }
            catch (Exception ex)
            {
                AcpImpuesto.JSProperties["cpCodigo"] = -1;
                AcpImpuesto.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsImpuesto_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                AgvImpuesto.JSProperties["cpCodigo"] = e.OutputParameters["codigoSalida"];
                AgvImpuesto.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
            }
            catch (Exception ex)
            {
                AcpImpuesto.JSProperties["cpCodigo"] = -1;
                AcpImpuesto.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void PrepararInicio()
        {
            try
            {
                AgvImpuesto.FocusedRowIndex = -1;
            }
            catch (Exception ex)
            {
                AcpImpuesto.JSProperties["cpCodigo"] = -1;
                AcpImpuesto.JSProperties["cpMensaje"] = ex.Message;
            }
        }
    }
}