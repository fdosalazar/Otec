using OtecLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBApi.Models;

namespace WEBApi.Controllers
{
    public class CursoController : ApiController
    {
        [HttpGet]
        [Route("api/v1/curso")]
        public respuesta listar(string idCurso = "")
        {

            respuesta resp = new respuesta();
            try
            {
                List<cursos> listado = new List<cursos>();
                cursoEntity cursoData = new cursoEntity();
                DataSet data = idCurso == "" ? cursoData.listadoCursos() : cursoData.listadoCursos(idCurso);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    cursos item = new cursos();
                    item.idCurso = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    listado.Add(item);
                }
                //operacion correcta 
                resp.error = false;
                resp.mensaje = "ok";
                if (listado.Count > 0)
                    resp.data = listado;
                else
                    resp.data = "No se encontro el Curso";
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpPost]
        [Route("api/v1/curso")]
        public respuesta guardar(cursos curso)
        {
            respuesta resp = new respuesta();
            try
            {
                cursoEntity emp = new cursoEntity(curso.idCurso, curso.nombre);
                int estado = emp.guardar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Curso ingresado correctamente";
                    resp.data = curso;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se pudo realizar el ingreso";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpDelete]
        [Route("api/v1/curso")]
        public respuesta eliminar(string idCurso)
        {
            respuesta resp = new respuesta();
            try
            {

                cursoEntity cur = new cursoEntity();
                cur.IdCurso = idCurso;
                int estado = cur.eliminar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Curso eliminado existosamente";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se pudo realizar la eliminacion";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
    }
}