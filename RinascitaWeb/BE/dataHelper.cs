using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.Linq;

using RinascitaWeb.Entity;

namespace RinascitaWeb.BE
{
    public class dataHelper
    {

        public dataHelper()
        { }


        public TB_users[] UserLogOn(string user, string password)
        {
            try
            {
                Entity.EntitiesRinascita context = new EntitiesRinascita();
                var userLogon = (from p in context.TB_users
                                 where p.Username == user && p.Password == password
                                 select p).ToArray();

                if (userLogon.Length == 1)
                    return userLogon;
                else
                    return null;
            }
            catch (Exception exc)
            {
                return null;
            }

        }


        public TB_pagesecurity[] pagesEnable()
        {
            try
            {
                Entity.EntitiesRinascita context = new EntitiesRinascita();
                var page = (from p in context.TB_pagesecurity
                                 select p).ToArray();

                if (page.Length == 1)
                    return page;
                else
                    return null;
            }
            catch (Exception exc)
            {
                return null;
            }

        }

    }
}