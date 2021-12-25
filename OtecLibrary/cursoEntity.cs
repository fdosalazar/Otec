using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class cursoEntity
    {
        private string idCurso;
        private string nombre;

        Datos data = new Datos();

        public string IdCurso { get => idCurso; set => idCurso = value; }
        public string Nombre { get => nombre; set => nombre = value; }
     
        public cursoEntity()
        {

        }
        public cursoEntity(string idCurso, string nombre)
        {
            this.idCurso = idCurso;
            this.nombre = nombre;
        }


        public DataSet listadoCursos() {         
            return data.listado("SELECT * FROM CURSO");
        }

        public DataSet listadoCursos(string idCurso)
        { 
            return data.listado("SELECT * FROM CURSOS WHERE id = '"+ idCurso + "'");
           
        }


        public int guardar(cursoEntity curso)
        {
            return data.ejecutar("Insert into EMPLEADO(id, nombre) values('" + curso.IdCurso + "','" + curso.Nombre + "','" +  "')");
        }
        public int guardar()
        {
            return data.ejecutar("Insert into EMPLEADO(id, nombre) values('" + this.IdCurso + "','" + this.nombre + "','" + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM EMPLEADO WHERE ID= '" + this.idCurso + "'");
        }
    }
}
