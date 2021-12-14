using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosLibrary
{
    public class claseParametro
    {
        private string m_Nombre;
        private object m_Valor;
        private SqlDbType m_TipoDato;
        private ParameterDirection m_Direccion;
        private int m_Tamaño;

        public string Nombre { get => m_Nombre; set => m_Nombre = value; }
        public object Valor { get => m_Valor; set => m_Valor = value; }
        public SqlDbType TipoDato { get => m_TipoDato; set => m_TipoDato = value; }
        public ParameterDirection Direccion { get => m_Direccion; set => m_Direccion = value; }
        public int Tamaño { get => m_Tamaño; set => m_Tamaño = value; }

        public claseParametro(string ObjNombre, object objValor)
        {
            m_Nombre = ObjNombre;
            m_Valor = objValor;
            m_Direccion = ParameterDirection.Input;
        }

        public claseParametro(string ObjNombre, object objValor, SqlDbType objTipoDato, ParameterDirection objDireccion, int objTamaño)
        {
            m_Nombre = ObjNombre;
            m_Valor = objValor;
            m_Direccion = objDireccion;
            m_TipoDato = objTipoDato;
            m_Tamaño = objTamaño;
        }
    }
}
