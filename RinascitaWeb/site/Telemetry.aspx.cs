using Rinascita.LIB;
using RinascitaWeb.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RinascitaWeb.site
{
    public partial class Telemetry : WebSitePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string v = Request.QueryString["IdProcess"];
            if (v != null)
            {
                BindChart(v);
            }

        }

        public string _dataForChart = "";// string.Empty;
        public string _dataRollForChart = "";// string.Empty;

        public void BindChart(string IdProcess)
        {
            string data = string.Empty;
            string dataRoll = string.Empty;
            //_dataRollForChart

            dataHelper db = new dataHelper();
            Entity.MyTelemetry[] mTel = db.selectTTelemetryByIdProcess(IdProcess);

            if (mTel != null && mTel.Length > 0)
            {
                int iNum = 0;
                data = "data: [ ";
                dataRoll = "data: [ ";
                foreach (Entity.MyTelemetry t in mTel)
                {
                    DateTime dt = (DateTime)t.DT_INS;
                    data += "{ d: '" + dt.ToString("HHmmss") + "', Xg: " + t.Xg.ToString() + ", Yg: " + t.Yg.ToString() + ", Zg: " + t.Zg.ToString() + " }";
                    dataRoll += "{ d: '" + dt.ToString("HHmmss") + "', Roll: " + t.roll.ToString() + ", Pitch: " + t.pitch.ToString() + " }";



                    if (iNum < mTel.Length - 1)
                    {
                        data += ",";
                        dataRoll += ",";
                    }
                        

                    iNum++;
                }

                data += "]";
                dataRoll += "]";

                _dataForChart = data;
                _dataRollForChart = dataRoll;
            }

            //data: [
            //  { year: '2008', value: 20, value1: 20 },
            //  { year: '2009', value: 10, value1: 20 },
            //  { year: '2010', value: 5, value1: 20 },
            //  { year: '2011', value: 5, value1: 20 },
            //  { year: '2012', value: 20, value1: 20 }
            //]

        }

    }
}