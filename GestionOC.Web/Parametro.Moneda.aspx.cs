using DevExpress.Web;
using GestionOC.Mod;
using GestionOC.Neg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionOC.Web
{
    public partial class Parametro_Moneda : System.Web.UI.Page
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
                    LevantarPermisos(AgvMoneda, Path.GetFileName(Request.PhysicalPath));
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
                AgvMoneda.JSProperties["cpCodigo"] = -1;
                AgvMoneda.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvMoneda_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            try
            {
                if (e.NewValues["Codigo"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Codigo"].ToString()) && Convert.ToInt32(e.NewValues["Codigo"]) > 0)
                {
                    if (e.NewValues["Glosa"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Glosa"].ToString()))
                    {
                        if (e.NewValues["Simbolo"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Simbolo"].ToString()))
                        {
                            if (e.IsNewRow)
                            {
                                MonedaNeg.BuscarMoneda(Convert.ToInt32(e.NewValues["Codigo"]), out int codigo, out _);
                                if(codigo >= 1)
                                {
                                    e.RowError = "Código de moneda ya existe.";
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            e.RowError = "Ingrese un símbolo valido.";
                        }
                    }
                    else
                    {
                        e.RowError = "Ingrese una glosa valida.";
                    }
                }
                else
                {
                    e.RowError = "Ingrese un código valido.";
                }
            }
            catch (Exception ex)
            {
                e.RowError = ex.Message;
            }
        }

        protected void OdsMoneda_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                if(Convert.ToInt32(e.OutputParameters["codigo"]) <= -1)
                {
                    AgvMoneda.JSProperties["cpCodigo"] = e.OutputParameters["codigo"];
                    AgvMoneda.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
                }
            }
            catch (Exception ex)
            {
                AcpMoneda.JSProperties["cpCodigo"] = -1;
                AcpMoneda.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsMoneda_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                AgvMoneda.JSProperties["cpCodigo"] = e.OutputParameters["codigoSalida"];
                AgvMoneda.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
            }
            catch (Exception ex)
            {
                AcpMoneda.JSProperties["cpCodigo"] = -1;
                AcpMoneda.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsMoneda_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                AgvMoneda.JSProperties["cpCodigo"] = e.OutputParameters["codigoSalida"];
                AgvMoneda.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
            }
            catch (Exception ex)
            {
                AcpMoneda.JSProperties["cpCodigo"] = -1;
                AcpMoneda.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsMoneda_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                AgvMoneda.JSProperties["cpCodigo"] = e.OutputParameters["codigoSalida"];
                AgvMoneda.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
            }
            catch (Exception ex)
            {
                AcpMoneda.JSProperties["cpCodigo"] = -1;
                AcpMoneda.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void PrepararInicio()
        {
            try
            {
                AgvMoneda.FocusedRowIndex = -1;
            }
            catch (Exception ex)
            {
                AcpMoneda.JSProperties["cpCodigo"] = -1;
                AcpMoneda.JSProperties["cpMensaje"] = ex.Message;
            }
        }
    }
}