using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionOC.Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioConectado"] != null)
            {
                IDLblUserRegistrado.Text = ((Usuario)Session["UsuarioConectado"]).Nombre;
            }
        }

        protected void IDBtnCerraSesion_Click(object sender, EventArgs e)
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
}