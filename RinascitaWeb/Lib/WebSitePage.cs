using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using System.Configuration;

using log4net;
using RinascitaWeb.Entity;

namespace Rinascita.LIB
{
    public partial class WebSitePage : System.Web.UI.Page
    {

        #region Log4Net
        private static readonly ILog log = LogManager.GetLogger(typeof(WebSitePage));
        private static readonly bool IsDebugEnabled = log.IsDebugEnabled;
        private static readonly bool IsErrorEnabled = log.IsErrorEnabled;
        #endregion

        private string _Name = string.Empty;
        private string _Surname = string.Empty;
        private string _Email = string.Empty;
        private string _Password = string.Empty;
        private string _Note = string.Empty;
        private string _Group = string.Empty;
        private string _LastLogin = string.Empty;



        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string sFunction = "WebSitePage  |";
            if (log.IsDebugEnabled) log.Debug(sFunction + "Start");

            try
            {


                if (Session["UserLogOn"] != null)
                {
                    TB_users[] user = (TB_users[])Session["UserLogOn"];
                    if (user != null && user.Length == 1)
                    {

                        if (!IsPageEnableForUser(user[0].GroupLevel))
                        {
                            Response.Redirect(Page.ResolveUrl("~/AutError.aspx"));
                        }
                    }

                }
                else
                {
                    Response.Redirect("~/AutError.aspx");
                }


            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception ex)
            { }

        }


        public bool IsPageEnableForUser(string strGroup)
        {
            try
            {
                string pagename = System.IO.Path.GetFileName(Request.PhysicalPath);
                string ds_group = string.Empty;



                if (strGroup == ConfigurationManager.AppSettings["AdminGroup"])
                {
                    ds_group = "Admin_Group";
                    Session["ds_group"] = ds_group;
                }

                else if (strGroup == ConfigurationManager.AppSettings["PricingGroup"])
                {
                    ds_group = "CS_Group";
                    Session["ds_group"] = ds_group;
                }
                else if (strGroup == ConfigurationManager.AppSettings["WebGroup"])
                {
                    ds_group = "User_Group";
                    Session["ds_group"] = ds_group;
                }


                if (ds_group != "")
                {
                    return true;
                    //implementare abilitazione per singola pagina
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                return false;
            }
            

        }


    }
}