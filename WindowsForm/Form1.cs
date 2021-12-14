using EmpleadosLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {

        empleadoEntity empleado = new empleadoEntity();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empleado.Rut = txt_rut.Text;
            empleado.Nombre = txt_nombre.Text;
            empleado.Apellido = txt_apellido.Text;
            empleado.Telefono = txt_telefono.Text;

            DataSet resultado = empleado.listadoEmpleados(empleado.Rut);
            if(resultado.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Rut de empleado ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                int x = empleado.guardar(empleado);

                if (x == 1)
                {
                    MessageBox.Show("Empleado Guardado", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error en Guardado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
