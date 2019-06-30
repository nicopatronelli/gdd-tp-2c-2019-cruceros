using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoCrucerosFueraServicioForm : Form
    {   
        private string rangoFechasQuery;

        public ListadoCrucerosFueraServicioForm()
        {
            InitializeComponent();
        }
        
        // Constructor que vamos a utilizar 
        public ListadoCrucerosFueraServicioForm(string rangoFechasQuery)
        {
            InitializeComponent();
            this.rangoFechasQuery = rangoFechasQuery;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoCrucerosFueraServicioForm_Load(object sender, EventArgs e)
        {
            // Mostramos el resultado de la consulta por pantalla
            //ListadoUtil.cargar(Consultas.crucerosConMasDiasFueraServicio(rangoFechasQuery), dgvListadoEstadistico);
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramAnio = new Parametro("@ano", SqlDbType.Int, 2019);
            Parametro paramSemestre = new Parametro("@semestre", SqlDbType.Int, 1);
            //FuncionSQL funcionListadoCrucerosFs = new FuncionSQL("[LOS_BARONES_DE_LA_CERVEZA].[UF_listado_fuera_de_servicio]", 
              //  parametros, SqlDbType.Structured);

            //funcionListadoCrucerosFs.ejecutar();
            //this.dgvListadoEstadistico

            //
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT [LOS_BARONES_DE_LA_CERVEZA].[UF_listado_fuera_de_servicio](@ano, @semestre)", conexion.obtenerConexion());
            dataAdapter.SelectCommand.Parameters.Add(paramAnio.obtenerSqlParameter());
            dataAdapter.SelectCommand.Parameters.Add(paramSemestre.obtenerSqlParameter());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            this.dgvListadoEstadistico.DataSource = dt;
            //
        }

    }
}
