using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
using Capa_entidad;


namespace Domain
{
    public class ClassNegocio
    {
      ClassDatos objd = new ClassDatos();

        public DataTable N_listar_trabajadores()
        {
            return objd.D_listar_trabajadores();
        }
        public DataTable N_buscar_trabajadores(ClassEntidad obje)
        {
            return objd.D_buscar_trabajadores(obje);
        }

        public string N_mantenimiento_trabajador(ClassEntidad obje)
        {
            return objd.D_mantenimiento_trabajadores(obje);   
        }

    }
}
