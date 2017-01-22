using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterWeb.Class
{
    public class Status
    {
        public int ID_Status { get; set; }

        public string Nome_Status { get; set; }

        public static int Ativo
        {
            get
            {
                return 1;
            }
        }

        public static int Inativo
        {
            get
            {
                return 2;
            }
        }

        public static int Teste
        {
            get
            {
                return 3;
            }
        }

        public Status()
        {
            ClearData();
        }

        public Status(int id_status)
        {
            DataTable data = USP_SEL_Status_ID(id_status);
            if(data.Rows.Count == 1)
            {
                OpenData(data.Rows[0]);
            }
            else
            {
                ClearData();
            }
        }

        public Status(DataRow coluna)
        {
            OpenData(coluna);
        }

        public void ClearData()
        {
            ID_Status = 0;
            Nome_Status = string.Empty;
        }

        public void OpenData(DataRow coluna)
        {
            ID_Status = Conector.Conector.AbreCampo_INT(coluna, "ID_Status");
            Nome_Status = Conector.Conector.AbreCampo_VARCHAR(coluna, "StatusName");
        }

        public static List<Status> getList()
        {
            List<Status> resp = new List<Status>();
            foreach(DataRow i in USP_SEL_Status().Rows)
            {
                resp.Add(new Status(i));
            }
            return resp;
        }

        private static DataTable USP_SEL_Status()
        {
            return Conector.SQL.ProcedureComand("USP_SEL_Status", new List<SqlParameter>()).Tables[0];
        }

        private static DataTable USP_SEL_Status_ID(int id_status)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(Conector.SQL.CriaParametro("ID_Status", SqlDbType.Int, id_status));
            return Conector.SQL.ProcedureComand("USP_SEL_Status_ID", parametros).Tables[0];
        }

        private static DataTable USP_INS_UPD_Status(Status status)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(Conector.SQL.CriaParametro("ID_Status", SqlDbType.Int, status.ID_Status));
            parametros.Add(Conector.SQL.CriaParametro("StatusName",100, SqlDbType.VarChar, status.Nome_Status));
            return Conector.SQL.ProcedureComand("USP_INS_UPD_Status", parametros).Tables[0];
        }

    }
}
