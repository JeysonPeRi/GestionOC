using GestionOC.Mod;
using GestionOC.Neg;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionOC.Web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string[] cadena = HttpContext.Current.Request.Url.ToString().Split('|');
                string url = cadena[0];
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                string host = HttpContext.Current.Request.Url.Host;
                string requestType = HttpContext.Current.Request.RequestType;

                Uri uri = new Uri(url);
                NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);

                string strNroUsu = query.Get("0100101");
                strNroUsu = "1";
                if (!string.IsNullOrEmpty(strNroUsu))
                {
                    //int.TryParse(FuncionGlobal.Desencriptar(FuncionGlobal.DecryptRijndael(strNroUsu)), out int UsuNum);
                    //Session["LoginUrl"] = FuncionGlobal.Desencriptar(FuncionGlobal.DecryptRijndael(cadena[1]));
                    int UsuNum = 1;
                    Usuario usuario = UsuarioNeg.BuscarUsuario(UsuNum, out int codigo, out string mensaje);
                    if (codigo >= 1 && usuario.CodigoAccesoSistema.Exists(x => x == 3))
                    {
                        Session["UsuarioConectado"] = usuario;

                        PropertyInfo isreadonly = typeof(NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        isreadonly.SetValue(Request.QueryString, false, null);
                        Request.QueryString.Remove("0100101");
                        Response.Redirect("GestionOrdenCompra.aspx", false);
                    }
                    else
                    {
                        if (Session["LoginUrl"] != null && !((string)Session["LoginUrl"]).Trim().Equals(""))
                        {
                            Response.Redirect((string)Session["LoginUrl"]);
                        }
                        else
                        {
                            Response.Redirect(ConfigurationManager.AppSettings["ControlAcceso"], true);
                        }
                    }
                }
                else
                {
                    Response.Redirect(ConfigurationManager.AppSettings["ControlAcceso"], true);
                }
            }
            catch (Exception ex)
            {
                ASPxMemo1.Text = ex.Message;
            }
        }
    }
}