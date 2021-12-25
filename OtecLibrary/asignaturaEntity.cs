using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class asignaturaEntity
    {
        private string idAsignatura;
        private string nombre;

        Datos data = new Datos();

        public string IdAsignatura { get => idAsignatura; set => idAsignatura = value; }
        public string Nombre { get => nombre; set => nombre = value; }
     
        public asignaturaEntity()
        {

        }
        public asignaturaEntity(string idAsignatura, string nombre)
        {
            this.idAsignatura = idAsignatura;
            this.nombre = nombre;
        }


        public DataSet listadoAsignatura() {         
            return data.listado("SELECT * FROM ASIGNATURA");
        }

        public DataSet listadoAsignatura(string idAsignatura)
        { 
            return data.listado("SELECT * FROM ASIGNATURA WHERE id = '" + idAsignatura + "'");
           
        }


        public int guardar(asignaturaEntity asignatura)
        {
            return data.ejecutar("Insert into EMPLEADO(id, nombre) values('" + asignatura.IdAsignatura + "','" + asignatura.Nombre + "','" +  "')");
        }
        public int guardar()
        {
            return data.ejecutar("Insert into EMPLEADO(id, nombre) values('" + this.IdAsignatura + "','" + this.nombre + "','" + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM EMPLEADO WHERE ID= '" + this.idAsignatura + "'");
        }
    }
}
