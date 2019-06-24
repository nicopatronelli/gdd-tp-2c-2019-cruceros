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
using FrbaCrucero.AbmRecorrido.Dominio;
using FrbaCrucero.AbmRecorrido.Dominio.Excepciones;

namespace FrbaCrucero.AbmRecorrido.EditarRecorrido
{
    public partial class EditarRecorridoForm : AltaRecorridoForm
    {
        string identificadorRecorridoAEditar;
        int pkRecorridoAEditar;

        public EditarRecorridoForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar
        public EditarRecorridoForm(string identificadorRecorridoAEditar)
        {
            InitializeComponent();
            this.identificadorRecorridoAEditar = identificadorRecorridoAEditar;
            this.gpbxAltaNuevoRecorrido.Text = "Editar Recorrido";
            this.btnEnviar.Text = "Guardar";
        }

        private void EditarRecorridoForm_Load(object sender, EventArgs e)
        {
            // 1. Cargamos el identificador del recorrido a editar en el txtbox
            this.txtbxCodRecorrido.Text = identificadorRecorridoAEditar;

            // 1. Populamos el dgvTramosSeleccionados con los tramos que forman parte del recorrido a editar
            string miConsulta = "SELECT "
                + "t.id_tramo id_tramo, "
                + "puerto_inicio.puerto_nombre puerto_inicio_tramo, "
                + "puerto_fin.puerto_nombre puerto_fin_tramo, "
                + "t.tramo_precio precio_tramo "
             + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr "
                        + "ON r.id_recorrido = tpr.id_recorrido "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                        + "ON tpr.id_tramo = t.id_tramo "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                        + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                        + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                + "WHERE r.recorrido_codigo = @identificador_recorrido";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramPuertoInicio = new Parametro("@identificador_recorrido", SqlDbType.NVarChar, identificadorRecorridoAEditar, 255);
            parametros.Add(paramPuertoInicio);
            Query query = new Query(miConsulta, parametros);
            SqlDataReader sqlDataReader = query.ejecutarReader();
            int idTramo;
            string tramoPuertoInicio, tramoPuertoFin;
            double precioTramo;
            Tramo tramoSeleccionado;
            while (sqlDataReader.Read())
            {
                idTramo = Convert.ToInt32(sqlDataReader["id_tramo"]);
                tramoPuertoInicio = sqlDataReader["puerto_inicio_tramo"].ToString();
                tramoPuertoFin = sqlDataReader["puerto_fin_tramo"].ToString();
                precioTramo = Convert.ToDouble(sqlDataReader["precio_tramo"]);
                tramoSeleccionado = new Tramo(idTramo, tramoPuertoInicio, tramoPuertoFin, precioTramo);
                this.recorrido.addTramo(tramoSeleccionado);
                this.tramosSeleccionados.agregarTramo(tramoSeleccionado);
                this.recorrido.getPrecio().aumentarLblPrecioRecorrido(tramoSeleccionado.getPrecio());
            }

            // Populamos el dgvTramosDisponibles según el puerto fin del último tramo del recorrido a editar
            Tramo ultimoTramo = this.tramosSeleccionados.getUltimoTramo();
            this.tramosDisponibles.popularTramosPosibles(ultimoTramo.getPuertoFin());

            // 5. A partir de ahora, estamos en la misma situación que en un alta de nuevo recorrido
        }

        // Cambiamos el comportamiento del botón Enviar nuevo recorrido: Ahora será el botón Guardar los cambios del recorrido editado
        override protected void btnEnviar_Click(object sender, EventArgs e) // Botón GUARDAR
        {
            // 1. Primero actualizamos el identificador del recorrido
            // Seteamos el identificador al recorrido y validamos que no sea nulo o cadena vacía
            try
            {
                recorrido.setIdentificador(txtbxCodRecorrido.Text);
            }
            catch (IdentificadorCruceroNullException ex)
            {
                ex.mensajeError();
                return;
            }

            // Validamos que el código de recorrido éste disponible 
            string identificadorRecorridoEditado = txtbxCodRecorrido.Text; // Puede ser igual al anterior
            if (this.identificadorDisponible(identificadorRecorridoAEditar, identificadorRecorridoEditado).Equals(false))
            {
                MensajeBox.error("El identificador ingresado para el recorrido ya se encuentra en uso en otro recorrido diferente a éste. Por favor, pruebe con uno diferente.");
                return;
            }

            // 2. Borramos todos sus tramos por recorrido en la BD
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramPkRecorrido = new Parametro("@pk_recorrido", SqlDbType.Int, pkRecorridoAEditar);
            parametros.Add(paramPkRecorrido);
            string consulta = "DELETE FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido WHERE id_recorrido = @pk_recorrido";
            Query miConsulta = new Query(consulta, parametros);
            miConsulta.ejecutarNonQuery();

            // 3. Insertamos los nuevos tramos seleccionados para el recorrido a editar
            recorrido.actualizar(identificadorRecorridoAEditar);

            // 4. Mostramos mensaje de confirmación

            this.Close(); // Cerramos el formulario de editar recorrido
        }

        private bool identificadorDisponible(string identificadorRecorridoAEditar, string identificadoRecorridoEditado)
        {
            // Recuperamos la pk del recorrido a editar (podría ir en Load o constructor)
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorRecorridoAEditar = new Parametro("@identificador_recorrido_a_editar", SqlDbType.NVarChar, identificadorRecorridoAEditar, 255);
            parametros.Add(paramIdentificadorRecorridoAEditar);
            string consultaRecorridopk = "SELECT id_recorrido FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido WHERE recorrido_codigo = @identificador_recorrido_a_editar";
            Query queryObtenerPk = new Query(consultaRecorridopk, parametros);
            pkRecorridoAEditar = Convert.ToInt32(queryObtenerPk.ejecutarEscalar());
         
            // Chequeamos si el identificador elegido no está en uso para otro recorrido que no tenga la pk del recorrido editado
            string consultaIdentificadorDisponible = "SELECT COUNT(*) "
                                                   + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido "
                                                   + "WHERE recorrido_codigo = @identificador_recorrido_editado "
                                                        + "AND id_recorrido != @pk_recorrido_a_editar";
            Parametro paramIdentificadoRecorridoEditado = new Parametro("@identificador_recorrido_editado", SqlDbType.NVarChar, identificadoRecorridoEditado, 255);
            Parametro paramPkIdentificadorRecorridoAEditar = new Parametro("@pk_recorrido_a_editar", SqlDbType.Int, pkRecorridoAEditar);
            parametros = new List<Parametro>();
            parametros.Add(paramIdentificadoRecorridoEditado);
            parametros.Add(paramPkIdentificadorRecorridoAEditar);
            Query queryIdentificadorRecorridoDisponible = new Query(consultaIdentificadorDisponible, parametros);
            int resultado = Convert.ToInt32(queryIdentificadorRecorridoDisponible.ejecutarEscalar());
            if (resultado.Equals(0))
                return true;
            else
                return false;
        }

    }
}
