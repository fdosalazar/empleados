using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosLibrary
{
    public class empleadoEntity
    {
        private string rut;
        private string nombre;
        private string apellido;
        private string telefono;

        Datos data = new Datos();

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
     
        public empleadoEntity()
        {

        }
        public empleadoEntity(string rut, string nombre, string apellido, string telefono)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }


        public DataSet listadoEmpleados() {         
            return data.listado("SELECT * FROM EMPLEADO");
        }

        public DataSet listadoEmpleados(string rut)
        {
            return data.listado("SELECT * FROM EMPLEADO WHERE RUT = '"+ rut +"'");
           
        }


        public int guardar(empleadoEntity empleado)
        {
            return data.ejecutar("Insert into EMPLEADO(rut, nombre, apellido, telefono) values('" + empleado.Rut + "','" + empleado.Nombre + "','" + empleado.Apellido + "','" + empleado.Telefono + "')");
        }
        public int guardar()
        {
            return data.ejecutar("Insert into EMPLEADO(rut, nombre, apellido, telefono) values('" + this.rut + "','" + this.nombre + "','" + this.apellido + "','" + this.telefono + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM EMPLEADO WHERE RUT= '" + this.rut + "'");
        }
    }
}
