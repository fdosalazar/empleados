using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosLibrary
{
    public class Datos
    {
        public SqlConnection conexion = new SqlConnection("Data Source=200.36.208.13;Initial Catalog=pooipvg;User ID=ipvg;Password=ipvg");

        public void Conectar()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        public void Desconectar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public DataSet listado(string query)
        {
            Conectar();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
            adapter.Fill(data);
            Desconectar();
            return data;
        }

        public int ejecutar(string query) {
            Conectar();
            SqlCommand com = new SqlCommand(query, conexion);
            int resultado = com.ExecuteNonQuery();
            Desconectar();
            return resultado;
        }


        public DataSet listado(String NombreSP, List<claseParametro> lst)
        {
            DataSet dt = new DataSet();
            SqlDataAdapter da;
            try
            {
                Conectar();
                da = new SqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Desconectar();
            return dt;
        }



    }
}
