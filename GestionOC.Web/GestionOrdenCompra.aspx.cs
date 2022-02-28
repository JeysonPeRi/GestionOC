using DevExpress.Web;
using GestionOC.Mod;
using GestionOC.Neg;
using System;
using System.Collections.Generic;
using System.IO;

namespace GestionOC.Web
{
    public partial class GestionOrdenCompra : System.Web.UI.Page
    {
        static Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioConectado"] != null)
            {
                usuario = (Usuario)Session["UsuarioConectado"];
                AgvOrdenCompra.Toolbars[0].Items[2].ClientEnabled = AgvOrdenCompra.FocusedRowIndex > -1;
                AgvOrdenCompra.Toolbars[0].Items[3].ClientEnabled = AgvOrdenCompra.FocusedRowIndex > -1;
                if (!IsPostBack && !IsCallback)
                {
                    PrepararInicio();
                    LevantarPermisos(AgvOrdenCompra, Path.GetFileName(Request.PhysicalPath));
                    LevantarPermisosAntecedente(AfmAntecedentes, Path.GetFileName(Request.PhysicalPath));
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
                            if (item.Name.Equals("Imprimir") || item.Name.Equals("Antecedentes"))
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
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
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void LevantarPermisosAntecedente(ASPxFileManager fileManager, string rutaFisicaFormulario)
        {
            try
            {
                if (usuario != null && fileManager != null)
                {
                    if (!usuario.Formularios.Exists(x => x.ToLower() == rutaFisicaFormulario.ToLower()))
                    {
                        fileManager.SettingsEditing.AllowDelete = false;
                        fileManager.SettingsEditing.AllowRename = false;
                        fileManager.SettingsUpload.Enabled = false;
                    }
                    else
                    {
                        fileManager.SettingsEditing.AllowDelete = true;
                        fileManager.SettingsEditing.AllowRename = true;
                        fileManager.SettingsUpload.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AcpOrdenCompra_Callback(object sender, CallbackEventArgsBase e)
        {
            try
            {
                string[] datos = e.Parameter.Split(',');
                switch (datos[0])
                {
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvOrdenCompra_DataBound(object sender, EventArgs e)
        {
            try
            {
                Session["idSeleccion"] = Convert.ToInt32(AgvOrdenCompra.GetRowValues(AgvOrdenCompra.FocusedRowIndex, AgvOrdenCompra.KeyFieldName));
                string ruta = MapPath("~/App_Data/Antecedentes/") + Session["idSeleccion"].ToString();
                OrdenCompraNeg.AsignarCarpetaAntecedentes(ruta, out int codigo, out string mensaje);
                AgvOrdenCompra.JSProperties["cpCarpeta"] = Session["idSeleccion"].ToString();
                AgvOrdenCompra.Toolbars[0].Items[2].ClientEnabled = AgvOrdenCompra.FocusedRowIndex > -1;
                AgvOrdenCompra.Toolbars[0].Items[3].ClientEnabled = AgvOrdenCompra.FocusedRowIndex > -1;
                Session["formularioImprimir"] = "GestionOrdenCompra.aspx";
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvOrdenCompra_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Command.ToString())
                {
                    case "New":
                        Session["itemsOrdenCompra"] = new List<Item>();
                        break;
                    case "Edit":
                        Session["itemsOrdenCompra"] = ItemNeg.ListarItem(Convert.ToInt32(AgvOrdenCompra.GetRowValues(AgvOrdenCompra.FocusedRowIndex, AgvOrdenCompra.KeyFieldName)), out _, out _);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvOrdenCompra_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                e.NewValues["Numero"] = 0;
                e.NewValues["Fecha"] = DateTime.Today.Date;
                e.NewValues["Lugar"] = "Santiago";
                e.NewValues["TipoCambio"] = 1;
                Impuesto impuesto = ObtenerImpuestoActual();
                AgvOrdenCompra.JSProperties["cpImpuesto"] = impuesto.Porcentaje;
                string ruta = MapPath("~/App_Data/Antecedentes/") + Session.SessionID;
                OrdenCompraNeg.AsignarCarpetaAntecedentes(ruta, out int codigo, out string mensaje);
                if (codigo > 0)
                {
                    AgvOrdenCompra.JSProperties["cpCarpeta"] = Session.SessionID;
                }
                else
                {
                    AgvOrdenCompra.JSProperties["cpCarpeta"] = null;
                }
                AgvOrdenCompra.FocusedRowIndex = -1;
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvOrdenCompra_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            try
            {
                if (e.NewValues["Fecha"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Fecha"].ToString()))
                {
                    if (e.NewValues["Lugar"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Lugar"].ToString()))
                    {
                        if (e.NewValues["Proveedor.RutFormateado"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Proveedor.RutFormateado"].ToString()))
                        {
                            if (e.NewValues["Proveedor.RazonSocial"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Proveedor.RazonSocial"].ToString()))
                            {
                                if (e.NewValues["Moneda.Codigo"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Moneda.Codigo"].ToString()))
                                {
                                    if (e.NewValues["TipoCambio"] != null && !string.IsNullOrWhiteSpace(e.NewValues["TipoCambio"].ToString()) && Convert.ToInt32(e.NewValues["TipoCambio"]) > -1)
                                    {
                                        if (e.NewValues["Subtotal"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Subtotal"].ToString()))
                                        {
                                            double.TryParse(e.NewValues["Subtotal"].ToString(), out double Subtotal);
                                            if (Subtotal > 0)
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                e.RowError = "Debe ingresar al menos un item.";
                                            }
                                        }
                                        else
                                        {
                                            e.RowError = "Debe ingresar al menos un item.";
                                        }
                                    }
                                    else
                                    {
                                        e.RowError = "Ingrese un tipo cambio valido.";
                                    }
                                }
                                else
                                {
                                    e.RowError = "Seleccione una moneda.";
                                }
                            }
                            else
                            {
                                e.RowError = "Ingrese un rut valido.";
                            }
                        }
                        else
                        {
                            e.RowError = "Ingrese un rut valido.";
                        }
                    }
                    else
                    {
                        e.RowError = "Ingrese un lugar valido.";
                    }
                }
                else
                {
                    e.RowError = "Ingrese una fecha valida.";
                }
            }
            catch (Exception ex)
            {
                e.RowError = ex.Message;
            }
        }

        protected void AgvOrdenCompra_FocusedRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (!AgvOrdenCompra.IsEditing)
                {
                    Session["idSeleccion"] = Convert.ToInt32(AgvOrdenCompra.GetRowValues(AgvOrdenCompra.FocusedRowIndex, AgvOrdenCompra.KeyFieldName));
                    Session["formularioImprimir"] = "GestionOrdenCompra.aspx";
                    if (Session["idSeleccion"] != null && ((int)Session["idSeleccion"]) > 0)
                    {
                        string ruta = MapPath("~/App_Data/Antecedentes/") + Session["idSeleccion"].ToString();
                        OrdenCompraNeg.AsignarCarpetaAntecedentes(ruta, out int codigo, out string mensaje);
                        if (codigo > 0)
                        {
                            AgvOrdenCompra.JSProperties["cpCarpeta"] = Session["idSeleccion"].ToString();
                        }
                        else
                        {
                            AgvOrdenCompra.JSProperties["cpCarpeta"] = null;
                        }
                    }
                }
                else
                {
                    AgvOrdenCompra.FocusedRowIndex = -1;
                }
                AgvOrdenCompra.Toolbars[0].Items[2].ClientEnabled = AgvOrdenCompra.FocusedRowIndex > -1;
                AgvOrdenCompra.Toolbars[0].Items[3].ClientEnabled = AgvOrdenCompra.FocusedRowIndex > -1;
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvDetalleOrdenCompra_BeforePerformDataSelect(object sender, EventArgs e)
        {
            try
            {
                Session["DetalleOrdenNumero"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvItemOrdenCompra_DataBound(object sender, EventArgs e)
        {
            try
            {
                ASPxGridView gridView = sender as ASPxGridView;
                gridView.JSProperties["cpSummaryTotal"] = gridView.GetTotalSummaryValue(gridView.TotalSummary["Total"]);
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvItemOrdenCompra_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            try
            {
                if (e.NewValues["Detalle"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Detalle"].ToString()))
                {
                    if (e.NewValues["Cantidad"] != null && !string.IsNullOrWhiteSpace(e.NewValues["Cantidad"].ToString()))
                    {
                        double.TryParse(e.NewValues["Cantidad"].ToString(), out double cantidad);
                        if (cantidad > 0)
                        {
                            if (e.NewValues["PrecioUnitario"] != null && !string.IsNullOrWhiteSpace(e.NewValues["PrecioUnitario"].ToString()))
                            {
                                double.TryParse(e.NewValues["PrecioUnitario"].ToString(), out double precioUnitario);
                                if (precioUnitario > 0)
                                {
                                    return;
                                }
                                else
                                {
                                    e.RowError = "El precio unitario debe se mayor que [0].";
                                }
                            }
                            else
                            {
                                e.RowError = "Ingrese un precio unitario valido.";
                            }
                        }
                        else
                        {
                            e.RowError = "La cantidad debe se mayor que [0].";
                        }
                    }
                    else
                    {
                        e.RowError = "Ingrese una cantidad valida.";
                    }
                }
                else
                {
                    e.RowError = "Ingrese un detalle valido.";
                }
            }
            catch (Exception ex)
            {
                e.RowError = ex.Message;
            }
        }

        protected void AgvItemOrdenCompra_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                ASPxGridView gridView = (ASPxGridView)sender;
                List<Item> items = (List<Item>)Session["itemsOrdenCompra"];
                items.Add(new Item(items.Count + 1, Convert.ToString(e.NewValues["Detalle"]), Convert.ToDouble(e.NewValues["Cantidad"]), Convert.ToDouble(e.NewValues["PrecioUnitario"]), Convert.ToDouble(e.NewValues["Total"])));
                Session["itemsOrdenCompra"] = items;
                gridView.CancelEdit();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvItemOrdenCompra_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                ASPxGridView gridView = (ASPxGridView)sender;
                List<Item> items = (List<Item>)Session["itemsOrdenCompra"];
                (items.Find(x => x.Codigo == Convert.ToInt32(e.Keys[0]))).Detalle = Convert.ToString(e.NewValues["Detalle"]);
                (items.Find(x => x.Codigo == Convert.ToInt32(e.Keys[0]))).Cantidad = Convert.ToDouble(e.NewValues["Cantidad"]);
                (items.Find(x => x.Codigo == Convert.ToInt32(e.Keys[0]))).PrecioUnitario = Convert.ToDouble(e.NewValues["PrecioUnitario"]);
                (items.Find(x => x.Codigo == Convert.ToInt32(e.Keys[0]))).Total = Convert.ToDouble(e.NewValues["Total"]);
                Session["itemsOrdenCompra"] = items;
                gridView.CancelEdit();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AgvItemOrdenCompra_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                List<Item> items = (List<Item>)Session["itemsOrdenCompra"];
                items.Remove(items.Find(x => x.Codigo == Convert.ToInt32(e.Values["Codigo"])));
                int codigo = 1;
                foreach (Item item in items)
                {
                    item.Codigo = codigo;
                    codigo++;
                }
                Session["itemsOrdenCompra"] = items;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsOrdenCompra_Selected(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.OutputParameters["codigo"]) <= -1)
                {
                    AgvOrdenCompra.JSProperties["cpCodigo"] = e.OutputParameters["codigo"];
                    AgvOrdenCompra.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
                }
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsOrdenCompra_Inserted(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                AgvOrdenCompra.JSProperties["cpCodigo"] = e.OutputParameters["codigo"];
                AgvOrdenCompra.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
                Session["idGardado"] = e.OutputParameters["ordenCompraNumeroActualizado"];
                Session["formularioImprimir"] = "GestionOrdenCompra.aspx";
                string ruta = MapPath("~/App_Data/Antecedentes/") + Session.SessionID;
                string ruta2 = MapPath("~/App_Data/Antecedentes/") + Session["idGardado"].ToString();
                if ((Convert.ToInt32(e.OutputParameters["codigo"]) > 0))
                {
                    OrdenCompraNeg.ConfirmarAntecedentes(ruta, ruta2, out int codigo, out string mensaje);
                    if (codigo < 1)
                    {
                        AgvOrdenCompra.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"] + " " + mensaje;
                    }
                }
                else
                {
                    OrdenCompraNeg.LimpiarAntecedentes(ruta, out int codigo, out string mensaje);
                }

            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void OdsOrdenCompra_Deleted(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            try
            {
                AgvOrdenCompra.JSProperties["cpCodigo"] = e.OutputParameters["codigo"];
                AgvOrdenCompra.JSProperties["cpMensaje"] = e.OutputParameters["mensaje"];
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        public Impuesto ObtenerImpuestoActual()
        {
            Impuesto impuesto = new Impuesto();
            try
            {
                impuesto = ImpuestoNeg.BuscarImpuesto(DateTime.Today.Date, out int codigo, out _);
                if (codigo <= 0)
                {
                    impuesto = new Impuesto(0, 19, DateTime.MinValue);
                }
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
            return impuesto;
        }

        protected void ValidarRut(string Rut)
        {
            try
            {
                int rut = FuncionGlobal.FormaterarRutEntero(Rut);
                Proveedor proveedor = ProveedorNeg.BuscarProveedor(rut, out int codigo, out string mensaje);
                AcbOrdenCompra.JSProperties["cpRut"] = codigo <= 0 ? "" : proveedor.RutFormateado;
                AcbOrdenCompra.JSProperties["cpRazonSocial"] = codigo <= 0 ? "" : proveedor.RazonSocial;
                if (codigo < 0)
                {
                    AcbOrdenCompra.JSProperties["cpCodigo"] = codigo;
                    AcbOrdenCompra.JSProperties["cpMensaje"] = mensaje;
                }
                Impuesto impuesto = ObtenerImpuestoActual();
                AgvOrdenCompra.JSProperties["cpImpuesto"] = impuesto.Porcentaje;
            }
            catch (Exception ex)
            {
                AcbOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcbOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        public List<Item> ItemsOrdenCompra()
        {
            try
            {
                if (Session["itemsOrdenCompra"] == null)
                {
                    Session["itemsOrdenCompra"] = new List<Item>();
                }
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
            return (List<Item>)Session["itemsOrdenCompra"];
        }

        protected void PrepararInicio()
        {
            try
            {
                DetInicio.Date = DateTime.Today.AddDays(-1);
                DetInicio.MaxDate = DateTime.Today;
                DetFin.Date = DateTime.Today;
                DetFin.MaxDate = DateTime.Today;
                Impuesto impuesto = ObtenerImpuestoActual();
                AgvOrdenCompra.JSProperties["cpImpuesto"] = impuesto.Porcentaje;
                AgvOrdenCompra.FocusedRowIndex = -1;
            }
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }

        protected void AcbOrdenCompra_Callback(object source, CallbackEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                AcpOrdenCompra.JSProperties["cpCodigo"] = -1;
                AcpOrdenCompra.JSProperties["cpMensaje"] = ex.Message;
            }
        }
    }
}