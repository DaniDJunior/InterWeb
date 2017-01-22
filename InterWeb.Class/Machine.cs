using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterWeb.Class
{
    public class Machine
    {
        public int ID_Machine { get; set; }
        //public int ID_PrinterConfig { get; set; }
        public int ID_Client { get; set; }
        public string MachineName { get; set; }
        public string MachineKey { get; set; }
        public string CPUID { get; set; }
        public string DiskID { get; set; }
        public string MACID { get; set; }
        public string IP { get; set; }
        public string IPOut { get; set; }
        public string HostName { get; set; }
        public string DNS { get; set; }
        public int ID_Status { get; set; }

        public Machine()
        {
            ClearData();
        }

        public Machine(int id_machine)
        {
            DataTable data = USP_SEL_Machine_ID(id_machine);
            if(data.Rows.Count == 1)
            {
                OpenData(data.Rows[0]);
            }
            else
            {
                ClearData();
            }
        }

        public Machine(DataRow coluna)
        {
            OpenData(coluna);
        }

        public void ClearData()
        {
            ID_Machine = 0;
            //ID_PrinterConfig = 0;
            ID_Client = 0;
            MachineName = null;
            MachineKey = null;
            CPUID = null;
            DiskID = null;
            MACID = null;
            IP = null;
            IPOut = null;
            HostName = null;
            DNS = null;
            ID_Status = Status.Ativo;
        }

        public void OpenData(DataRow coluna)
        {
            ID_Machine = Conector.Conector.AbreCampo_INT(coluna, "ID_Machine");
            //ID_PrinterConfig = Conector.Conector.AbreCampo_INT(coluna, "ID_PrinterConfig");
            ID_Client = Conector.Conector.AbreCampo_INT(coluna, "ID_Client");
            MachineName = Conector.Conector.AbreCampo_VARCHAR(coluna, "MachineName");
            MachineKey = Conector.Conector.AbreCampo_VARCHAR(coluna, "MachineKey");
            CPUID = Conector.Conector.AbreCampo_VARCHAR(coluna, "CPUID");
            DiskID = Conector.Conector.AbreCampo_VARCHAR(coluna, "DiskID");
            MACID = Conector.Conector.AbreCampo_VARCHAR(coluna, "MACID");
            IP = Conector.Conector.AbreCampo_VARCHAR(coluna, "IP");
            IPOut = Conector.Conector.AbreCampo_VARCHAR(coluna, "IPOut");
            HostName = Conector.Conector.AbreCampo_VARCHAR(coluna, "HostName");
            DNS = Conector.Conector.AbreCampo_VARCHAR(coluna, "DNS");
            ID_Status = Conector.Conector.AbreCampo_INT(coluna, "ID_Status");
        }

        public void salvar()
        {
            DataTable data = USP_INS_UPD_Machine(this);
            if (data.Rows.Count == 1)
            {
                ID_Machine =int.Parse(data.Rows[0][0].ToString());
            }
            else
            {
                //TODO: Erro;
            }
        }

        public static List<Status> getList()
        {
            List<Status> resp = new List<Status>();
            foreach (DataRow i in USP_SEL_Machine().Rows)
            {
                resp.Add(new Status(i));
            }
            return resp;
        }

        private static DataTable USP_SEL_Machine()
        {
            return Conector.SQL.ProcedureComand("USP_SEL_Machine", new List<SqlParameter>()).Tables[0];
        }

        private static DataTable USP_SEL_Machine_ID(int id_machine)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(Conector.SQL.CriaParametro("ID_Machine", SqlDbType.Int, id_machine));
            return Conector.SQL.ProcedureComand("USP_SEL_Machine_ID", parametros).Tables[0];
        }

        private static DataTable USP_INS_UPD_Machine(Machine machine)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(Conector.SQL.CriaParametro("ID_Machine", SqlDbType.Int, machine.ID_Machine));
            parametros.Add(Conector.SQL.CriaParametro("ID_Client", SqlDbType.Int, machine.ID_Client));
            parametros.Add(Conector.SQL.CriaParametro("MachineName", 100, SqlDbType.VarChar, machine.MachineName));
            parametros.Add(Conector.SQL.CriaParametro("MachineKey", 100, SqlDbType.VarChar, machine.MachineKey));
            parametros.Add(Conector.SQL.CriaParametro("CPUID", 100, SqlDbType.VarChar, machine.CPUID));
            parametros.Add(Conector.SQL.CriaParametro("DiskID", 100, SqlDbType.VarChar, machine.DiskID));
            parametros.Add(Conector.SQL.CriaParametro("MACID", 100, SqlDbType.VarChar, machine.MACID));
            parametros.Add(Conector.SQL.CriaParametro("IP", 100, SqlDbType.VarChar, machine.IP));
            parametros.Add(Conector.SQL.CriaParametro("IPOut", 100, SqlDbType.VarChar, machine.IPOut));
            parametros.Add(Conector.SQL.CriaParametro("HostName", 100, SqlDbType.VarChar, machine.HostName));
            parametros.Add(Conector.SQL.CriaParametro("DNS", 100, SqlDbType.VarChar, machine.DNS));
            parametros.Add(Conector.SQL.CriaParametro("ID_Status", SqlDbType.Int, machine.ID_Status));
            return Conector.SQL.ProcedureComand("USP_INS_UPD_Machine", parametros).Tables[0];
        }
    }
}
