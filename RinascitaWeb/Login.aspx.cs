using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using RinascitaWeb.Entity;
using RinascitaWeb.BE;
using System.Threading;

namespace RinascitaWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            dataHelper db = new dataHelper();

            try
            {

                TB_users[] user = db.UserLogOn(this.txtUser.Text, this.txtPassword.Text);
                if (user != null && user.Length==1)
                {
                    Session["UserLogOn"] = user;
                    Response.Redirect("~/index.aspx");
                }
                else
                {
                    Session["UserLogOn"] = null;
                    Response.Redirect("~/AutError.aspx");
                }
            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception exc)
            { }


        }
    }
}