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
    
    public class ClassDatos:ConnectionToSql
    {
       public ClassDatos()
        {

            cn.ConnectionString = connectionString;

        }
        private SqlConnection cn = new SqlConnection();
        private SqlCommand Comando = new SqlCommand();
        
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
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return(dt);
        }

        public string D_mantenimiento_trabajadores(ClassEntidad obje)
        {
            string accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenimiento_trabajador", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", obje.Id);
            cmd.Parameters.AddWithValue("@Apellido_s", obje.Apellido_s);
            cmd.Parameters.AddWithValue("@Nombres", obje.Nombres);
            cmd.Parameters.AddWithValue("@DNI", obje.DNI);
            cmd.Parameters.AddWithValue("@Nacionalidad", obje.Nacionalidad);
            cmd.Parameters.AddWithValue("@EstadoCivil", obje.EstadoCivil);
            cmd.Parameters.AddWithValue("@Domicilio", obje.Domicilio);
            cmd.Parameters.AddWithValue("@NumeroDeCalle", obje.NumeroDeCalle);
            cmd.Parameters.AddWithValue("@Depto", obje.Depto);
            cmd.Parameters.AddWithValue("@Piso", obje.Piso);
            cmd.Parameters.AddWithValue("@Localidad", obje.Localidad);
            cmd.Parameters.AddWithValue("@Provincia", obje.Provincia);
            cmd.Parameters.AddWithValue("@TelefonoParticular", obje.TelefonoParticular);
            cmd.Parameters.AddWithValue("@Celular", obje.Celular);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;

            try
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Open();

                cmd.ExecuteNonQuery(); // Aquí se ejecuta el procedimiento almacenado.

                accion = cmd.Parameters["@accion"].Value.ToString();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                accion = "Error: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return accion;
        }



    }
}
