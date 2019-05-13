using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils
{
    class Parametro
    {

        SqlParameter param = null;

        /*** INICIO - CONSTRUCTORES ***/

        // Constructor para nombre y tipo de parametro 
        public Parametro(string nombreParam, SqlDbType tipoParam)
        {
            param = new SqlParameter(nombreParam, tipoParam);
        }

        // Constructor para nombre, tipo y valor del parametro
        public Parametro(string nombreParam, SqlDbType tipoParam, Object valor)
        {
            param = new SqlParameter(nombreParam, tipoParam);
            if (valor.Equals("") && valor.GetType().Equals(typeof(string))) // Reemplazo la cadena vacía por null
                param.Value = DBNull.Value;
            else
                param.Value = valor;
        }

        // Constructor para nombre, tipo, valor y tamaño del parametro (cuarto parametro)
        public Parametro(string nombreParam, SqlDbType tipoParam, Object valor, int size)
        {
            param = new SqlParameter(nombreParam, tipoParam, size);
            if (valor.Equals("") && valor.GetType().Equals(typeof(string))) // Reemplazo la cadena vacía por null
                param.Value = DBNull.Value;
            else
                param.Value = valor;
        }

        /*** FIN- CONSTRUCTORES ***/

        public SqlParameter obtenerSqlParameter()
        {
            return param;
        }

        public object obtenerValor()
        {
            return param.Value;
        }

        public void esParametroOut() // Es un set, no una pregunta 
        {
            // Establecer el parámetro como de salida (para los SP que tengan parametros OUT)
            param.Direction = ParameterDirection.Output;
        }

        public void esCadenaVaciaYNoNull()
        {
            param.Value = "";
        }

    }
}
