using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_entidad;

namespace DataAccess
{
    internal class ClassDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_trabajadores()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_trabajador",cn);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_trabajadores(ClassEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_trabajador", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNI",obje.DNI);

        }


    }
}
