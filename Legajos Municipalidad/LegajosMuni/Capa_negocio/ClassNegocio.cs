using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;
using capa_entidad;

namespace Capa_negocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_listar_agente()
        {
            return objd.D_listar_agente();

        }

        public DataTable n_buscar_agente(ClassEntidad obje)
        {
            return objd.D_buscar_agente(obje);
        }

        public string N_mantenimiento_agentes(ClassEntidad obje)
        {
            return objd.D_mantenimiento_agentes(obje);
        }
    }
}
