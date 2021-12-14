using EmpleadosLibrary;
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
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/v1/empleado")]
        public respuesta listar(string rut="") {

            respuesta resp = new respuesta();
            try
            {
                List<empleados> listado = new List<empleados>();
                empleadoEntity empleadoData = new empleadoEntity();
                DataSet data = rut == "" ? empleadoData.listadoEmpleados() : empleadoData.listadoEmpleados(rut);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    empleados item = new empleados();
                    item.rut = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.apellido = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    listado.Add(item);
                }              
                //operacion correcta 
                resp.error = false;
                resp.mensaje = "ok";
                if (listado.Count > 0)
                    resp.data = listado;
                else
                    resp.data = "No se encontro el empleado";
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
        [Route("api/v1/empleado")]
        public respuesta guardar(empleados empleado)
        {
            respuesta resp = new respuesta();
            try
            {          
            empleadoEntity emp = new empleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.telefono);
            int estado = emp.guardar();

            if (estado == 1)
            {
                resp.error = false;
                resp.mensaje = "Empleado ingresado correctamente";
                resp.data = empleado;
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
        [Route("api/v1/empleado")]
        public respuesta eliminar(string rut)
        {
            respuesta resp = new respuesta();
            try
            {

            empleadoEntity emp = new empleadoEntity();
                emp.Rut = rut;
            int estado = emp.eliminar();

            if (estado == 1)
            {
                resp.error = false;
                resp.mensaje = "Empleado eliminado existosamente";
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
