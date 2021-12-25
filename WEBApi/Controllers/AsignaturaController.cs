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
    public class AsignaturaController : ApiController
    {
        [HttpGet]
        [Route("api/v1/asignatura")]
        public respuesta listar(string idAsignatura = "")
        {

            respuesta resp = new respuesta();
            try
            {
                List<asignaturas> listado = new List<asignaturas>();
                asignaturaEntity asignaturaData = new asignaturaEntity();
                DataSet data = idAsignatura == "" ? asignaturaData.listadoAsignatura() : asignaturaData.listadoAsignatura(idAsignatura);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    asignaturas item = new asignaturas();
                    item.idAsignatura = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    listado.Add(item);
                }
                //operacion correcta 
                resp.error = false;
                resp.mensaje = "ok";
                if (listado.Count > 0)
                    resp.data = listado;
                else
                    resp.data = "No se encontro la Asignatura";
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
        [Route("api/v1/asignatura")]
        public respuesta guardar(asignaturas asignatura)
        {
            respuesta resp = new respuesta();
            try
            {
                asignaturaEntity emp = new asignaturaEntity(asignatura.idAsignatura, asignatura.nombre);
                int estado = emp.guardar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura ingresado correctamente";
                    resp.data = asignatura;
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
        [Route("api/v1/aisgnatura")]
        public respuesta eliminar(string idAsignatura)
        {
            respuesta resp = new respuesta();
            try
            {

                asignaturaEntity asig = new asignaturaEntity();
                asig.IdAsignatura = idAsignatura;
                int estado = asig.eliminar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura eliminado existosamente";
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