using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Guia12
{
    internal class ConexionConBD
    {
        //creamos los objetos y variables a nivel clase
        static private OleDbConnection Conexion;
        static private OleDbCommand Orden;

        //Indicamos el nombre de la base de datos dentro de cadena de conexion
        static string strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source = Agenda.mdb;";
        public void Desconectar()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
        }


        //método para leer datos de Access
        public OleDbDataReader Leer(string Consulta)
        {
            //creamos la conexión con la base de datos
            Conexion = new OleDbConnection(strConexion);

            //establecemos la consulta dentro de la conexión
            Orden = new OleDbCommand(Consulta, Conexion);
            try
            {
                Conexion.Open();//abrimos la conexion
                                //ejecutamos la consulta y retornamos el resultado de tipo OleDbDataReader
                return Orden.ExecuteReader();
            }
            catch
            {
                //ante cualquier error en la conexión, se devuelve un valor nulo al DataTable (Tabla)
                OleDbDataReader error = null;
                return error;
            }
        }

        public bool ABM(string Consulta)
        {
            //variable de control
            bool Resultado = false;
            //creamos la conexión con la base de datos
            Conexion = new OleDbConnection(strConexion);
            //establecemos la consulta dentro de la conexión
            Orden = new OleDbCommand(Consulta, Conexion);
            try
            {
                Conexion.Open();//abrimos la conexion
                                //ejecutamos la consulta
                Orden.ExecuteNonQuery();
                //indicamos que todo se realizó de forma correcta
                Resultado = true;
            }
            catch
            {
                //caso contrario, indicamos que hubo un error
                Resultado = false;
            }
            Desconectar();//deconectamos 
                          //devolvemos el valor asignado en la variable de control
            return Resultado;
        }

        
        


    }
}
