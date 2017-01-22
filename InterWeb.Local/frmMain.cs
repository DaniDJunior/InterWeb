using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterWeb.Local
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            MachineInfo.GetMachineData();
        }

        private void OpenWebInterface()
        {
            string retorno = string.Empty;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:9001/InterWeb/api/token");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {

                string json = "{";
                json += "\"CPUID\": \"" + ConfigurationManager.AppSettings["Machine.CPUID"] + "\"";
                json += ",";
                json += "\"DiskID\": \"" + ConfigurationManager.AppSettings["Machine.DiskID"] + "\"";
                json += ",";
                json += "\"MACID\": \"" + ConfigurationManager.AppSettings["Machine.MACID"] + "\"";
                json += ",";
                json += "\"IP\": \"" + ConfigurationManager.AppSettings["Machine.IP"] + "\"";
                json += ",";
                json += "\"IPOut\": \"" + ConfigurationManager.AppSettings["Machine.IPOut"] + "\"";
                json += "}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            ProcessStartInfo sInfo = new ProcessStartInfo("http://localhost:9001/InterWeb/");
            Process.Start(sInfo);
        }

        private void cmsIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWebInterface();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebInterface();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {

        }
    }
}
